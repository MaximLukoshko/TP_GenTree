using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Database
{
    internal class Database : IDatabase
    {
        protected IDictionary<Int32, Person> data;

        public Database()
        {
            data = new Dictionary<Int32, Person>();
        }

        public Int32 AddPerson(Person person)
        {
            data.Add(data.Count, person);
            return data.Count - 1;
        }

        public Person GetPersonByCode(Int32 code)
        {
            return data[code];
        }

        public IDictionary<Int32, Person> GetPeople(Person mask)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Int32, Person> GetPeopleByParentCode(Int32 parentCode)
        {
            IDictionary<Int32, Person> ret = new Dictionary<Int32, Person>();

            foreach (Person it in data.Values) 
                if (it.Mother == parentCode || it.Father == parentCode)
                    ret.Add(it.Code, it);

            return ret;
        }
    }
}
