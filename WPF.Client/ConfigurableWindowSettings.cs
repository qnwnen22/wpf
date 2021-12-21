using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Client
{
    public interface IConfigurableWindowSettings
    {
        bool IsFirstRun { get; }
        Point WindowLocation { get; set; }
        Size WindowSize { get; set; }
        WindowState WindowState { get; set; }
    }
    public class ConfigurableWindowSettings : IConfigurableWindowSettings
    {
        #region Data
        readonly ApplicationSettingsBase settings;
        readonly string isFirstRun;
        readonly string windowLocation;
        readonly string windowSize;
        readonly string windowState;
        #endregion

        #region Constructor
        public ConfigurableWindowSettings(
            ApplicationSettingsBase settings,
            string isFirstRunProp,
            string windowLocationProp,
            string windowSizeProp,
            string windowStateProp
            )
        {
            this.settings = settings;
            this.isFirstRun = isFirstRunProp;
            this.windowLocation = windowLocationProp;
            this.windowSize = windowSizeProp;
            this.windowState = windowStateProp;
        }
        #endregion

        protected T GetValue<T>(string propName)
        {
            return (T)settings[propName];
        }
        protected void SetValue(string propName, object value)
        {
            settings[propName] = value;
            settings.Save();
        }

        public bool IsFirstRun
        {
            get { return GetValue<bool>(isFirstRun); }
            protected set { SetValue(isFirstRun, value); }
        }
        public Point WindowLocation
        {
            get { return GetValue<Point>(windowLocation); }
            set { SetValue(windowLocation, value); }
        }
        public Size WindowSize
        {
            get { return GetValue<Size>(windowSize); }
            set { SetValue(windowSize, value); }
        }
        public WindowState WindowState
        {
            get { return GetValue<WindowState>(windowState); }
            set { SetValue(windowState, value); }
        }
    }

}
