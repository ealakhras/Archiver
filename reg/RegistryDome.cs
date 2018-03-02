using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace set
{
    public static class RegistryDome
    {
        const string REG_KEY_ROOT = @"Software\Archiver";
        const string REG_VAL_CONNECTION_STRING = "DBConnectionString";
        const string REG_VAL_DEBUG_MODE = "DebugMode";

        private static string GetString(RegistryKey key, string name, string defVal = "")
        {
            object val = key.GetValue(name);
            if (val == null)
            {
                key.SetValue(name, defVal);
                return defVal;
            }
            return val.ToString();
        }

        private static bool GetBool(RegistryKey key, string name, bool defVal = false)
        {
            object val = key.GetValue(name);
            if (val == null)
            {
                key.SetValue(name, defVal ? 1 : 0, RegistryValueKind.DWord);
                return defVal;
            }

            return bool.Parse(val.ToString());
        }

        public static string DBConnectionString
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
                {
                    return GetString(key, REG_VAL_CONNECTION_STRING);
                }
            }

            set
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
                {
                    key.SetValue(REG_VAL_CONNECTION_STRING, value);
                }
            }
        }

        public static bool Debug
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
                {
                    return GetBool(key, REG_VAL_DEBUG_MODE);
                }
            }
            set
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
                {
                    key.SetValue(REG_VAL_DEBUG_MODE, value, RegistryValueKind.DWord);
                }
            }
        }
    }
}
