using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.FindPerson
{
    internal interface IFindPerson
    {
        IDictionary<Int32, Person> GetPeople(Person mask);
    }
}
