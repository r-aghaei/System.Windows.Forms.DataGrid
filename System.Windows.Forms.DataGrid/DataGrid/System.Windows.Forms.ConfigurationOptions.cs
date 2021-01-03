// System.Windows.Forms.ConfigurationOptions
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.Versioning;
namespace System.Windows.Forms
{
    internal static class ConfigurationOptions
    {
        private static NameValueCollection applicationConfigOptions;

        private static Version netFrameworkVersion;

        private static readonly Version featureSupportedMinimumFrameworkVersion;

        internal static Version OSVersion;

        internal static readonly Version RS2Version;

        public static Version NetFrameworkVersion
        {
            get
            {
                if (netFrameworkVersion == null)
                {
                    netFrameworkVersion = new Version(0, 0, 0, 0);
                    try
                    {
                        string targetFrameworkName = AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
                        if (!string.IsNullOrEmpty(targetFrameworkName))
                        {
                            FrameworkName frameworkName = new FrameworkName(targetFrameworkName);
                            if (string.Equals(frameworkName.Identifier, ".NETFramework"))
                            {
                                netFrameworkVersion = frameworkName.Version;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return netFrameworkVersion;
            }
        }

        static ConfigurationOptions()
        {
            applicationConfigOptions = null;
            netFrameworkVersion = null;
            featureSupportedMinimumFrameworkVersion = new Version(4, 7);
            OSVersion = Environment.OSVersion.Version;
            RS2Version = new Version(10, 0, 14933, 0);
            PopulateWinformsSection();
        }

        private static void PopulateWinformsSection()
        {
            if (NetFrameworkVersion.CompareTo(featureSupportedMinimumFrameworkVersion) >= 0)
            {
                try
                {
                    applicationConfigOptions = ConfigurationManager.GetSection("System.Windows.Forms.ApplicationConfigurationSection") as NameValueCollection;
                }
                catch (Exception)
                {
                }
            }
        }

        public static string GetConfigSettingValue(string settingName)
        {
            if (applicationConfigOptions != null && !string.IsNullOrEmpty(settingName))
            {
                return applicationConfigOptions.Get(settingName);
            }
            return null;
        }
    }
}