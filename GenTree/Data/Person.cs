using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Person
    {
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Boolean IsCorrectDate { get; set; }
        public String BirthPlace { get; set; }
        public Int32 Code { get; set; }
        public Int32 Mother { get; set; }
        public Int32 Father { get; set; }
        public DateTime DeathDate { get; set; }
        public String DeathPlace { get; set; }
        public String Nationality { get; set; }
        public String SocialStatus { get; set; }
        public ICollection<String> Education { get; set; }
        public ICollection<String> Profession { get; set; }
        public ICollection<LocationFromTo> Location { get; set; }
        public String DataSource { get; set; }
        public String Note { get; set; }


    }
}
