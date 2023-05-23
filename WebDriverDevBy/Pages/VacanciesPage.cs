
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WebDriverDevBy.Pages;

internal class VacanciesPage
{
    IWebDriver _driver;
    IWebElement _buttonCloseWindow;

    ReadOnlyCollection<IWebElement> vacancies;

    const string VACANCIES_COLLECTIONS_XPATH = "//a[@class='collections__item gtm-track-collection-click']";
    const string VACANCIES_PAGE_WINDOWB_XPATH = "//button[@class = 'wishes-popup__button-close wishes-popup__button-close_icon']";//= 'submit'
    
    ////a[@class = "collections__item gtm-track-collection-click" and text() = "QA"] 
    ///"//a[@class='collections__item gtm-track-collection-click']/child::text()"
    ////span[@class="collections__item-sub"] - col for list

    List<CollectionWrapper> collections = new List<CollectionWrapper>();

    public VacanciesPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public int GetCountVacancies()
    {
        vacancies = _driver.FindElements(By.XPath(VACANCIES_COLLECTIONS_XPATH));
        //vacanciesName = _driver.FindElements(By.XPath("//a[@class='collections__item gtm-track-collection-click']"));


        //for (int i = 0; i < vacanciesName.Count(); i++)

        //vacanciesName.Where(x => x.Text != null).ToList().ForEach(e =>

        vacancies.ToList().ForEach(x => 
        {
            String[] splitResult = x.Text.Split("\r\n");
            collections.Add(new CollectionWrapper(splitResult[0], Int32.Parse(splitResult[1])));
        });
        

        // vacanciesCount = _driver.FindElements(By.XPath(VACANCIES_LIST_COUNT_XPATH));
        //var vacanciesNum = vacanciesCount.Select(x => x.Text).ToList();

        //var allVacancies = vacancies.Select(x => x.Text).ToList();

        //for(int i = 0; i < allVacancies.Count(); i++)
        //{
        //    collections.Add(new CollectionWrapper(allVacancies[i], Int32.Parse(vacanciesNum[i])));
        //}

        //for (int i = 0; i < collections.Count(); i++)
        //{
        //   collections[i].name.Split('\r');
        //}

        return vacancies.Count();
    }

    public void CloseInfoWindowOnVacanciesPage()
    {
        _buttonCloseWindow = _driver.FindElement(By.XPath(VACANCIES_PAGE_WINDOWB_XPATH));
        _buttonCloseWindow.Click();
    }

    private class CollectionWrapper
    {
        public String name;
        public int count;

        public CollectionWrapper(String name, int count)
        {
            this.name = name;
            this.count = count;
        }
    }

}


