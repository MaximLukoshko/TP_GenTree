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
        IDictionary<Int32, Person> FindPeople(Person mask);
        IDictionary<Int32, Person> BuildTree(Int32 code);
        void AddPerson(Person person);
        String FindRelations(Int32 first_code, Int32 second_code);
    }
}
