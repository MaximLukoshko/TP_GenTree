using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseModel.Database
{
    internal class Database : IDatabase
    {
        protected IDictionary<Int32, Person> data;

        public Database()
        {
            data = new Dictionary<Int32, Person>();
        }
        public void AddPerson(ref Person person)
        {
            person.Code = data.Count + 1;
            if (!data.ContainsKey(person.Code))
                data.Add(person.Code, person);
        }

        public Person GetPersonByCode(Int32 code)
        {
            if (data.ContainsKey(code))
                return data[code];
            else
                return null;
        }

        public IList<Person> GetPeople(Person mask)
        {
            IList<Person> ret = new List<Person>();

            foreach (Person person in data.Values)
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
                if (mask.MotherSecondName != "" && person.IsGenderSet == true && (null == person.MotherSecondName ||
                    person.Gender == true || person.Gender == false &&
                        null != person.MotherSecondName &&
                        person.MotherSecondName.IndexOf(mask.MotherSecondName) < 0))
                    continue;

                //Если всё совпало с маской, то добавляем человека
                ret.Add(person);
            }

            return ret;
        }

        public IList<Person> GetPeopleByParentCode(Int32 parentCode)
        {
            IList<Person> ret = new List<Person>();

            foreach (Person it in data.Values)
                if (it.Mother == parentCode || it.Father == parentCode)
                    ret.Add(it);

            return ret;
        }

        public void UpdatePerson(ref Person person)
        {
            if (data.ContainsKey(person.Code))
                data[person.Code] = person;
        }

        public void write()
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("database.txt"))
            {
                foreach (Person p in data.Values)
                {
                    if (p.FirstName != null)
                       writer.WriteLine("FirstName: " + p.FirstName);
                    if (p.SecondName != null)
                       writer.WriteLine("SecondName: " + p.SecondName);
                    if (p.MotherSecondName != null)
                       writer.WriteLine("MotherSecondName: " + p.MotherSecondName);
                    if (p.MiddleName != null)
                        writer.WriteLine("MiddleName: " + p.MiddleName);
                    writer.WriteLine("IsGenderSet: " + p.IsGenderSet);
                    if (p.IsGenderSet)
                        writer.WriteLine("Gender: " + p.Gender);
                    writer.WriteLine("BirthDateCorrectField[0]: " + p.BirthDateCorrectField[0]);
                    writer.WriteLine("BirthDateCorrectField[1]: " + p.BirthDateCorrectField[1]);
                    writer.WriteLine("BirthDateCorrectField[2]: " + p.BirthDateCorrectField[2]);
                    if (p.BirthDateCorrectField[0])
                        writer.WriteLine("BirthDateDay: " + p.BirthDate.Day);
                    if (p.BirthDateCorrectField[1])
                        writer.WriteLine("BirthDateMonth: " + p.BirthDate.Month);
                    if (p.BirthDateCorrectField[2])
                        writer.WriteLine("BirthDateYear: " + p.BirthDate.Year);
                    if (p.BirthPlace != null)
                        writer.WriteLine("BirthPlace: " + p.BirthPlace);
                    if (p.Mother!=0)
                        writer.WriteLine("Mother: " + p.Mother);
                    if (p.Father != 0)
                        writer.WriteLine("Father: " + p.Father);
                    if (p.MotherName != null)
                        writer.WriteLine("MotherName: " + p.MotherName);
                    if (p.FatherName != null)
                        writer.WriteLine("FatherrName: " + p.FatherName);
                    writer.WriteLine("DeathDateCorrectField[0]: " + p.DeathDateCorrectField[0]);
                    writer.WriteLine("DeathDateCorrectField[1]: " + p.DeathDateCorrectField[1]);
                    writer.WriteLine("DeathDateCorrectField[2]: " + p.DeathDateCorrectField[2]);
                    if (p.DeathDateCorrectField[0])
                        writer.WriteLine("DeathDateDay: " + p.DeathDate.Day);
                    if (p.DeathDateCorrectField[1])
                        writer.WriteLine("DeathDateMonth: " + p.DeathDate.Month);
                    if (p.DeathDateCorrectField[2])
                        writer.WriteLine("DeathDateYear: " + p.DeathDate.Year);
                    if (p.DeathPlace != null)
                        writer.WriteLine("DeathPlace: " + p.DeathPlace);
                    if (p.Nationality != null)
                        writer.WriteLine("Nationality: " + p.Nationality);
                    if (p.SocialStatus != null)
                        writer.WriteLine("SocialStatus: " + p.SocialStatus);
                    foreach(String s in p.Education)
                        writer.WriteLine("Education: " + s);
                    foreach (String s in p.Profession)
                        writer.WriteLine("Profession: " + s);
                    foreach (String s in p.Location)
                        writer.WriteLine("Location: " + s);
                    if (p.DataSource != null)
                        writer.WriteLine("DataSource: " + p.DataSource);
                    if (p.Note != null)
                        writer.WriteLine("Note: " + p.Note);
                    writer.WriteLine();
                }
                writer.WriteLine("end");
            }
        }
        public void read()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader("database.txt"))
            {
                string line;
                Person p=new Person();

                while ((line = reader.ReadLine()) != "end")
                {
                    if (line.Contains("FirstName: "))
                    {
                        p.FirstName = line.Replace("FirstName: ", "");
                        continue;
                    }
                    if (line.Contains("MotherSecondName: "))
                    {
                        p.MotherSecondName = line.Replace("MotherSecondName: ", "");
                        continue;
                    }
                    if (line.Contains("SecondName: "))
                    {
                        p.SecondName = line.Replace("SecondName: ", "");
                        continue;
                    }
                    if (line.Contains("MiddleName: "))
                    {
                        p.MiddleName = line.Replace("MiddleName: ", "");
                        continue;
                    }
                    if (line.Contains("IsGenderSet: "))
                    {
                        if (line.Contains("rue"))
                            p.IsGenderSet = true;
                        else
                            p.IsGenderSet = false;
                        continue;
                    }
                    if (line.Contains("Gender: "))
                    {
                        if (line.Contains("rue"))
                            p.Gender = true;
                        else
                            p.Gender = false;
                        continue;
                    } 
                    if (line.Contains("MotherName: "))
                    {
                        p.MotherName = line.Replace("MotherName: ", "");
                        continue;
                    }
                    if (line.Contains("FatherName: "))
                    {
                        p.FatherName = line.Replace("FatherName: ", "");
                        continue;
                    }
                    if (line.Contains("BirthDateCorrectField[0]: "))
                    {
                        if (line.Contains("rue"))
                            p.BirthDateCorrectField[0] = true;
                        else
                            p.BirthDateCorrectField[0] = false;
                        continue;
                    }
                    if (line.Contains("BirthDateCorrectField[1]: "))
                    {
                        if (line.Contains("rue"))
                            p.BirthDateCorrectField[1] = true;
                        else
                            p.BirthDateCorrectField[1] = false;
                        continue;
                    }
                    if (line.Contains("BirthDateCorrectField[2]: "))
                    {
                        if (line.Contains("rue"))
                            p.BirthDateCorrectField[2] = true;
                        else
                            p.BirthDateCorrectField[2]= false;
                        continue;
                    }
                    if (line.Contains("BirthDateDay: "))
                    {
                        p.BirthDate = p.BirthDate.AddDays(int.Parse(line.Replace("BirthDateDay: ", "")));
                        continue;
                    }
                    if (line.Contains("BirthDateMonth: "))
                    {
                        p.BirthDate=p.BirthDate.AddMonths(int.Parse(line.Replace("BirthDateMonth: ", "")));
                        continue;
                    }
                    if (line.Contains("BirthDateYear: "))
                    {
                        p.BirthDate=p.BirthDate.AddYears(int.Parse(line.Replace("BirthDateYear: ", "")));
                        continue;
                    }
                    if (line.Contains("BirthPlace: "))
                    {
                        p.BirthPlace = line.Replace("BirthPlace: ", "");
                        continue;
                    }
                    if (line.Contains("Mother: "))
                    {
                        p.Mother = int.Parse(line.Replace("Mother: ", ""));
                        continue;
                    }
                    if (line.Contains("Father: "))
                    {
                        p.Father = int.Parse(line.Replace("Father: ", ""));
                        continue;
                    }
                    if (line.Contains("DeathDateCorrectField[0]: "))
                    {
                        if (line.Contains("rue"))
                            p.DeathDateCorrectField[0] = true;
                        else
                            p.DeathDateCorrectField[0] = false;
                        continue;
                    }
                    if (line.Contains("DeathDateCorrectField[1]: "))
                    {
                        if (line.Contains("rue"))
                            p.DeathDateCorrectField[1] = true;
                        else
                            p.DeathDateCorrectField[1] = false;
                        continue;
                    }
                    if (line.Contains("DeathDateCorrectField[2]: "))
                    {
                        if (line.Contains("rue"))
                            p.DeathDateCorrectField[2] = true;
                        else
                            p.DeathDateCorrectField[2] = false;
                        continue;
                    }
                    if (line.Contains("DeathDateDay: "))
                    {
                        p.DeathDate=p.DeathDate.AddDays(int.Parse(line.Replace("DeathDateDay: ", "")));
                        continue;
                    }
                    if (line.Contains("DeathDateMonth: "))
                    {
                        p.DeathDate= p.DeathDate.AddMonths(int.Parse(line.Replace("DeathDateMonth: ", "")));
                        continue;
                    }
                    if (line.Contains("DeathDateYear: "))
                    {
                        p.DeathDate=p.DeathDate.AddYears(int.Parse(line.Replace("DeathDateYear: ", "")));
                        continue;
                    }
                    if (line.Contains("DeathPlace: "))
                    {
                        p.DeathPlace = line.Replace("DeathPlace: ", "");
                        continue;
                    }
                    if (line.Contains("Nationality: "))
                    {
                        p.Nationality = line.Replace("Nationality: ", "");
                        continue;
                    }
                    if (line.Contains("SocialStatus: "))
                    {
                        p.SocialStatus = line.Replace("SocialStatus: ", "");
                        continue;
                    }
                    if (line.Contains("Education: "))
                    {
                        p.Education.Add(line.Replace("Education: ", ""));
                        continue;
                    }
                    if (line.Contains("Profession: "))
                    {
                        p.Profession.Add(line.Replace("Profession: ", ""));
                        continue;
                    }
                    if (line.Contains("Location: "))
                    {
                        p.Location.Add(line.Replace("Location: ", ""));
                        continue;
                    }
                    if (line.Contains("DataSource: "))
                    {
                        p.DataSource=line.Replace("DataSource: ", "");
                        continue;
                    }
                    if (line.Contains("Note: "))
                    {
                        p.Note=line.Replace("Note: ", "");
                        continue;
                    }
                    if (line=="")
                    {
                        AddPerson(ref p);
                        p = new Person();
                        continue;
                    }
                }
            }
        }
    }
}
