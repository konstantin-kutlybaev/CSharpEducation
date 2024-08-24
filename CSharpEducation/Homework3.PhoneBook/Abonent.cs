using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework3.PhoneBook
{
    internal class Abonent
    {
        public string Name { get; set; }
        public string SubNumber { get; set; }

        public Abonent(string name, string subNumber) 
        {
            this.Name = name;
            this.SubNumber = subNumber;
        }
    }
}
