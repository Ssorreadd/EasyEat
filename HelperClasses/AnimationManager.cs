using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EasyEat.HelperClasses
{
    public static class AnimationManager
    {
        public static bool IsPlaying { get; private set; }

        /// <summary>
        /// Принимает в качестве параметра страницу, на которую нужно перейти.<br/>
        /// Если оставить принимаемое значение пустым - будет произведен переход на предыдущую страницу, если такая имеется.
        /// </summary>
        /// <param name="requiredPage">Страница для перехода</param>
        public static async void StartAnimation(Page? requiredPage = null)
        {
            await Task.Run(() =>
            {
                if (IsPlaying)
                {
                    return;
                }

                IsPlaying = true;

                for (double i = 1.0; i >= 0; i -= 0.025)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        FrameManager.MainFrame.Opacity = i;
                    }));

                    Thread.Sleep(5);
                }

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    if (requiredPage != null)
                    {
                        FrameManager.MainFrame.Navigate(requiredPage);
                    }
                    else if (FrameManager.MainFrame.CanGoBack)
                    {
                        FrameManager.MainFrame.GoBack();
                    }
                }));

                for (double i = 0.0; i <= 1.0; i += 0.025)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        FrameManager.MainFrame.Opacity = i;
                    }));

                    Thread.Sleep(5);
                }

                IsPlaying = false;
            });
        }
    }
}
