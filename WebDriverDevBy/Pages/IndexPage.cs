using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class IndexPage
{
    IWebDriver _driver;
    IWebElement _vacancieesLink;

    public ReadOnlyCollection<VacanciesList> Vacanciees;

    const string VACANCIES_PAGE_XPATH = "//a[@class='navbar__nav-item navbar__nav-item_label']"; 
    
    

    public IndexPage()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://devby.io/"; 
    }

    public void Initialize()
    {
        _vacancieesLink = _driver.FindElement(By.XPath(VACANCIES_PAGE_XPATH));
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
    

