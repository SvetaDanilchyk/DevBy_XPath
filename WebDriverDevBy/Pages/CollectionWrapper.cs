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
        public int Count;

        public CollectionWrapper( string name, int count)
        {
            Name = name;
            Count = count; 
        }
        public override string ToString()
        {
            return String.Format("Name: {0} " + "Count: {1}",Name, Count);
        }

    }
}
