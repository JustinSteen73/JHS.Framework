using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework
{
    public class JhsSingleton<t> 
    {
        protected static t instance;
        public static t Instance
        {
            get { return instance; }
        }

    }
}
