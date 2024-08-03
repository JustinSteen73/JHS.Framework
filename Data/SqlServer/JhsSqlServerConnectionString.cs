using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JHS.Framework.Data.SqlServer
{


    public class JhsSqlServerConnectionString
    {


        #region Constructors

        public JhsSqlServerConnectionString()
        {
        }

        public JhsSqlServerConnectionString(string strConnectionString)
        {
            Parse(strConnectionString);
        }

        #endregion


        #region Properties

        private long connectTimeout;
        public long ConnectTimeout
        {
            get
            {
                return this.connectTimeout;
            }
            set
            {
                this.connectTimeout = value;
            }
        }

        private string database;
        public string Database
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }

        private bool? persistSecurityInfo;
        public bool? PersistSecurityInfo
        {
            get
            {
                return this.persistSecurityInfo;
            }
            set
            {
                this.persistSecurityInfo = value;
            }
        }

        private bool? integratedSecurity;
        public bool? IntegratedSecurity
        {
            get
            {
                return this.integratedSecurity;
            }
            set
            {
                this.integratedSecurity = value;
            }
        }

        private string server;
        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }

        #endregion


        public override string ToString()
        {

            System.Collections.ArrayList connectionStringValueList = new System.Collections.ArrayList();

            // --- Build Connection String ---

            if (Server != "")
                connectionStringValueList.Add("server=" + Server);

            if (Database != "")
                connectionStringValueList.Add("database=" + Database);

            if (this.integratedSecurity != null)
                connectionStringValueList.Add("Integrated Security=" + this.integratedSecurity.ToString());

            if (persistSecurityInfo != null)
                connectionStringValueList.Add("Persist Security Info=" + persistSecurityInfo.ToString());

            if (ConnectTimeout != 0)
                connectionStringValueList.Add("Connect Timeout=" + ConnectTimeout);

            // --- End Build Connection String ---

            if (connectionStringValueList.Count > 0)
            {
                string[] connectionStringValues = (string[])connectionStringValueList.ToArray(typeof(string));
                return string.Join(";", connectionStringValues);
            }
            else
                return string.Empty;
        }


        public void Parse(string connectionString)
        {
            string[] namesAndValues;
            string[] astrPart;

            namesAndValues = connectionString.Split(';');

            foreach (string nameAndValue in namesAndValues)
            {
                astrPart = nameAndValue.Split('=');
                switch (astrPart[0].ToLower())
                {
                    case "server":
                        {
                            this.Server = astrPart[1];
                            break;
                        }

                    case "database":
                        {
                            this.Database = astrPart[1];
                            break;
                        }
                }
            }

        }


    }   // end class JhsSqlServerConnectionString


}   // end namespace JHS.Framework.Data.SqlServer

