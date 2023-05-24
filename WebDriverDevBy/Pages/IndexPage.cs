using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class IndexPage
{
    IWebDriver _driver;
    IWebElement _vacancieesLink;

    const string VACANCIES_PAGE_XPATH = "//a[@class='navbar__nav-item navbar__nav-item_label']";
    const string VACANCIES_COUNT_XPATH = "//h2[@class ='informer__title']";

    public int numberVacancies {get; set;}

    public IndexPage()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://devby.io/";
    }

    public void Initialize()
    {
        _vacancieesLink = _driver.FindElement(By.XPath(VACANCIES_PAGE_XPATH));
        GetNumberOfVacancies();
    }

    public void GetNumberOfVacancies()
    {
        var vacanciesCount = _driver.FindElements(By.XPath(VACANCIES_COUNT_XPATH)).First().Text;
        String[] stringVacanciesCount = vacanciesCount.Split(" ");
        numberVacancies = Int32.Parse(stringVacanciesCount[0]);
        //return Int32.Parse(stringVacanciesCount[0]);

    }

    public VacanciesPage SwitchToVacanciesPage()
    {
        _vacancieesLink.Click();
        new VacanciesPage(_driver).CloseInfoWindowOnVacanciesPage();
        return new VacanciesPage(_driver);

    }

    public void Unitialize() ////////////////////&&
    {
        _driver.Close();
    }

}
    

