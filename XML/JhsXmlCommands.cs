using System;
using System.Collections.Generic;

using System.IO;                    // Required for StringWriter
using System.Xml;                   // Required for XmlWriter
using System.Xml.Serialization;     // Required for XmlSerializer


namespace JHS.Framework.XML
{


    public static class JhsXmlCommands
    {


        public static string CompareXmlFiles(string xmlFilePath1, string xmlFilePath2, string[] ignoreXmlNodeNames = null)
        {

            System.Text.StringBuilder differences = new System.Text.StringBuilder();

            // Load xml doc 1
            System.Xml.XmlDocument xmlDoc1 = new System.Xml.XmlDocument();
            xmlDoc1.Load(xmlFilePath1);

            // Load xml doc 2
            System.Xml.XmlDocument xmlDoc2 = new System.Xml.XmlDocument();
            xmlDoc2.Load(xmlFilePath2);

            string diff = CompareXml(xmlDoc1.DocumentElement, xmlDoc2.DocumentElement, ignoreXmlNodeNames);
            if (!String.IsNullOrWhiteSpace(diff))
                differences.AppendLine(diff);

            //for (int xmlNodeIndex = 0; xmlNodeIndex < xmlDoc1.DocumentElement.ChildNodes.Count; xmlNodeIndex++)
            //{

            //    string xmlNodeName1 = xmlDoc1.DocumentElement.ChildNodes[xmlNodeIndex].Name;
            //    string xmlNodeName2 = xmlDoc2.DocumentElement.ChildNodes[xmlNodeIndex].Name;

            //    // Compare children first
            //    bool xmlNode1HasChildren = xmlDoc1.DocumentElement.ChildNodes[xmlNodeIndex].HasChildNodes && (xmlDoc1.DocumentElement.ChildNodes[xmlNodeIndex].ChildNodes.Count > 1);
            //    bool xmlNode2HasChildren = xmlDoc2.DocumentElement.ChildNodes[xmlNodeIndex].HasChildNodes && (xmlDoc2.DocumentElement.ChildNodes[xmlNodeIndex].ChildNodes.Count > 1); 
            //    if (xmlNode1HasChildren && xmlNode2HasChildren)
            //    {
            //        string diff = CompareXml(xmlDoc1.DocumentElement.ChildNodes[xmlNodeIndex], xmlDoc2.DocumentElement.ChildNodes[xmlNodeIndex]);
            //    }
            //    else
            //    {
            //        string xmlNodeText1 = xmlDoc1.DocumentElement.ChildNodes[xmlNodeIndex].InnerText;
            //        string xmlNodeText2 = xmlDoc2.DocumentElement.ChildNodes[xmlNodeIndex].InnerText;
            //        if (!xmlNodeName1.Equals(xmlNodeName2))
            //        {
            //            // node names are different

            //        }
            //        else if (!xmlNodeText1.Equals(xmlNodeText2))
            //        {
            //            // node texts are different
            //            differences.AppendLine($"{xmlNodeName1} '{xmlNodeText1}' does not equal '{xmlNodeText2}'");
            //        }
            //    }
            //}

            return differences.ToString();

        }   // End CompareXmlFiles


        public static string CompareXml(System.Xml.XmlNode xmlNode1, System.Xml.XmlNode xmlNode2, string[] ignoreXmlNodeNames = null)
        {

            System.Text.StringBuilder differences = new System.Text.StringBuilder();

            string xmlNodeName1 = xmlNode1.Name;
            string xmlNodeName2 = xmlNode2.Name;

            // Check for nodes to ignore            
            if (ignoreXmlNodeNames != null)
                if (JhsInformation.InList(xmlNodeName1, ignoreXmlNodeNames) || JhsInformation.InList(xmlNodeName2, ignoreXmlNodeNames))
                    return "";

            bool xmlNode1HasChildren = xmlNode1.HasChildNodes && (xmlNode1.ChildNodes.Count > 1);
            bool xmlNode2HasChildren = xmlNode2.HasChildNodes && (xmlNode2.ChildNodes.Count > 1);
            if (xmlNode1HasChildren && xmlNode2HasChildren)
            {
                // Compare children first
                for (int xmlChildNodeIndex = 0; xmlChildNodeIndex < xmlNode1.ChildNodes.Count; xmlChildNodeIndex++)
                {
                    string diff = CompareXml(xmlNode1.ChildNodes[xmlChildNodeIndex], xmlNode2.ChildNodes[xmlChildNodeIndex], ignoreXmlNodeNames);
                    if (!String.IsNullOrWhiteSpace(diff))
                        differences.AppendLine(diff);
                }
            }
            else
            {                
                string xmlNodeText1 = xmlNode1.InnerText;
                string xmlNodeText2 = xmlNode2.InnerText;
                if (!xmlNodeName1.Equals(xmlNodeName2))
                {
                    // node names are different

                }
                else if (!xmlNodeText1.Equals(xmlNodeText2))
                {
                    // node texts are different
                    differences.AppendLine($"{xmlNodeName1} '{xmlNodeText1}' does not equal '{xmlNodeText2}'");
                }
            }

            return differences.ToString();

        }   // End CompareXml


        // Source: http://stackoverflow.com/questions/4123590/serialize-an-object-to-xml
        public static string Serialize<T>(T serializeThis)
        {

            string serializeXml = string.Empty;

            if (serializeThis != null)
            {

                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, serializeThis);
                    serializeXml = stringWriter.ToString();
                }

            }

            return serializeXml;

        }


        // Source: http://stackoverflow.com/questions/226599/deserializing-xml-to-objects-in-c-sharp
        public static T Deserialize<T>(string serializedText)
        {
            T obj = default(T);
            if (serializedText != string.Empty)
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(serializedText))
                    obj = (T)xmlserializer.Deserialize(stringReader);
            }
            return obj;
        }




    }   // end class JhsXmlCommands


}
