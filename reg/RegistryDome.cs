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
        const string REG_VAL_ROOTS = "Roots";


        private static string GetString(string name, string defVal = "")
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
            {
                object val = key.GetValue(name);
                if (val == null)
                {
                    key.SetValue(name, defVal);
                    return defVal;
                }
                return val.ToString();
            }
        }

        private static void SetString(string name, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
            {
                key.SetValue(REG_VAL_CONNECTION_STRING, value);
            }
        }

        private static bool GetBool(string name, bool defVal = false)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
            {
                object val = key.GetValue(name);
                if (val == null)
                {
                    key.SetValue(name, defVal ? 1 : 0, RegistryValueKind.DWord);
                    return defVal;
                }
                return bool.Parse(val.ToString());
            }
        }

        private static void SetBool(string name, bool value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_KEY_ROOT))
            {
                key.SetValue(name, value, RegistryValueKind.DWord);
            }
        }

        public static string DBConnectionString
        {
            get
            {
                return GetString(REG_VAL_CONNECTION_STRING);
            }

            set
            {
                SetString(REG_VAL_CONNECTION_STRING, value);
            }
        }

        public static bool Debug
        {
            get
            {
                return GetBool(REG_VAL_DEBUG_MODE);
            }
            set
            {
                SetBool(REG_VAL_DEBUG_MODE, value);
            }
        }

        public static string Roots
        {
            get
            {
                return GetString(REG_VAL_ROOTS);
            }

            set
            {
                SetString(REG_VAL_ROOTS, value);
            }
        }

    }
}
