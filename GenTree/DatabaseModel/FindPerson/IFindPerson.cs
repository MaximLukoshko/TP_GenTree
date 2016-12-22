using Data;
using DatabaseModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.FindPerson
{
    public interface IFindPerson
    {
        IList<Person> GetPeople(Person mask);
        String FindRelation(Int32 first_code, Int32 second_code, IModel model);
    }
}
