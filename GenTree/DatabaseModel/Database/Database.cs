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
            
            Person person = new Person();
            person.FirstName = "Maxim";
            person.SecondName= "Lukoshko";
            person.MiddleName= "Alexander";
            person.BirthDate=(new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            AddPerson(ref person);
        }

        public void AddPerson(ref Person person)
        {
            person.Code = data.Count + 1;
            data.Add(person.Code, person);
        }

        public Person GetPersonByCode(Int32 code)
        {
            return data[code];
        }

        public IDictionary<Int32, Person> GetPeople(Person mask)
        {
            IDictionary<Int32, Person> ret = new Dictionary<Int32, Person>();

            foreach(Person person in data.Values)
            {
                if (mask.FirstName.Length > 0 && person.FirstName.IndexOf(mask.FirstName) < 0)
                    continue;
                if (mask.SecondName.Length > 0 && person.SecondName.IndexOf(mask.SecondName) < 0)
                    continue;
                if (mask.MiddleName.Length > 0 && person.MiddleName.IndexOf(mask.MiddleName) < 0)
                    continue;
                if (mask.BirthPlace.Length > 0 && person.BirthPlace.IndexOf(mask.BirthPlace) < 0)
                    continue;
                if (mask.BirthDateCorrectField[0] && person.BirthDate.Year != mask.BirthDate.Year)
                    continue;
                if (mask.BirthDateCorrectField[1] && person.BirthDate.Month != mask.BirthDate.Month)
                    continue;
                if (mask.BirthDateCorrectField[2] && person.BirthDate.Day != mask.BirthDate.Day) 
                    continue;
                if (person.Gender != mask.Gender)
                    continue;
                
                //Если всё совпало с маской, то добавляем человека
                ret.Add(person.Code, person);
            }

            return ret;
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
