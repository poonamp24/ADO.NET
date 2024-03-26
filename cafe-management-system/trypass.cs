using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cafe_Management_Syatem
{
    static class trypass
    {
        public static int cInt(string input)
        {

            int x = 0;
            int.TryParse(input, out x);
            return x;
        }
        
        public static double cDouble(string input)
        {

            double x = 0;
            double.TryParse(input, out x);
            return x;
        }
        public static decimal cDecimal(string input)
        {

            decimal x = 0;
            decimal.TryParse(input, out x);
            return x;
        }
        public static DateTime cDatetime(string input)
        {
            DateTime db = new DateTime();
            DateTime.TryParse(input, out db);
            return db;
        }
    }
    
}

