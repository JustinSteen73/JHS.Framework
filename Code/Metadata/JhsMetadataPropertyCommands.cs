using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Code.Metadata
{

    public static class JhsMetadataPropertyCommands
    {

        public static System.Collections.Generic.KeyValuePair<string, object>[] GetPropertyNamesAndValues(object obj)
        {
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            System.Collections.Generic.KeyValuePair<string, object> kvp;

            System.Type t = obj.GetType();
            foreach (System.Reflection.PropertyInfo prop in t.GetProperties())
            {
                string propName = prop.Name;
                object propValue = prop.GetValue(obj);
                kvp = new System.Collections.Generic.KeyValuePair<string, object>(propName, propValue);
                al.Add(kvp);
            }

            return (System.Collections.Generic.KeyValuePair<string, object>[])al.ToArray(typeof(System.Collections.Generic.KeyValuePair<string, object>));

        }

        public static void SetPropertyValue(object obj, string propName, object propValue)
        {
            System.Type t = obj.GetType();
            System.Reflection.PropertyInfo prop = t.GetProperty(propName);
            if (prop == null)
                throw new JhsException($"Cannot find Property {propName}");
            else
                prop.SetValue(obj, propValue);
        }

    }

}
