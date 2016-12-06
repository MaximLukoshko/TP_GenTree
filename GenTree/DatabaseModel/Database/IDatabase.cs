using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Database
{
    internal interface IDatabase
    {
        Int32 AddPerson(Person person);
        Person GetPersonByCode(Int32 code);
        IDictionary<Int32, Person> GetPeople(Person mask);
        IDictionary<Int32, Person> GetPeopleByParentCode(Int32 parentCode);
    }
}
