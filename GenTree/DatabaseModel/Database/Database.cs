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

            person = new Person();
            person.FirstName = "Maxim";
            person.SecondName= "Lukoshko";
            person.MiddleName= "Alexander";
            person.BirthDate=(new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = true;
            person.IsGenderSet = true;
            person.Father = 3;
            person.Mother = 2;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Mum";
            person.SecondName = "Mum";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = false;
            person.IsGenderSet = true;
            person.Father = 4;
            person.Mother = 5;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Father";
            person.SecondName = "Father";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = true;
            person.IsGenderSet = true;
            person.Father = 6;
            person.Mother = 7;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Ded1";
            person.SecondName = "Ded1";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = true;
            person.IsGenderSet = true;
            AddPerson(ref person);
            
            person = new Person();
            person.FirstName = "Babulya1";
            person.SecondName = "Babulya1";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = false;
            person.IsGenderSet = true;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Ded2";
            person.SecondName = "Ded2";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = true;
            person.IsGenderSet = true;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Babulya2";
            person.SecondName = "Babulya2";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = false;
            person.IsGenderSet = true;
            AddPerson(ref person);

            person = new Person();
            person.FirstName = "Son";
            person.SecondName = "Son";
            person.MiddleName = "Alexander";
            person.BirthDate = (new DateTime()).AddDays(25).AddYears(1997);
            person.BirthDateCorrectField[0] = true;
            person.BirthDateCorrectField[1] = false;
            person.BirthDateCorrectField[2] = true;
            person.Gender = true;
            person.IsGenderSet = true;
            person.Father = 1;
            AddPerson(ref person);
        }

        public void AddPerson(ref Person person)
        {
            person.Code = data.Count + 1;
            data.Add(person.Code, person);
        }

        public Person GetPersonByCode(Int32 code)
        {
            if (data.ContainsKey(code))
                return data[code];
            else
                return null;
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
                if (mask.BirthDateCorrectField[0] && person.BirthDateCorrectField[0]
                        && person.BirthDate.Year != mask.BirthDate.Year)
                    continue;
                if (mask.BirthDateCorrectField[1] && person.BirthDateCorrectField[1]
                        && person.BirthDate.Month != mask.BirthDate.Month)
                    continue;
                if (mask.BirthDateCorrectField[2] && person.BirthDateCorrectField[2]
                        && person.BirthDate.Day != mask.BirthDate.Day)
                    continue;
                if (person.IsGenderSet == true && person.IsGenderSet == mask.IsGenderSet &&
                        person.Gender != mask.Gender)
                    continue;
                if (mask.IsGenderSet == true && person.IsGenderSet == false)
                    continue;
                if (person.IsGenderSet == true && person.Gender == false &&
                        null != person.MotherSecondName &&
                        person.MotherSecondName.IndexOf(mask.MotherSecondName) < 0) 
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
