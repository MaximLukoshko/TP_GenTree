using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    public interface IModel
    {
        IList<Person> FindPeople(Person mask);
        IDictionary<Int32, Person> BuildTree(Int32 code);
        String AddPerson(ref Person person);
        String FindRelations(Int32 first_code, Int32 second_code);
        IList<Person> GetPeopleByParentCode(Int32 parentCode);
    }
}
