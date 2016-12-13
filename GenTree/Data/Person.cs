using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Person
    {
        public Person()
        {
            BirthDateCorrectField = new List<Boolean>();
            DeathDateCorrectField = new List<Boolean>();
            for (int i = 0; i < 3; i++) 
            {
                BirthDateCorrectField.Add(false);
                DeathDateCorrectField.Add(false);
            }
        }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String MiddleName { get; set; }
        public Boolean Gender { get; set; } // true - мужской, false - женский
        public DateTime BirthDate { get; set; }
        public List<Boolean> BirthDateCorrectField { get; private set; }
        public String BirthPlace { get; set; }
        public Int32 Code { get; set; }
        public Int32 Mother { get; set; }
        public Int32 Father { get; set; }
        public DateTime DeathDate { get; set; }
        public List<Boolean> DeathDateCorrectField { get; private set; }
        public String DeathPlace { get; set; }
        public String Nationality { get; set; }
        public String SocialStatus { get; set; }
        public ICollection<String> Education { get; set; }
        public ICollection<String> Profession { get; set; }
        public ICollection<String> Location { get; set; }
        public String DataSource { get; set; }
        public String Note { get; set; }
    }
}
