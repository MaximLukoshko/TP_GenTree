using Data;
using DatabaseModel.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.FindPerson
{
    class FindPeron : IFindPerson
    {
        protected IDatabase database;
        public FindPeron(IDatabase dtBase)
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
