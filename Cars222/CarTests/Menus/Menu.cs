using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Menus
{
    public class Menu
    {
        private readonly string tmpMenuItemXpath = "//span[contains(., '{0}')]/following-sibling::span//cui-icon[contains(@name, 'chevron')]";
        private readonly string tmpSubMenuItemXPath = "//ul[contains(@class, 'submenu-column')]//a[contains(., '{0}')]";

        /// <summary>
        ///
        /// </summary>
        /// <param name="menuItem">Buy</param>
        /// <param name="subMenuItem">Review a Car</param>

        public void OpenItem(string menuItem, string subMenuItem)
        {
            Element menuItemLnk = new Element(By.XPath(string.Format(tmpMenuItemXpath, menuItem)), menuItem);
            menuItemLnk.Click();

            Element subMenuItemLnk = new Element(By.XPath(string.Format(tmpSubMenuItemXPath, subMenuItem)), subMenuItem);
            subMenuItemLnk.Click();
        }
    }
}
