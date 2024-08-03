using System.Xml.Linq;


namespace JHS.Framework.SoftwareIntegration.MicrosoftHealthVault
{

    public static class JhsHealthVaultNonApiXmlCommands
    {

        public static System.DateTime? HealthVaultXmlToDate(XElement dateElement)
        {
            if (dateElement == null) return null;
            int year = System.Convert.ToInt32(dateElement.Element("structured").Element("date").Element("y").Value);
            int month = System.Convert.ToInt32(dateElement.Element("structured").Element("date").Element("m").Value);
            int day = System.Convert.ToInt32(dateElement.Element("structured").Element("date").Element("d").Value);
            System.DateTime date = new System.DateTime(year, month, day);
            return date;
        }

        public static System.DateTime? HealthVaultXmlToDateTime(XElement dateTimeElement)
        {
            if (dateTimeElement == null) return null;
            XElement dateElement = dateTimeElement.Element("structured").Element("date");
            int year = System.Convert.ToInt32(dateElement.Element("y").Value);
            int month = System.Convert.ToInt32(dateElement.Element("m").Value);
            int day = System.Convert.ToInt32(dateElement.Element("d").Value);
            XElement timeElement = dateTimeElement.Element("structured").Element("time");
            if (timeElement == null)
            {
                System.DateTime date = new System.DateTime(year, month, day);
                return date;
            }
            else
            {
                int hour = System.Convert.ToInt32(timeElement.Element("h").Value);
                int minute = System.Convert.ToInt32(timeElement.Element("m").Value);
                System.DateTime dateTime = new System.DateTime(year, month, day, hour, minute, 0);
                return dateTime;
            }
        }


    }   // end class JhsHealthVaultNonApiXmlCommands

}
