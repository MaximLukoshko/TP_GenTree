using Data;
using DatabaseModel.Database;
using DatabaseModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.FindPerson
{
    class FindPerson : IFindPerson
    {
        protected IDatabase database;
        public FindPerson(ref IDatabase dtBase)
        {
            if (null == dtBase)
                throw new NullReferenceException();

            database = dtBase;
        }

        public IDictionary<Int32, Person> GetPeople(Person mask)
        {
            return database.GetPeople(mask);
        }

        public String FindRelation(Int32 first_code, Int32 second_code, IModel model)
        {
            IDictionary<Int32, Person> cur = model.BuildTree(first_code);

            if (cur.ContainsKey(second_code))
                return "Кровное родство";

            IDictionary<Int32, Person> toFind = model.BuildTree(second_code);
            foreach (Int32 keyTofind in toFind.Keys)
                if (cur.ContainsKey(keyTofind))
                    return "Некровное родство";

            return "Родства нет";
        }
    }
}
