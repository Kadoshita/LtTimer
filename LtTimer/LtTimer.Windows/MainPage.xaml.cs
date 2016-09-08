using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace LtTimer
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dispTimer;
        int time;
        public MainPage()
        {
            this.InitializeComponent();
            dispTimer = new DispatcherTimer();
            dispTimer.Tick += DispTimer_Tick;
            dispTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Source = new Uri("ms-appx:///Assets/start.wav");
            mediaElement.Play();
            Disp_Text(300);
            time = 0;
            dispTimer.Start();
        }
        private void DispTimer_Tick(object sender, object e)
        {
            time++;
            Disp_Text(300 - time);
            if (time == 300)
            {
                mediaElement.Source = new Uri("ms-appx:///Assets/end.wav");
                mediaElement.Play();
                dispTimer.Stop();
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dispTimer.Stop();
            Disp_Text(300);
        }
        private void Disp_Text(int count)
        {
            int min, sec;
            String disptext = "";
            min = count / 60;
            sec = count % 60;
            disptext = String.Format("{0:0}:{1:00}",min,sec);
            TextBlock.Text = disptext;
        }
    }
}
