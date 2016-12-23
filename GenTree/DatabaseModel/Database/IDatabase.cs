using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Database
{
    public interface IDatabase
    {
        void AddPerson(ref Person person);
        Person GetPersonByCode(Int32 code);
        IDictionary<Int32, Person> GetPeople(Person mask);
        IDictionary<Int32, Person> GetPeopleByParentCode(Int32 parentCode);
        void write();
        void read();
    }
}
