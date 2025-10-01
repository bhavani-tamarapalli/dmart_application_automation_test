

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Amazon_Application.Pages
{
    public class SubNavigationPage
    {
        private IWebDriver driver;

        public SubNavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAllSubNavItems(string topNavText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); 

            
            IWebElement topNavItem = FindTopNavByText(topNavText, wait);
            if (topNavItem == null)
            {
                Console.WriteLine($"Could not find top nav item: {topNavText}");
                return;
            }

            Console.WriteLine($"Clicking top nav item: {topNavText}");
            try
            {
                topNavItem.Click();
                Thread.Sleep(1000); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking top nav: {ex.Message}");
                return;
            }

            
            IWebElement subNavContainer = GetSubNavContainer(wait);
            if (subNavContainer == null)
            {
                Console.WriteLine($"No subnav found for: {topNavText}");
                Thread.Sleep(500); 
                return;
            }

            
            var subNavData = GetSubNavData(subNavContainer);
            //Console.WriteLine($"Found {subNavData.Count} subnav items under '{topNavText}'");

            if (subNavData.Count == 0)
            {
                Console.WriteLine("No clickable subnav items found");
                return;
            }

            
            for (int i = 0; i < subNavData.Count; i++)
            {
                try
                {
                    var (text, href) = subNavData[i];
                    //Console.WriteLine($"  [{i + 1}/{subNavData.Count}] Clicking SubNav: {text}");

                    
                    subNavContainer = GetSubNavContainer(wait);
                    if (subNavContainer == null)
                    {
                        Console.WriteLine("    Lost subnav container, breaking loop");
                        break;
                    }

                    var subNavItem = FindSubNavByTextOrHref(subNavContainer, text, href);

                    if (subNavItem != null)
                    {
                       
                        ((IJavaScriptExecutor)driver).ExecuteScript(
                            "arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});", subNavItem); 
                        Thread.Sleep(200); 
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", subNavItem);

                        Thread.Sleep(800); 
                        driver.Navigate().Back();
                        Thread.Sleep(800); 
                    }
                    else
                    {
                        Console.WriteLine($"Could not re-find subnav item: {text}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error clicking subnav: {e.Message}");
                    try
                    {
                        driver.Navigate().Back();
                        Thread.Sleep(800); 
                    }
                    catch { }
                }
            }

            Console.WriteLine($"Completed testing all subnav items for: {topNavText}");
        }

        private IWebElement FindTopNavByText(string text, WebDriverWait wait)
        {
            try
            {
                return wait.Until(d =>
                {
                    
                    var items = d.FindElements(By.XPath("//div[@id='nav-main']//a"));
                    return items.FirstOrDefault(x =>
                        !string.IsNullOrEmpty(x.Text) &&
                        x.Text.Trim().Equals(text, StringComparison.OrdinalIgnoreCase));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding top nav: {ex.Message}");
                return null;
            }
        }

        private IWebElement GetSubNavContainer(WebDriverWait wait)
        {
            try
            {
               
                string[] xpaths = {
                    "//div[contains(@class,'subnav-content')]", 
                    "//div[@id='nav-subnav']" 
                };

                foreach (var xp in xpaths)
                {
                    try
                    {
                        var container = wait.Until(d =>
                        {
                            try
                            {
                                var elem = d.FindElement(By.XPath(xp));
                                return (elem != null && elem.Displayed) ? elem : null;
                            }
                            catch { return null; }
                        });

                        if (container != null)
                        {
                            Console.WriteLine($"Found subnav using XPath: {xp}");
                            return container;
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return null;
        }

        private List<(string text, string href)> GetSubNavData(IWebElement container)
        {
            var data = new List<(string, string)>();
            try
            {
                var subNavItems = container.FindElements(By.TagName("a"));
                Console.WriteLine($"Found {subNavItems.Count} anchor tags in subnav container");

                foreach (var item in subNavItems)
                {
                    try
                    {
                        if (item.Displayed && item.Enabled)
                        {
                            string text = item.Text?.Trim() ?? "";
                            string href = item.GetAttribute("href") ?? "";
                            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(href))
                                data.Add((text, href));
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting subnav data: {ex.Message}");
            }
            return data;
        }

        private IWebElement FindSubNavByTextOrHref(IWebElement container, string text, string href)
        {
            try
            {
                var items = container.FindElements(By.TagName("a")).Where(x => x.Displayed && x.Enabled).ToList();

              
                var item = items.FirstOrDefault(x =>
                    !string.IsNullOrEmpty(x.Text) &&
                    x.Text.Trim().Equals(text, StringComparison.OrdinalIgnoreCase));
                if (item != null) return item;

             
                if (!string.IsNullOrEmpty(href))
                {
                    item = items.FirstOrDefault(x => x.GetAttribute("href") == href);
                    if (item != null) return item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding subnav element: {ex.Message}");
            }
            return null;
        }
    }
}