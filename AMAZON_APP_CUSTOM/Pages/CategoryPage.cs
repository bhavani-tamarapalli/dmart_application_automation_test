//using Amazon_Application.Utilities;
//using OpenQA.Selenium;

//public class CategoryPage
//{
//    private IWebDriver driver;

//    public CategoryPage(IWebDriver driver)
//    {
//        this.driver = driver;
//    }

//    // Click any Top Nav by locator from config
//    public void ClickTopNav(string navName)
//    {
//        var topNav = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("FreshNavLink"), 10);
//        if (topNav == null)
//            throw new Exception($"Top Nav '{navName}' not found.");

//        topNav.Click();
//        Thread.Sleep(2000);

//        // Special handling for Fresh modal (if it appears)
//        try
//        {
//            var skipBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("FreshSkipButton"), 5);
//            if (skipBtn != null)
//            {
//                skipBtn.Click();
//                Console.WriteLine("Fresh modal skipped.");
//                Thread.Sleep(2000);
//            }
//        }
//        catch { /* ignore if modal not found */ }
//    }

//    // ✅ New method to click nested sub nav under Fresh
//    public void ClickNestedSubNav(string subCategory)
//    {
//        var categories = SeleniumCustomMethods.GetElements(driver, ConfigReader.GetLocator("FreshCategoryLinks"), 10);

//        var target = categories.FirstOrDefault(x =>
//            x.Text.Trim().Equals(subCategory, StringComparison.OrdinalIgnoreCase));

//        if (target == null)
//            throw new Exception($"Nested SubCategory '{subCategory}' not found under Fresh.");

//        target.Click();
//        Thread.Sleep(2000);
//    }

//    // Add first product to cart
//    public void AddFirstProductToCart()
//    {
//        var firstProduct = SeleniumCustomMethods.GetElements(driver, ConfigReader.GetLocator("ProductTitles"), 10).FirstOrDefault();
//        if (firstProduct == null)
//            throw new Exception("No products found on category page.");

//        firstProduct.Click();
//        Thread.Sleep(2000);

//        var addToCartButton = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("AddToCartButton"), 10);
//        if (addToCartButton == null)
//            throw new Exception("Add to Cart button not found.");

//        addToCartButton.Click();

//        Console.WriteLine("✅ Product added to cart successfully!");
//    }
//}


//using Amazon_Application.Utilities;
//using OpenQA.Selenium;
//using System;
//using System.Linq;
//using System.Threading;

//public class CategoryPage
//{
//    private IWebDriver driver;

//    public CategoryPage(IWebDriver driver)
//    {
//        this.driver = driver;
//    }

//    // Click "Fresh" top nav
//    public void ClickTopNav()
//    {
//        try
//        {
//            var topNav = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("FreshNavLink"), 10);
//            if (topNav == null)
//                throw new Exception("Fresh top nav not found.");

//            topNav.Click();
//            Console.WriteLine("Clicked on Fresh top navigation.");

//            // Wait for modal to appear
//            Thread.Sleep(3000);

//            // Handle the modal popup
//            HandleFreshModal();

//            // Wait for the Fresh sub-navigation bar to load after closing modal
//            Thread.Sleep(3000);

//            Console.WriteLine("Ready to interact with Fresh sub-navigation.");
//        }
//        catch (Exception ex)
//        {
//            throw new Exception($"Failed to click Fresh navigation: {ex.Message}");
//        }
//    }

//    // Handle Fresh modal/popup by clicking Skip button or Close button
//    private void HandleFreshModal()
//    {
//        try
//        {
//            Console.WriteLine("Checking for Fresh modal popup...");
//            Thread.Sleep(2000);

//            // Strategy 1: Try to click the X (close) button first
//            try
//            {
//                var closeButton = driver.FindElements(By.XPath(
//                    "//button[@data-action='a-popover-close'] | " +
//                    "//button[contains(@class,'a-button-close')] | " +
//                    "//button[@aria-label='Close']"
//                )).FirstOrDefault(b => b.Displayed && b.Enabled);

//                if (closeButton != null)
//                {
//                    Console.WriteLine("Modal detected. Clicking Close (X) button...");
//                    closeButton.Click();
//                    Thread.Sleep(2000);
//                    Console.WriteLine("Modal closed successfully using Close button.");
//                    return;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Close button not found: {ex.Message}");
//            }

//            // Strategy 2: Try Skip link/button
//            try
//            {
//                var skipButton = driver.FindElements(By.XPath(
//                    "//a[contains(text(),'Skip')] | " +
//                    "//input[@aria-label='Skip'] | " +
//                    "//button[contains(text(),'Skip')] | " +
//                    "//input[@value='Skip']"
//                )).FirstOrDefault(b => b.Displayed && b.Enabled);

//                if (skipButton != null)
//                {
//                    Console.WriteLine("Modal detected. Clicking Skip link...");

//                    // Scroll to element and use JavaScript click to avoid interception
//                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", skipButton);
//                    Thread.Sleep(500);
//                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", skipButton);

//                    Thread.Sleep(2000);
//                    Console.WriteLine("Modal closed successfully using Skip button.");
//                    return;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Skip button not found: {ex.Message}");
//            }

//            // Strategy 3: Press ESC key to close modal
//            try
//            {
//                Console.WriteLine("Trying to close modal with ESC key...");
//                var body = driver.FindElement(By.TagName("body"));
//                body.SendKeys(Keys.Escape);
//                Thread.Sleep(1500);
//                Console.WriteLine("ESC key pressed.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"ESC key failed: {ex.Message}");
//            }

//            Console.WriteLine("Modal handling completed.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error handling modal: {ex.Message}. Continuing anyway...");
//        }
//    }

//    // Click "Fruits & vegetables" sub category
//    public void ClickSubCategory()
//    {
//        try
//        {
//            Console.WriteLine("Looking for Fruits & vegetables link...");

//            // Wait for sub-navigation to be visible
//            Thread.Sleep(3000);

//            // Try multiple XPath variations to find the link
//            IWebElement subCat = null;

//            var xpaths = new string[]
//            {
//                "//a[contains(text(),'Fruits & vegetables')]",
//                "//a[contains(text(),'Fruits &') and contains(text(),'vegetables')]",
//                "//a[contains(@href,'fresh') and contains(text(),'Fruits')]",
//                "//div[contains(@class,'nav')]//a[contains(text(),'Fruits')]",
//                "//a[normalize-space()='Fruits & vegetables']"
//            };

//            foreach (var xpath in xpaths)
//            {
//                try
//                {
//                    var elements = driver.FindElements(By.XPath(xpath));
//                    var visibleElement = elements.FirstOrDefault(e => e.Displayed && e.Enabled);
//                    if (visibleElement != null)
//                    {
//                        Console.WriteLine($"Found element using XPath: {xpath}");
//                        subCat = visibleElement;
//                        break;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"XPath '{xpath}' failed: {ex.Message}");
//                }
//            }

//            if (subCat == null)
//            {
//                // Print current URL for debugging
//                Console.WriteLine($"Current URL: {driver.Url}");

//                // Print all visible links for debugging
//                var allLinks = driver.FindElements(By.TagName("a"));
//                Console.WriteLine($"Total links found: {allLinks.Count}");
//                Console.WriteLine("Visible links containing 'Fruit':");
//                foreach (var link in allLinks.Where(l => l.Displayed && l.Text.Contains("Fruit", StringComparison.OrdinalIgnoreCase)))
//                {
//                    Console.WriteLine($"  - Text: '{link.Text}', Href: {link.GetAttribute("href")}");
//                }

//                throw new Exception("Fruits & Vegetables subcategory not found under Fresh.");
//            }

//            // Scroll into view if needed
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", subCat);
//            Thread.Sleep(1000);

//            Console.WriteLine($"Clicking on: {subCat.Text}");
//            subCat.Click();
//            Console.WriteLine("Navigated to Fruits & vegetables category.");

//            // Wait for page to load
//            Thread.Sleep(3000);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception($"Failed to click Fruits & vegetables: {ex.Message}");
//        }
//    }

//    // Select "Featured" tab (default landing)
//    public void ClickFeaturedTab()
//    {
//        try
//        {
//            Console.WriteLine("Looking for Featured tab...");
//            Thread.Sleep(2000);

//            // Check if Featured tab exists and click it
//            var featuredTabs = driver.FindElements(By.XPath(
//                "//a[contains(text(),'Featured') or contains(@class,'featured')]"
//            ));

//            var visibleTab = featuredTabs.FirstOrDefault(t => t.Displayed && t.Enabled);

//            if (visibleTab != null)
//            {
//                Console.WriteLine($"Found Featured tab: {visibleTab.Text}");
//                visibleTab.Click();
//                Thread.Sleep(2000);
//                Console.WriteLine("Clicked on Featured tab.");
//            }
//            else
//            {
//                Console.WriteLine("Featured tab not found - likely already selected by default.");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Featured tab note: {ex.Message} - Continuing as Featured is usually default.");
//        }
//    }

//    // Add first product from featured list to cart
//    public void AddFirstProductToCart()
//    {
//        try
//        {
//            Console.WriteLine("Looking for products on the page...");
//            Thread.Sleep(3000);

//            // Scroll down to load products
//            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
//            Thread.Sleep(2000);

//            Console.WriteLine($"Current URL: {driver.Url}");

//            // Find all product links - using multiple strategies
//            var products = driver.FindElements(By.XPath(
//                "//div[@data-component-type='s-search-result']//h2//a | " +
//                "//div[contains(@class,'s-result-item')]//h2//a"
//            ));

//            Console.WriteLine($"Total product links found: {products.Count}");

//            // Filter for visible products
//            var visibleProducts = products.Where(p => p.Displayed && !string.IsNullOrWhiteSpace(p.Text)).ToList();
//            Console.WriteLine($"Visible products: {visibleProducts.Count}");

//            if (visibleProducts.Count == 0)
//            {
//                // Try alternative approach - look for product cards
//                Console.WriteLine("Trying alternative product locator...");
//                products = driver.FindElements(By.XPath(
//                    "//div[@data-component-type='s-search-result']//a[contains(@class,'s-link')]"
//                ));
//                visibleProducts = products.Where(p => p.Displayed).ToList();
//                Console.WriteLine($"Alternative approach found: {visibleProducts.Count} products");
//            }

//            if (visibleProducts.Count == 0)
//            {
//                // List all divs with search results for debugging
//                var searchResults = driver.FindElements(By.XPath("//div[@data-component-type='s-search-result']"));
//                Console.WriteLine($"Search result divs found: {searchResults.Count}");

//                throw new Exception("No products found on category page. Page may not have loaded properly.");
//            }

//            var firstProduct = visibleProducts.First();
//            string productName = firstProduct.Text;
//            Console.WriteLine($"Found first product: {productName}");

//            // Scroll to product
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", firstProduct);
//            Thread.Sleep(1000);

//            // Click the product using JavaScript for reliability
//            Console.WriteLine("Clicking on the product...");
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", firstProduct);

//            Console.WriteLine("Product clicked. Waiting for product page to load...");
//            Thread.Sleep(5000);

//            Console.WriteLine($"Product page URL: {driver.Url}");

//            // Wait for page to stabilize
//            Thread.Sleep(2000);

//            // Find Add to Cart button
//            IWebElement addToCartButton = null;

//            Console.WriteLine("Looking for Add to Cart button...");

//            // Try multiple times to find the button
//            for (int attempt = 1; attempt <= 3; attempt++)
//            {
//                Console.WriteLine($"Attempt {attempt} to find Add to Cart button...");

//                try
//                {
//                    addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
//                    if (addToCartButton != null && addToCartButton.Displayed)
//                    {
//                        Console.WriteLine("Found Add to Cart button!");
//                        break;
//                    }
//                }
//                catch
//                {
//                    Console.WriteLine($"Add to Cart button not found in attempt {attempt}");
//                }

//                if (attempt < 3)
//                {
//                    Thread.Sleep(2000);
//                }
//            }

//            if (addToCartButton == null)
//            {
//                // Check for alternative buttons
//                Console.WriteLine("Checking for alternative cart buttons...");

//                var alternativeButtons = driver.FindElements(By.XPath(
//                    "//input[@name='submit.add-to-cart'] | " +
//                    "//input[contains(@id,'add-to-cart')] | " +
//                    "//span[@id='submit.add-to-cart']//input"
//                ));

//                addToCartButton = alternativeButtons.FirstOrDefault(b => b.Displayed);

//                if (addToCartButton != null)
//                {
//                    Console.WriteLine("Found alternative Add to Cart button!");
//                }
//            }

//            if (addToCartButton == null)
//            {
//                // Check if Buy Now exists (means add to cart should exist too)
//                var buyNow = driver.FindElements(By.Id("buy-now-button")).FirstOrDefault();
//                if (buyNow != null)
//                {
//                    Console.WriteLine("Buy Now button found, but Add to Cart not found.");
//                }

//                throw new Exception("Add to Cart button not found. Product may require variant selection or page not loaded properly.");
//            }

//            // Scroll to button
//            Console.WriteLine("Scrolling to Add to Cart button...");
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", addToCartButton);
//            Thread.Sleep(1000);

//            // Click Add to Cart using JavaScript for reliability
//            Console.WriteLine("Clicking Add to Cart button...");
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", addToCartButton);

//            Thread.Sleep(3000);
//            Console.WriteLine("✓ Product added to cart successfully!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"ERROR in AddFirstProductToCart: {ex.Message}");
//            Console.WriteLine($"Current URL at error: {driver.Url}");
//            throw new Exception($"Failed to add product to cart: {ex.Message}");
//        }
//    }
//}

using Amazon_Application.Utilities;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

public class CategoryPage
{
    private IWebDriver driver;

    public CategoryPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Click "Fresh" top nav
    public void ClickTopNav()
    {
        try
        {
            var topNav = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("FreshNavLink"), 10);
            if (topNav == null)
                throw new Exception("Fresh top nav not found.");
            
            topNav.Click();
            Console.WriteLine("Clicked on Fresh top navigation.");
            
            // Wait for modal to appear
            Thread.Sleep(3000);
            
            // Handle the modal popup
            HandleFreshModal();
            
            // Wait for the Fresh sub-navigation bar to load after closing modal
            Thread.Sleep(3000);
            
            Console.WriteLine("Ready to interact with Fresh sub-navigation.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to click Fresh navigation: {ex.Message}");
        }
    }

    // Handle Fresh modal/popup by clicking Skip button or Close button
    private void HandleFreshModal()
    {
        try
        {
            Console.WriteLine("Checking for Fresh modal popup...");
            Thread.Sleep(2000);
            
            // Strategy 1: Try to click the X (close) button first
            try
            {
                var closeButton = driver.FindElements(By.XPath(
                    "//button[@data-action='a-popover-close'] | " +
                    "//button[contains(@class,'a-button-close')] | " +
                    "//button[@aria-label='Close']"
                )).FirstOrDefault(b => b.Displayed && b.Enabled);

                if (closeButton != null)
                {
                    Console.WriteLine("Modal detected. Clicking Close (X) button...");
                    closeButton.Click();
                    Thread.Sleep(2000);
                    Console.WriteLine("Modal closed successfully using Close button.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Close button not found: {ex.Message}");
            }

            // Strategy 2: Try Skip link/button
            try
            {
                var skipButton = driver.FindElements(By.XPath(
                    "//a[contains(text(),'Skip')] | " +
                    "//input[@aria-label='Skip'] | " +
                    "//button[contains(text(),'Skip')] | " +
                    "//input[@value='Skip']"
                )).FirstOrDefault(b => b.Displayed && b.Enabled);

                if (skipButton != null)
                {
                    Console.WriteLine("Modal detected. Clicking Skip link...");
                    
                    // Scroll to element and use JavaScript click to avoid interception
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", skipButton);
                    Thread.Sleep(500);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", skipButton);
                    
                    Thread.Sleep(2000);
                    Console.WriteLine("Modal closed successfully using Skip button.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Skip button not found: {ex.Message}");
            }

            // Strategy 3: Press ESC key to close modal
            try
            {
                Console.WriteLine("Trying to close modal with ESC key...");
                var body = driver.FindElement(By.TagName("body"));
                body.SendKeys(Keys.Escape);
                Thread.Sleep(1500);
                Console.WriteLine("ESC key pressed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ESC key failed: {ex.Message}");
            }

            Console.WriteLine("Modal handling completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling modal: {ex.Message}. Continuing anyway...");
        }
    }

    // Click "Fruits & vegetables" sub category
    public void ClickSubCategory()
    {
        try
        {
            Console.WriteLine("Looking for Fruits & vegetables link...");
            
            // Wait for sub-navigation to be visible
            Thread.Sleep(3000);
            
            // Try multiple XPath variations to find the link
            IWebElement subCat = null;
            
            var xpaths = new string[]
            {
                "//a[contains(text(),'Fruits & vegetables')]",
                "//a[contains(text(),'Fruits &') and contains(text(),'vegetables')]",
                "//a[contains(@href,'fresh') and contains(text(),'Fruits')]",
                "//div[contains(@class,'nav')]//a[contains(text(),'Fruits')]",
                "//a[normalize-space()='Fruits & vegetables']"
            };

            foreach (var xpath in xpaths)
            {
                try
                {
                    var elements = driver.FindElements(By.XPath(xpath));
                    var visibleElement = elements.FirstOrDefault(e => e.Displayed && e.Enabled);
                    if (visibleElement != null)
                    {
                        Console.WriteLine($"Found element using XPath: {xpath}");
                        subCat = visibleElement;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"XPath '{xpath}' failed: {ex.Message}");
                }
            }

            if (subCat == null)
            {
                // Print current URL for debugging
                Console.WriteLine($"Current URL: {driver.Url}");
                
                // Print all visible links for debugging
                var allLinks = driver.FindElements(By.TagName("a"));
                Console.WriteLine($"Total links found: {allLinks.Count}");
                Console.WriteLine("Visible links containing 'Fruit':");
                foreach (var link in allLinks.Where(l => l.Displayed && l.Text.Contains("Fruit", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"  - Text: '{link.Text}', Href: {link.GetAttribute("href")}");
                }
                
                throw new Exception("Fruits & Vegetables subcategory not found under Fresh.");
            }
            
            // Scroll into view if needed
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", subCat);
            Thread.Sleep(1000);
            
            Console.WriteLine($"Clicking on: {subCat.Text}");
            subCat.Click();
            Console.WriteLine("Navigated to Fruits & vegetables category.");
            
            // Wait for page to load
            Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to click Fruits & vegetables: {ex.Message}");
        }
    }

    // Select "Featured" tab (default landing)
    public void ClickFeaturedTab()
    {
        try
        {
            Console.WriteLine("Looking for Featured tab...");
            Thread.Sleep(2000);
            
            // Check if Featured tab exists and click it
            var featuredTabs = driver.FindElements(By.XPath(
                "//a[contains(text(),'Featured') or contains(@class,'featured')]"
            ));

            var visibleTab = featuredTabs.FirstOrDefault(t => t.Displayed && t.Enabled);

            if (visibleTab != null)
            {
                Console.WriteLine($"Found Featured tab: {visibleTab.Text}");
                visibleTab.Click();
                Thread.Sleep(2000);
                Console.WriteLine("Clicked on Featured tab.");
            }
            else
            {
                Console.WriteLine("Featured tab not found - likely already selected by default.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Featured tab note: {ex.Message} - Continuing as Featured is usually default.");
        }
    }

    // Add first product from featured list to cart
    //public void AddFirstProductToCart()
    //{
    //    try
    //    {
    //        Console.WriteLine("Looking for products on the page...");
    //        Thread.Sleep(4000);

    //        Console.WriteLine($"Current URL: {driver.Url}");

    //        // Scroll down to load products (important for lazy loading)
    //        Console.WriteLine("Scrolling to load products...");
    //        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 800);");
    //        Thread.Sleep(2000);
    //        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 1200);");
    //        Thread.Sleep(2000);

    //        // Try multiple product locator strategies for Amazon Fresh pages
    //        IWebElement firstProduct = null;

    //        // Strategy 1: Standard Amazon product cards
    //        Console.WriteLine("Strategy 1: Looking for standard product cards...");
    //        var products = driver.FindElements(By.XPath(
    //            "//div[@data-component-type='s-search-result']//h2//a | " +
    //            "//div[contains(@class,'s-result-item')]//h2//a"
    //        ));
    //        Console.WriteLine($"Standard products found: {products.Count}");
    //        firstProduct = products.FirstOrDefault(p => p.Displayed && !string.IsNullOrWhiteSpace(p.Text));

    //        // Strategy 2: Fresh category specific products
    //        if (firstProduct == null)
    //        {
    //            Console.WriteLine("Strategy 2: Looking for Fresh category products...");
    //            products = driver.FindElements(By.XPath(
    //                "//div[contains(@class,'ProductCard')]//a | " +
    //                "//div[contains(@class,'product-card')]//a | " +
    //                "//a[contains(@class,'product-link')] | " +
    //                "//div[contains(@class,'product')]//a[contains(@href,'/dp/')]"
    //            ));
    //            Console.WriteLine($"Fresh products found: {products.Count}");
    //            firstProduct = products.FirstOrDefault(p => p.Displayed);
    //        }

    //        // Strategy 3: Look for any product image links
    //        if (firstProduct == null)
    //        {
    //            Console.WriteLine("Strategy 3: Looking for product images...");
    //            products = driver.FindElements(By.XPath(
    //                "//img[@data-image-latency='s-product-image']//ancestor::a | " +
    //                "//img[contains(@class,'product')]//ancestor::a"
    //            ));
    //            Console.WriteLine($"Image-based products found: {products.Count}");
    //            firstProduct = products.FirstOrDefault(p => p.Displayed);
    //        }

    //        // Strategy 4: Look for any links with /dp/ (product detail page)
    //        if (firstProduct == null)
    //        {
    //            Console.WriteLine("Strategy 4: Looking for any product detail links...");
    //            products = driver.FindElements(By.XPath("//a[contains(@href,'/dp/')]"));
    //            Console.WriteLine($"Product detail links found: {products.Count}");

    //            // Filter out non-product links
    //            var productLinks = products.Where(p => 
    //                p.Displayed && 
    //                !p.GetAttribute("href").Contains("/ref=") &&
    //                !p.GetAttribute("href").Contains("/gp/")
    //            ).ToList();
    //            Console.WriteLine($"Filtered product links: {productLinks.Count}");
    //            firstProduct = productLinks.FirstOrDefault();
    //        }

    //        // Strategy 5: Look for fresh-specific containers
    //        if (firstProduct == null)
    //        {
    //            Console.WriteLine("Strategy 5: Looking for fresh containers...");
    //            products = driver.FindElements(By.XPath(
    //                "//div[contains(@class,'fresh')]//a[contains(@href,'amazon.in')] | " +
    //                "//article//a | " +
    //                "//div[@role='group']//a"
    //            ));
    //            Console.WriteLine($"Fresh container links found: {products.Count}");
    //            firstProduct = products.FirstOrDefault(p => p.Displayed && p.GetAttribute("href").Contains("/dp/"));
    //        }

    //        if (firstProduct == null)
    //        {
    //            // Debug: Print page source length and check for common elements
    //            Console.WriteLine($"Page source length: {driver.PageSource.Length}");

    //            // Check if page has any images
    //            var allImages = driver.FindElements(By.TagName("img"));
    //            Console.WriteLine($"Total images on page: {allImages.Count}");

    //            // Check all links
    //            var allLinks = driver.FindElements(By.TagName("a"));
    //            Console.WriteLine($"Total links on page: {allLinks.Count}");

    //            // Print some visible links for debugging
    //            Console.WriteLine("Sample visible links:");
    //            foreach (var link in allLinks.Take(10).Where(l => l.Displayed))
    //            {
    //                Console.WriteLine($"  - Text: '{link.Text}', Href: {link.GetAttribute("href")}");
    //            }

    //            throw new Exception("No products found on category page. Page may not have loaded properly or products require different locators.");
    //        }

    //        // Get product info
    //        string productHref = firstProduct.GetAttribute("href");
    //        string productText = firstProduct.Text;
    //        Console.WriteLine($"Found first product - Text: '{productText}', Href: {productHref}");

    //        // Scroll to product
    //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", firstProduct);
    //        Thread.Sleep(1500);

    //        // Click the product using JavaScript for reliability
    //        Console.WriteLine("Clicking on the product...");
    //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", firstProduct);

    //        Console.WriteLine("Product clicked. Waiting for product page to load...");
    //        Thread.Sleep(6000);

    //        Console.WriteLine($"Product page URL: {driver.Url}");

    //        // Wait for page to stabilize
    //        Thread.Sleep(2000);

    //        // Find Add to Cart button
    //        IWebElement addToCartButton = null;

    //        Console.WriteLine("Looking for Add to Cart button...");

    //        // Try multiple times to find the button
    //        for (int attempt = 1; attempt <= 5; attempt++)
    //        {
    //            Console.WriteLine($"Attempt {attempt} to find Add to Cart button...");

    //            try
    //            {
    //                // Try ID first
    //                addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
    //                if (addToCartButton != null && addToCartButton.Displayed)
    //                {
    //                    Console.WriteLine("Found Add to Cart button by ID!");
    //                    break;
    //                }
    //            }
    //            catch { }

    //            try
    //            {
    //                // Try name attribute
    //                addToCartButton = driver.FindElement(By.Name("submit.add-to-cart"));
    //                if (addToCartButton != null && addToCartButton.Displayed)
    //                {
    //                    Console.WriteLine("Found Add to Cart button by name!");
    //                    break;
    //                }
    //            }
    //            catch { }

    //            try
    //            {
    //                // Try XPath
    //                var buttons = driver.FindElements(By.XPath(
    //                    "//input[@id='add-to-cart-button'] | " +
    //                    "//input[contains(@name,'add-to-cart')] | " +
    //                    "//button[@id='add-to-cart-button'] | " +
    //                    "//span[@id='submit.add-to-cart']//input"
    //                ));
    //                addToCartButton = buttons.FirstOrDefault(b => b.Displayed);
    //                if (addToCartButton != null)
    //                {
    //                    Console.WriteLine("Found Add to Cart button by XPath!");
    //                    break;
    //                }
    //            }
    //            catch { }

    //            if (attempt < 5)
    //            {
    //                Console.WriteLine($"Button not found in attempt {attempt}, waiting...");
    //                Thread.Sleep(2000);
    //            }
    //        }

    //        if (addToCartButton == null)
    //        {
    //            // Check for alternative buttons or requirements
    //            Console.WriteLine("Checking page for clues...");

    //            var buyNow = driver.FindElements(By.Id("buy-now-button")).FirstOrDefault();
    //            if (buyNow != null && buyNow.Displayed)
    //            {
    //                Console.WriteLine("Buy Now button found - Add to Cart should be nearby.");
    //            }

    //            // Check for variant selection requirement
    //            var dropdowns = driver.FindElements(By.XPath("//select[contains(@name,'dropdown')]"));
    //            if (dropdowns.Count > 0)
    //            {
    //                Console.WriteLine($"Found {dropdowns.Count} dropdown(s) - product may require variant selection.");
    //            }

    //            throw new Exception("Add to Cart button not found after 5 attempts. Product may require variant selection or page not loaded properly.");
    //        }

    //        // Scroll to button
    //        Console.WriteLine("Scrolling to Add to Cart button...");
    //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", addToCartButton);
    //        Thread.Sleep(1000);

    //        // Click Add to Cart using JavaScript for reliability
    //        Console.WriteLine("Clicking Add to Cart button...");
    //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", addToCartButton);

    //        Thread.Sleep(3000);
    //        Console.WriteLine("✓ Product added to cart successfully!");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"ERROR in AddFirstProductToCart: {ex.Message}");
    //        Console.WriteLine($"Current URL at error: {driver.Url}");
    //        throw new Exception($"Failed to add product to cart: {ex.Message}");
    //    }
    //}

    public void AddFirstProductToCart()
    {
        try
        {
            Console.WriteLine("Looking for products on the page...");
            Thread.Sleep(4000);

            // Scroll to load products
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 2000);");
            Thread.Sleep(2000);

            // Find first product link
            var productLinks = driver.FindElements(By.XPath("//a[contains(@href,'/dp/')]"))
                                     .Where(p => p.Displayed).ToList();
            if (!productLinks.Any())
                throw new Exception("No products found on category page.");

            var firstProduct = productLinks.First();
            Console.WriteLine($"Clicking first product: {firstProduct.GetAttribute("href")}");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", firstProduct);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", firstProduct);

            // Wait for product page to load
            Thread.Sleep(6000);

            // --- Handle variant selection if required ---
            var variantSelectors = driver.FindElements(By.XPath(
                "//select[contains(@id,'dropdown') or contains(@name,'dropdown')]" // dropdowns
            )).Where(s => s.Displayed).ToList();

            foreach (var select in variantSelectors)
            {
                var options = select.FindElements(By.TagName("option"))
                                    .Where(o => !string.IsNullOrEmpty(o.Text) && !o.GetAttribute("disabled").Equals("true"))
                                    .ToList();
                if (options.Any())
                {
                    Console.WriteLine($"Selecting variant: {options[0].Text}");
                    options[0].Click();
                    Thread.Sleep(1500);
                }
            }

            // --- Also handle radio button variants (like weight/pack) ---
            var radioOptions = driver.FindElements(By.XPath("//input[@type='radio' and not(@disabled)]"))
                                     .Where(r => r.Displayed).ToList();
            if (radioOptions.Any())
            {
                Console.WriteLine($"Selecting first radio variant...");
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", radioOptions[0]);
                Thread.Sleep(1500);
            }

            // --- Wait for Add to Cart button to be enabled ---
            IWebElement addToCartButton = null;
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            addToCartButton = wait.Until(drv =>
            {
                var btn = drv.FindElements(By.Id("add-to-cart-button"))
                             .FirstOrDefault(b => b.Displayed && b.Enabled);
                return btn ?? drv.FindElements(By.XPath("//input[contains(@id,'add-to-cart') or contains(@name,'add-to-cart')]"))
                                 .FirstOrDefault(b => b.Displayed && b.Enabled);
            });

            if (addToCartButton == null)
                throw new Exception("Add to Cart button not found or still disabled. Product may require more variant selections.");

            // Scroll and click
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCartButton);
            Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", addToCartButton);

            Thread.Sleep(3000);
            Console.WriteLine("✓ Product added to cart successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR in AddFirstProductToCart: {ex.Message}");
            Console.WriteLine($"Current URL: {driver.Url}");
            throw new Exception($"Failed to add product to cart: {ex.Message}");
        }
    }



}