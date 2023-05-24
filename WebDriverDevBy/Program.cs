using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverDevBy.Pages;

namespace WebDriverDevBy;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //1 open main page
        IndexPage indexPage = new IndexPage();
        indexPage.Initialize();

        //2 switch vacancies page 
        VacanciesPage vacanciesPage = indexPage.SwitchToVacanciesPage();

        //3 count  all  vacancies on page
        List<CollectionWrapper> collectionWrappers = new List<CollectionWrapper>();
        collectionWrappers = vacanciesPage.GetCountVacancies();
        //driver.Close();

        collectionWrappers.ToList().ForEach(x => Console.WriteLine(x));

        Console.WriteLine("\n");

        List<CollectionWrapper> collectionSortByDescending = vacanciesPage.SortByDescending();
        collectionSortByDescending.ToList().ForEach(x => Console.WriteLine(x));

        Console.WriteLine("Index = " + indexPage.numberVacancies + "\n" + "Vacancies = " + vacanciesPage.numberVacancies);
        Console.WriteLine(indexPage.numberVacancies == vacanciesPage.numberVacancies);

        indexPage.Unitialize();
    }
}