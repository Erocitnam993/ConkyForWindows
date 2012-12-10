using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Timers;
using WUApiLib;
using System.Management;
using Microsoft.Win32;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WeatherRSS
{
    class Weather
    {
        private Winky.Window1 userLocation;
        public string location = "";
        public string CurrentConditions()
        {
            userLocation = new Winky.Window1();
            string weather = "";
            //location = userLocation.location;

            // http://weather.yahooapis.com/forecastrss?w=2464601
            
            // conditions
            // Create a new XmlDocument  
            XmlDocument condition = new XmlDocument();

            // Load data  
            condition.Load(location);

            // Set up namespace manager for XPath  
            XmlNamespaceManager NameSpaceMgrCondition = new XmlNamespaceManager(condition.NameTable);
            NameSpaceMgrCondition.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodes = condition.SelectNodes("/rss/channel/item/yweather:condition", NameSpaceMgrCondition);

            // To get forcasted high
            string temps = forcastTemps();

            foreach (XmlNode node in nodes)
            {
                
                weather = ("Currently: " +
                                    node.Attributes["text"].InnerText + "\n" +
                                    "Now: " +
                                    node.Attributes["temp"].InnerText + "\n" +
                                    "High: " +
                                    temps + "\n" + 
                                    "Last Updated: " +
                                    node.Attributes["date"].InnerText);

            }

           
            return weather;
        }

        private string forcastTemps()
        {
            string weather = "";

            // forcast
            // Create a new XmlDocument  
            XmlDocument docc = new XmlDocument();

            // Load data  
            docc.Load(location);

            // Set up namespace manager for XPath  
            XmlNamespaceManager forcastNameSpaceMgr = new XmlNamespaceManager(docc.NameTable);
            forcastNameSpaceMgr.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodess = docc.SelectNodes("/rss/channel/item/yweather:forecast", forcastNameSpaceMgr);
            int i = 0;
            foreach (XmlNode node in nodess)
            {
                if (i == 0)
                    weather = node.Attributes["high"].InnerText + "\nLow: " + node.Attributes["low"].InnerText;
                i++;
            }
            return weather;
        }

        public string Forcast()
        {
            string weather = "";

            // forcast
            // Create a new XmlDocument  
            XmlDocument docc = new XmlDocument();

            // Load data  
            docc.Load(location);

            // Set up namespace manager for XPath  
            XmlNamespaceManager forcastNameSpaceMgr = new XmlNamespaceManager(docc.NameTable);
            forcastNameSpaceMgr.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodess = docc.SelectNodes("/rss/channel/item/yweather:forecast", forcastNameSpaceMgr);

            // You can also get elements based on their tag name and namespace,  
            // though this isn't recommended  
            //XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
            //                          "http://xml.weather.yahoo.com/ns/rss/1.0");  
            weather += "\nForcast";
            foreach (XmlNode node in nodess)
            {
                weather += ("\n" +
                                    node.Attributes["day"].InnerText + "\n" +
                                    "The Condition will be " +
                                    node.Attributes["text"].InnerText + "\n" +
                                    "High: " +
                                    node.Attributes["high"].InnerText + "\n" +
                                    "Low: " +
                                    node.Attributes["low"].InnerText);
            }
            return weather;
        }

        public string getImage()
        {
            // forcast
            // Create a new XmlDocument  
            XmlDocument doc = new XmlDocument();

            // Load data  
            doc.Load(location);

            // Set up namespace manager for XPath  
            XmlNamespaceManager ImageNameSpaceMgr = new XmlNamespaceManager(doc.NameTable);
            ImageNameSpaceMgr.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodess = doc.SelectNodes("/rss/channel/item/description", ImageNameSpaceMgr);


            string xml = nodess[0].InnerXml;
            string desiredValue = Regex.Replace(xml
                                           .Replace("<br />", "\n")
                                           .Trim(),
                    @"\<br />", "\n");
            desiredValue = Regex.Replace(desiredValue
                                           .Replace("<br />", "\n")
                                           .Trim(),
                    @"\<BR />", "\n");

            desiredValue = desiredValue.Remove(57);
            desiredValue = desiredValue.Remove(0, 20);

            return desiredValue;
        }
    }
}