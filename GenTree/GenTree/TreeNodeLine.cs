using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenTree
{
    public class TreeNodeLine : IComparable
    {
        private Person personData;
        private Int32 Level;
        public Person PersonData
        {
            get
            {
                return personData;
            }
            
            set
            {
                personData = value;
            }
        }
        public TreeNodeLine(Person person, Int32 level)
        {
            personData = person;
            Level = level;
        }

        public override string ToString()
        {
            String space = new String( ' ', 5 - Level.ToString().Length );
            return Level.ToString() + ")" + space + PersonData.ToString();
        }

        public int CompareTo(object obj)
        {
            return CompareTo((TreeNodeLine)obj);
        }

        public int CompareTo(TreeNodeLine other)
        {
            return this.Level.CompareTo(other.Level);
        }
        public override int GetHashCode()
        {
            return personData.Code;
        }
    }
}
