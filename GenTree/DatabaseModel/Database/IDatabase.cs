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
        void UpdatePerson(ref Person person);
        Person GetPersonByCode(Int32 code);
        IList<Person> GetPeople(Person mask);
        IList<Person> GetPeopleByParentCode(Int32 parentCode);
    }
}
