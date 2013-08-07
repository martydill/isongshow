
// Settings.cs - A simple hashtable-based database of settings
// (c) 2005 Marty Dill. See license.txt for details.

// todo: load from file
// todo: rationalize all settings...

using System;
using System.Collections;


namespace iSongShow
{
    public class Settings
    {
        private Hashtable settingsTable = new Hashtable();
        private static Settings instance = new Settings();


        public static Settings Instance
        {
            get
            {
                return instance;
            }
        }


        private Settings()
        {
            SetDefaults();
        }


        public object GetValue(string settingName)
        {
            lock (typeof(Settings))
            {
                Validate(settingName);

                if (this.settingsTable.Contains(settingName))
                    return this.settingsTable[settingName];

                throw new ApplicationException("Unknown setting " + settingName);
            }
        }


        public double GetDouble(string settingName)
        {
            lock (typeof(Settings))
            {
                Validate(settingName);

                object o = this.GetValue(settingName);
                if (o is System.Double)
                    return Convert.ToDouble(o);

                throw new ApplicationException("Setting " + settingName + " is not a double");
            }
        }


        public int GetInt(string settingName)
        {
            lock (typeof(Settings))
            {
                Validate(settingName);

                object o = this.GetValue(settingName);
                if (o is System.Int32)
                    return Convert.ToInt32(o);

                throw new ApplicationException("Setting " + settingName + " is not an int");
            }
        }


        public void SetValue(string settingName, object val)
        {
            lock (typeof(Settings))
            {
                Validate(settingName);
                this.settingsTable[settingName] = val;
            }
        }


        private void SetDefaults()
        {
            this.SetValue("Opacity", 70);
            this.SetValue("OpacityStep", .01);
            this.SetValue("FadeDelay", 10);
            this.SetValue("PopupDuration", 3500);
        }


        private void Validate(string settingName)
        {
            if (settingName == null || settingName.Length == 0)
                throw new ArgumentException("Null or empty parameter", "settingName");
        }
    }
}
