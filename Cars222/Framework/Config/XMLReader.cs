using System;
using System.Xml;

namespace Framework.Config
{
    public class XMLReader
    {
        public string browser, temp;
        public double timeWait;

        public XMLReader()
        {
            XmlDocument mydata = new XmlDocument();
            mydata.Load("..\\..\\..\\Framework\\Config\\mydata.xml");

            XmlNode nBrowser = mydata.SelectSingleNode("//browser");
            browser = nBrowser.InnerText;

            XmlNode nTimeWait = mydata.SelectSingleNode("//timeWait");
            temp = nTimeWait.InnerText;
            timeWait = Convert.ToDouble(temp);
        }
    }
}
