using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Configuration
{
    public abstract class JhsConfigurationFactory
    {
        public abstract void Init();

        private static JhsConfigurationFactory instance;
        public static JhsConfigurationFactory Instance 
        { 
            get
            {
                return instance;
            }
        }

        //public static JhsConfigurationFactory CreateConfiguration()
        //{

        //}

    }
}
