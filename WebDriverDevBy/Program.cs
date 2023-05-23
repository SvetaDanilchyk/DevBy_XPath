using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverDevBy.Pages;

namespace WebDriverDevBy;

internal class Program
{
    static void Main(string[] args)
    {
        //1 open main page
        IndexPage indexPage = new IndexPage();
        indexPage.Initialize();

        //2 switch vacancies page 
        VacanciesPage vacanciesPage = indexPage.SwitchToVacanciesPage();

        //3 count  all  vacancies on page
        int numberVacancies = vacanciesPage.GetCountVacancies();
        //driver.Close();

        Console.WriteLine(numberVacancies);

        indexPage.Unitialize();
    }
}