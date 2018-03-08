using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace set
{
    public static class RegistryDome
    {
        #region constants
        const string REG_KEY_ROOT = @"Software\Archiver";
        const string REG_KEY_UI = REG_KEY_ROOT + @"\ui";
        const string REG_KEY_DAL = REG_KEY_ROOT + @"\dal";

        const string REG_VAL_DEBUG_MODE = "DebugMode";
        const string REG_VAL_SPLIT_LEFT_DIST = "SplitterLeftDist";
        const string REG_VAL_SPLIT_RIGHT_DIST = "SplitterRightDist";
        const string REG_VAL_SPLIT_VERT_DIST = "SplitterVertDist";
        const string REG_VAL_SPLIT_WIDTH = "SplitterWidth";
        const string REG_VAL_VIEW_FOLDERS = "ViewFolders";
        const string REG_VAL_VIEW_PREVIEW = "ViewPreview";
        const string REG_VAL_VIEW_STATUSBAR = "ViewStatusBar";
        const string REG_VAL_VIEW_TOOLBAR = "ViewToolbar";
        const string REG_VAL_WINDOWS_SIZE = "WindowSize";
        const string REG_VAL_WINDOWS_STATE = "WindowState";

        const string REG_VAL_DBSC = "DBCS";
        #endregion

        #region methods
        private static string GetString(string key, string name, string defVal = "")
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                object val = regKey.GetValue(name);
                if (val == null)
                {
                    regKey.SetValue(name, defVal);
                    return defVal;
                }
                return val.ToString();
            }
        }

        private static string[] GetStringArray(string key, string nameStart)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                string[] items = regKey.GetValueNames();
                List<string> result = new List<string>();
                foreach (string item in items)
                {
                    if(item.StartsWith(nameStart))
                    {
                        result.Add(regKey.GetValue(item).ToString());
                    }
                }
                return result.ToArray();
            }

        }

        private static void SetString(string key, string name, string value)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                regKey.SetValue(name, value);
            }
        }

        private static bool GetBool(string key, string name, bool defVal = false)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                object val = regKey.GetValue(name);
                if (val == null)
                {
                    regKey.SetValue(name, defVal ? 1 : 0, RegistryValueKind.DWord);
                    return defVal;
                }
                return val.ToString() == "0" ? false: true;
            }
        }

        private static void SetBool(string key, string name, bool value)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                regKey.SetValue(name, value, RegistryValueKind.DWord);
            }
        }

        private static int GetInt(string key, string name, int defVal = 0)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                object val = regKey.GetValue(name);
                if (val == null)
                {
                    regKey.SetValue(name, defVal, RegistryValueKind.DWord);
                    return defVal;
                }
                return int.Parse(val.ToString());
            }
        }

        private static void SetInt(string key, string name, int value)
        {
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key))
            {
                regKey.SetValue(name, value, RegistryValueKind.DWord);
            }
        }
        #endregion

        #region properties
        public static bool Debug
        {
            get
            {
                return GetBool(REG_KEY_ROOT, REG_VAL_DEBUG_MODE);
            }
            set
            {
                SetBool(REG_KEY_ROOT, REG_VAL_DEBUG_MODE, value);
            }
        }

        public static int SplitterWidth
        {
            get
            {
                return GetInt(REG_KEY_UI, REG_VAL_SPLIT_WIDTH, 4);
            }
        }

        public static int SplitLeftDist
        {
            get
            {
                return GetInt(REG_KEY_UI, REG_VAL_SPLIT_LEFT_DIST, 200);
            }
            set
            {
                SetInt(REG_KEY_UI, REG_VAL_SPLIT_LEFT_DIST, value);
            }
        }

        public static int SplitRightDist
        {
            get
            {
                return GetInt(REG_KEY_UI, REG_VAL_SPLIT_RIGHT_DIST, 950);
            }
            set
            {
                SetInt(REG_KEY_UI, REG_VAL_SPLIT_RIGHT_DIST, value);
            }
        }

        public static int SplitVertDist
        {
            get
            {
                return GetInt(REG_KEY_UI, REG_VAL_SPLIT_VERT_DIST, 500);
            }
            set
            {
                SetInt(REG_KEY_UI, REG_VAL_SPLIT_VERT_DIST, value);
            }
        }

        public static bool ViewFolders
        {
            get
            {
                return GetBool(REG_KEY_UI, REG_VAL_VIEW_FOLDERS, true);
            }
            set
            {
                SetBool(REG_KEY_UI, REG_VAL_VIEW_FOLDERS, value);
            }
        }

        public static bool ViewPreview
        {
            get
            {
                return GetBool(REG_KEY_UI, REG_VAL_VIEW_PREVIEW, true);
            }
            set
            {
                SetBool(REG_KEY_UI, REG_VAL_VIEW_PREVIEW, value);
            }
        }

        public static bool ViewStatusBar
        {
            get
            {
                return GetBool(REG_KEY_UI, REG_VAL_VIEW_STATUSBAR, true);
            }
            set
            {
                SetBool(REG_KEY_UI, REG_VAL_VIEW_STATUSBAR, value);
            }
        }

        public static bool ViewToolbar
        {
            get
            {
                return GetBool(REG_KEY_UI, REG_VAL_VIEW_TOOLBAR, true);
            }
            set
            {
                SetBool(REG_KEY_UI, REG_VAL_VIEW_TOOLBAR, value);
            }
        }

        public static FormWindowState WindowsState
        {
            get
            {
                string result = GetString(REG_KEY_UI, REG_VAL_WINDOWS_STATE, FormWindowState.Maximized.ToString());
                if (result == FormWindowState.Maximized.ToString())
                {
                    return FormWindowState.Maximized;
                }
                return FormWindowState.Normal;
            }
            set
            {
                SetString(REG_KEY_UI, REG_VAL_WINDOWS_STATE, value.ToString());
            }
        }

        public static Size WindowSize
        {
            get
            {
                Size defSize = new Size(830, 425);
                try
                {
                    string[] result = GetString(REG_KEY_UI, REG_VAL_WINDOWS_SIZE, defSize.ToString()).Split(',');
                    int width = int.Parse(result[0].Substring(result[0].IndexOf('=') + 1));
                    int height = int.Parse(result[1].Substring(result[1].IndexOf('=') + 1, result[1].Substring(result[1].IndexOf('=') + 1).Length - 1));
                    return new Size(width, height);
                }
                catch
                {
                    return defSize;
                }
            }
            set
            {
                SetString(REG_KEY_UI, REG_VAL_WINDOWS_SIZE, value.ToString());
            }
        }

        public static string[] DBCS
        {
            get
            {
                return GetStringArray(REG_KEY_DAL, REG_VAL_DBSC);
            }
        }

        #endregion
    }
}
