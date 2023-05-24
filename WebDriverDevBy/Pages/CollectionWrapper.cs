using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverDevBy.Pages
{
    internal class CollectionWrapper
    {
        public string Name;
        public int CountVacancies;

        public CollectionWrapper( string name, int count)
        {
            Name = name;
            CountVacancies = count; 
        }
        public override string ToString()
        {
            return String.Format("Name: {0} " + "Count: {1}",Name, CountVacancies);
        }

    }
}
