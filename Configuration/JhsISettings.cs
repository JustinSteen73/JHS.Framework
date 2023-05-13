using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Configuration
{
    public interface JhsISettings
    {
        public string GetSettingValue(string settingFullName);
    }
}
