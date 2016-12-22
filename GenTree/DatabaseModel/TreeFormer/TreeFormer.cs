using Data;
using DatabaseModel.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.TreeFormer
{
    class TreeFormer : ITreeFormer
    {
        protected IDatabase database;
        public TreeFormer(ref IDatabase dtBase)
        {
            if (null == dtBase)
                throw new NullReferenceException();

            database = dtBase;
        }

        public IDictionary<Int32, Person> FormTree(Int32 code)
        {
            IDictionary<Int32, Person> ret = new Dictionary<Int32, Person>();

            Person rootMan = database.GetPersonByCode(code);
            if (null != rootMan)
            {
                ret.Add(code, rootMan);
                GetChildrenAll(code, ref ret);
                GetParentsAll(code, ref ret);
            }
                        
            return ret;
        }

        private IDictionary<Int32, Person> GetChildren(Int32 code)
        {
            return database.GetPeopleByParentCode(code);
        }

        private void GetChildrenAll(Int32 code, ref IDictionary<Int32, Person> ret)
        {
            IDictionary<Int32, Person> children = GetChildren(code);

            Boolean flag = false;
            foreach(Person iter in children.Values)
            {
                if(!flag)
                {
                    //Получаем второго родителя     
                    AddCollection(ref ret, GetParents(iter.Code).Values);
                    flag = true;
                }
   
                if (!ret.ContainsKey(iter.Code))
                    ret.Add(iter.Code, iter);
                
                //Получаем внуков и т.д.
                if (iter.Code != code)
                    GetChildrenAll(iter.Code, ref ret);
            }
        }

        private IDictionary<Int32, Person> GetParents(Int32 code)
        {
            IDictionary<Int32, Person> ret = new Dictionary<Int32, Person>();

            Person item = database.GetPersonByCode(code);
            if(null != item)
            {
                Person mum = database.GetPersonByCode(item.Mother);
                Person dad = database.GetPersonByCode(item.Father);

                if (null != mum || null != dad)
                {
                    if (null != mum)
                        ret.Add(mum.Code, mum);
                    if (null != dad)
                        ret.Add(dad.Code, dad);
                }

            }

            return ret;
        }

        private void GetParentsAll(Int32 code, ref IDictionary<Int32, Person> ret)
        {
            IDictionary<Int32, Person> parents = GetParents(code);

            Boolean flag = false;
            foreach (Person iter in parents.Values)
            {
                if (!flag)
                {
                    //Получаем братьев и сестёр
                    AddCollection(ref ret, GetChildren(iter.Code).Values);
                    flag = true;
                }
                if (!ret.ContainsKey(iter.Code))
                    ret.Add(iter.Code, iter);
                
                //Получаем бабушек и дедушек
                GetParentsAll(iter.Code, ref ret);
            }
        }
        private void AddCollection(ref IDictionary<Int32, Person> ret, ICollection<Person> collection)
        {
            foreach (Person it in collection)
                if (!ret.ContainsKey(it.Code))
                    ret.Add(it.Code, it);
        }

        public Int32 FindLevel(Int32 code_from, Int32 code_to)
        {
            Int32 ret = 0;
            throw new NotImplementedException();
            return ret;
        }
    }
}
