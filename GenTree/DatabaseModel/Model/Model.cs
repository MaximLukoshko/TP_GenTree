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
    class Model : IModel
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

        public IDictionary<Int32, Person> FindPeople(Person mask)
        {
            return findPerson.GetPeople(mask);
        }

        public IDictionary<Int32, Person> BuildTree(Int32 code)
        {
            return treeFormer.FormTree(code);
        }

        public Int32 AddPerson(Person person)
        {
            return dataBase.AddPerson(person);
        }

        public String FindRelations(Int32 first_code, Int32 second_code)
        {
            return findPerson.FindRelation(first_code, second_code);
        }
    }
}
