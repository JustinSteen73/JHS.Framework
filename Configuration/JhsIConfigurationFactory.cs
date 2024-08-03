using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Configuration
{
    interface JhsIConfigurationFactory<t>
    {
        public void Init();
        public static t Instance { get; }
    }
}
