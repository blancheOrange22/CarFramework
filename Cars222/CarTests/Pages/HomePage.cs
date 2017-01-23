using CarTests.Menus;
using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class HomePage : BasePage
    {
        public readonly Menu menu = new Menu();

        public void GoToCarCatalogue(string menuItem, string subMenuItem)
        {
            menu.OpenItem(menuItem, subMenuItem);
        }
    }
}
