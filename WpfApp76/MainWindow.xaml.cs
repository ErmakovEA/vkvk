using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace WpfApp76
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void setTextInWebElement(ChromeDriver chromeDriver, string id, string value)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.Id(id)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.SendKeys(value);
                break;
            }
        }
        private void setClickInDate(ChromeDriver chromeDriver, string datatestid, string id)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            foreach (var item in webElements)
            {
                try
                {
                    if (!item.Displayed)
                        continue;
                }
                catch (Exception)
                {
                    continue;
                }
                if (item.GetAttribute("data-test-id") == null)
                    continue;
                if (!item.GetAttribute("data-test-id").Equals(datatestid))
                    continue;
                item.Click();
                break;
            }
            webElements = chromeDriver.FindElements(By.Id(id)).ToList();
            foreach (var item in webElements)
            {
                try
                {
                    if (!item.Displayed)
                        continue;
                }
                catch (Exception)
                {
                    continue;
                }
                item.Click();
                break;
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\Егорушка UwU\AppData\Local\Google\Chrome\User Data");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            List<Vkidtext> vk = new List<Vkidtext>();
            List<Vkphoto> vk2 = new List<Vkphoto>();
            List<Vksilka> vk3 = new List<Vksilka>();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if (item.GetAttribute("class") == null)
                    continue;
                if (!item.GetAttribute("class").Trim().Equals("feed_row"))
                    continue;
                IWebElement webElementId = item.FindElement(By.TagName("div"));
                IWebElement webElementphoto = item.FindElement(By.TagName("img"));
                IWebElement webElementsilka = item.FindElement(By.TagName("a"));
                if (webElementId == null)
                    continue;
                if (webElementId.GetAttribute("id") == null)
                    continue;
                VkNews vkNews = new VkNews();
                vk.Add(new Vkidtext()
                {
                    id = webElementId.GetAttribute("id"),
                    text = item.Text
                });
                JSONWorker.setDataInJson(vk);
                vk2.Add(new Vkphoto()
                {
                    id = webElementId.GetAttribute("id"),
                    photo = webElementphoto.GetAttribute("src")
                });
                JSONWorker.setDataInJson1(vk2);
                vk3.Add(new Vksilka()
                {
                    id = webElementId.GetAttribute("id"),
                    silka = webElementsilka.GetAttribute("href")
                });
                JSONWorker.setDataInJson2(vk3);
            }
        }   
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Vkidtext> vk = JSONWorker.Getvk();
            List<Vkphoto> vk2 = JSONWorker.Getvk1();
            List<Vksilka> vk3 = JSONWorker.Getvk2();

        }
       /*private void setDataInTextFile0()
        {
            List<Vkidtext> vk = JSONWorker.Getvk();
        }
        private void setDataInTextFile1()
        {
          List<Vkphoto> vk2 = JSONWorker.Getvk1();
        }
        private void setDataInTextFile2()
        {
          List<Vkphoto> vk2 = JSONWorker.Getvk1();
        }*/

         private void Button_Click_2(object sender, RoutedEventArgs e)
         {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\Егорушка UwU\AppData\Local\Google\Chrome\User Data");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            List<Vkidtext> vk = new List<Vkidtext>();
            List<Vkphoto> vk2 = new List<Vkphoto>();
            List<Vksilka> vk3 = new List<Vksilka>();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if (item.GetAttribute("class") == null)
                    continue;
                if (!item.GetAttribute("class").Trim().Equals("feed_row"))
                    continue;
                IWebElement webElementId = item.FindElement(By.TagName("div"));
                IWebElement webElementPhoto = item.FindElement(By.TagName("img"));
                IWebElement webElementSilka = item.FindElement(By.TagName("a"));
                if (webElementId == null)
                    continue;
                if (webElementId.GetAttribute("id") == null)
                    continue;
                VkNews vkNews = new VkNews();
                vk.Add(new Vkidtext()
                {
                    id = webElementId.GetAttribute("id"),
                    text = item.Text
                });
                JSONWorker.setDataInJson(vk);
                //Thread thread = new Thread();
                
                vk2.Add(new Vkphoto()
                {
                    //id = webElementId.GetAttribute("id"),
                    photo = webElementPhoto.GetAttribute("src")
                });
                JSONWorker.setDataInJson1(vk2);
                vk3.Add(new Vksilka()
                {
                    //id = webElementId.GetAttribute("id"),
                    silka = webElementSilka.GetAttribute("href")
                });
                JSONWorker.setDataInJson2(vk3);
            }
          //Thread thread = new Thread();
          //thread.Start();
          //Thread thread1 = new Thread();
          //thread1.Start();
          //Thread thread2 = new Thread();
          //thread2.Start();
         }

  }
}
