using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework
{
    public interface JhsISingleton<t>
    {
        public static t Instance { get; }
    }
}
