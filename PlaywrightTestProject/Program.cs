using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTestProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();

            // Launch a browser (Chromium in this case)
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true if you want to run in headless mode
            });

            // Create a new browser context
            var context = await browser.NewContextAsync();

            // Create a new page
            var page = await context.NewPageAsync();

            // Navigate to the Taxually application
            await page.GotoAsync("https://app.taxually.com/");

            // Fill out the email address
            await page.FillAsync("input[name='Email Address']", "sandorkovacs122@gmail.com");

            // Fill out the password
            await page.FillAsync("input[name='Password']", "Sa123456!");

            // Click the "Sign in" button
            await page.ClickAsync("button:has-text('Sign in')");

            // Optional: Wait for a while to see the result before closing the browser
            await page.WaitForTimeoutAsync(5000);

            // Close the browser
            await browser.CloseAsync();
        }
    }
}
