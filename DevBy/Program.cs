using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevBy;

internal class Program
{
    static void Main(string[] args)
    {
        WebDriver driver = new ChromeDriver();
        driver.Url = "https://devby.io/";

        var menuPoint = driver.FindElement(By.XPath("//a[@class='navbar__nav-item'][text()='Польша']"));

        //var menuPoint = menuPoints.Where(x => x.Text == "Польша").First();
        menuPoint.Click();

        var cardNews = driver.FindElements(By.XPath("//div[@class='card card_media card_col-mobile']")).Last();
        cardNews.Click();

        driver.Close();

    }
}