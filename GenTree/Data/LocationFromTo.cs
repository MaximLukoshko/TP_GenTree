using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LocationFromTo
    {
        public LocationFromTo(String place, DateTime dateFrom, DateTime dateTo)
        {
            Place = place;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
        public String Place { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
