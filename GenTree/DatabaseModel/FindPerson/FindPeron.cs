using Data;
using DatabaseModel.Database;
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
    }
}
