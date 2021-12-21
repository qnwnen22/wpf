using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPF.Client
{
    public abstract class WindowBase : Window
    {
        bool _isLoaded;
        readonly IConfigurableWindowSettings _settings;
        protected WindowBase()
        {
            _settings = this.CreateSettings();
            if (_settings == null)
            {
                throw new Exception("Cannot return null");
            }
            this.Loaded += delegate { _isLoaded = true; };
            this.ApplySettings();
        }

        protected abstract IConfigurableWindowSettings CreateSettings();
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                if (IsLoaded && base.WindowState == WindowState.Normal)
                {
                    Point loc = new Point(base.Left, base.Top);
                    _settings.WindowLocation = loc;
                }
            }
            ));
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo info)
        {
            base.OnRenderSizeChanged(info);
            if (IsLoaded && base.WindowState == WindowState.Normal)
            {
                _settings.WindowSize = base.RenderSize;
            }
        }
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (_isLoaded)
            {
                if (base.WindowState != WindowState.Minimized)
                {
                    _settings.WindowState = base.WindowState;
                }
                else
                {
                    _settings.WindowState = WindowState.Normal;
                }
            }
        }
        private void ApplySettings()
        {
            Size size;
            try
            {
                size = _settings.WindowSize;
            }
            catch
            {
                size = new Size(0, 0);
            }
            base.Width = size.Width;
            base.Height = size.Height;

            Point loc;
            try
            {
                loc = _settings.WindowLocation;
            }
            catch
            {
                loc = new Point(0, 0);
            }
            bool outOfBounds =
                SystemParameters.VirtualScreenWidth <= loc.X ||
                SystemParameters.VirtualScreenHeight <= loc.Y;
            //loc.X <= -size.Width ||
            //loc.Y <= -size.Height ||
            if (_settings.IsFirstRun || outOfBounds)
            {
                base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                base.WindowStartupLocation = WindowStartupLocation.Manual;
                base.Left = loc.X;
                base.Top = loc.Y;
                this.SourceInitialized += delegate
                {
                    base.WindowState = _settings.WindowState;
                };
            }
        }
    }
}
