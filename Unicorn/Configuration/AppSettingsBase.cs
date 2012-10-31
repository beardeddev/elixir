using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Unicorn.Configuration
{
    using Unicorn.Extensions;
    
    /// <summary>
    /// The base class for reading appSettings section.
    /// </summary>
    public abstract class AppSettingsBase
    {
        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <typeparam name="T">The type of a setting value.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns>A value of application setting as T type.</returns>
        protected static T GetSettingValue<T>(string name)
        {
            try
            {
                return GetSettingValue(name).GetValue<T>();
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets the app setting value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>String representation of application setting value.</returns>
        protected static string GetSettingValue(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
