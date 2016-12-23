using Data;
using DatabaseModel.Database;
using DatabaseModel.FindPerson;
using DatabaseModel.TreeFormer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    public class Model : IModel
    {
        protected IFindPerson findPerson;
        protected ITreeFormer treeFormer;
        protected IDatabase dataBase;

        public Model()
        {
            dataBase = new Database.Database();
            findPerson = new FindPerson.FindPerson(ref dataBase);
            treeFormer = new TreeFormer.TreeFormer(ref dataBase);
        }

        public IList<Person> FindPeople(Person mask)
        {
            return findPerson.GetPeople(mask);
        }

        public IDictionary<Int32, Person> BuildTree(Int32 code)
        {
            return treeFormer.FormTree(code);
        }

        private String CheckCorrectness(ref Person person)
        {
            String ret = "";
            if (person.FirstName == "" && person.SecondName == "" && person.MotherSecondName == "")
                return "Поля Фамилия(Девичья фамилия), Имя не могут быть пустыми одновременно";

            if (person.Mother > 0 && person.Father == 0)
                if (treeFormer.FindLevel(person.Code, person.Mother) > 0)
                    return "Пытаетесь задать матерью своего ребёнка";

            if (person.Mother == 0 && person.Father > 0)
                if (treeFormer.FindLevel(person.Code, person.Father) > 0)
                    return "Пытаетесь задать отцом своего ребёнка";

            if (person.Mother > 0 && person.Father > 0)
            {
                IDictionary<Int32, Person> motherTree = this.BuildTree(person.Mother);
                IDictionary<Int32, Person> fatherTree = this.BuildTree(person.Father);

                foreach (Int32 keyTofind in fatherTree.Keys)
                    if (motherTree.ContainsKey(keyTofind) &&
                        this.treeFormer.FindLevel(keyTofind, person.Mother) != this.treeFormer.FindLevel(keyTofind, person.Father))
                        return "Родители находятся в разных поколениях";

                return "";
            }
            return ret;
        }
        public String AddPerson(ref Person person)
        {
            String ret = CheckCorrectness(ref person);
            if (ret == "")
                dataBase.AddPerson(ref person);

            return ret;
        }

        public String FindRelations(Int32 first_code, Int32 second_code)
        {
            return findPerson.FindRelation(first_code, second_code, this);
        }
        public IList<Person> GetPeopleByParentCode(Int32 parentCode)
        {
            return dataBase.GetPeopleByParentCode(parentCode);
        }

        public String UpdatePerson(ref Person person)
        {
            String ret = CheckCorrectness(ref person);
            if (ret == "")
                dataBase.UpdatePerson(ref person);

            return ret;
        }
    }
}
