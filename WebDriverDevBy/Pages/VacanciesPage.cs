
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class VacanciesPage 
{
    IWebDriver _driver;
    
    ReadOnlyCollection<IWebElement> vacancies;
    public List<CollectionWrapper> CollectionsVacancies;

    const string VACANCIES_COLLECTIONS_XPATH = "//a[@class='collections__item gtm-track-collection-click']";
    const string VACANCIES_PAGE_WINDOWB_XPATH = "//button[@class = 'wishes-popup__button-close wishes-popup__button-close_icon']";//= 'submit'
    
    public int numberVacancies { get; set; }
    public VacanciesPage(IWebDriver driver)
    {
        _driver = driver;
        CollectionsVacancies = new List<CollectionWrapper>();
    }

    public List<CollectionWrapper> GetCountVacancies()
    {
        vacancies = _driver.FindElements(By.XPath(VACANCIES_COLLECTIONS_XPATH));

        for (int i = 0; i < vacancies.Count(); i++)
        {
            String[] splitResult = vacancies[i].Text.Split("\r\n");
            CollectionsVacancies.Add(new CollectionWrapper(splitResult[0], Int32.Parse(splitResult[1])));
        }


        GetNumberOfVacancies();

        return CollectionsVacancies;
    }

    public List<CollectionWrapper> SortByDescending()
    {
        List<CollectionWrapper> sortVacancies = new();

        sortVacancies =  CollectionsVacancies.OrderByDescending(x => x.CountVacancies).ToList();

        return sortVacancies;
    }

    public void CloseInfoWindowOnVacanciesPage()
    {
        Thread.Sleep(5000);
        var buttonCloseWindow = _driver.FindElement(By.XPath(VACANCIES_PAGE_WINDOWB_XPATH));
        buttonCloseWindow.Click();
    }

    public void GetNumberOfVacancies()
    {
        numberVacancies = CollectionsVacancies.Select(x => x.CountVacancies).Sum();
    }

    public void СomparisonNumberForVacancies()
    {
        int acountInVacanciesPage = CollectionsVacancies.Select(x => x.CountVacancies).Sum();
        
    }
}


