using GryphonSecurity_v2.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GryphonSecurity_v2.DataSource
{
    class DummyDB
    {
        private static IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        private Boolean dummyDBStatus = false;
        private String KEY_FIRSTNAME = "FIRSTNAME";
        private String KEY_LASTNAME = "LASTNAME";
        private String KEY_ADDRESS = "ADDRESS";
        private String KEY_PHONENUMBER = "PHONENUMBER";
        private String KEY_USERNAME = "USERNAME";
        private String KEY_PASSWORD = "PASSWORD";
        public Boolean createUser(User user)
        {
            if (appSettings.Contains(KEY_FIRSTNAME))
            {
                appSettings.Remove(KEY_FIRSTNAME);
                appSettings.Remove(KEY_LASTNAME);
                appSettings.Remove(KEY_ADDRESS);
                appSettings.Remove(KEY_PHONENUMBER);
                appSettings.Remove(KEY_USERNAME);
                appSettings.Remove(KEY_PASSWORD);
            }

            try
            {
                Debug.WriteLine("" + user.toString());
                appSettings.Add(KEY_FIRSTNAME, user.Firstname);
                appSettings.Add(KEY_LASTNAME, user.Lastname);
                appSettings.Add(KEY_ADDRESS, user.Address);
                appSettings.Add(KEY_PHONENUMBER, user.Phonenumber);
                appSettings.Add(KEY_USERNAME, user.Username);
                appSettings.Add(KEY_PASSWORD, user.Password);
                appSettings.Save();
                dummyDBStatus = true;

            }
            catch (IsolatedStorageException)
            {
                dummyDBStatus = false;
                Debug.WriteLine("you are here");
            }
            return dummyDBStatus;
        }

        public User getUser()
        {
            if (appSettings.Contains(KEY_USERNAME))
            {
                String firstname = appSettings[KEY_FIRSTNAME] as String;
                String lastname = appSettings[KEY_LASTNAME] as String;
                String address = appSettings[KEY_ADDRESS] as String;
                long phonenumber = Convert.ToInt64(appSettings[KEY_PHONENUMBER] as String);
                String username = appSettings[KEY_USERNAME] as String;
                String password = appSettings[KEY_PASSWORD] as String;
                return new User(firstname, lastname, address, phonenumber, username, password);
            }
            else
            {
                return null;
            }

        }

        public Boolean createAlarmReport(AlarmReport alarmReport)
        {
            return true;
        }
        //todo
        public AlarmReport getAlarmReport()
        {
            return null;
        }
    }
}
