using BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input; 
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Controls
{
    /// <summary>
    /// Interaction logic for MessageBoxV2.xaml
    /// </summary>
    public partial class MessageBoxV2 : UserControl
    {
        //public UIElement PlacementTarget { get; set; }
        //public UIElement MainPanel { get; set; }

        //private System.Timers.Timer _popup_timer;
        private DispatcherTimer? timer;



        public static readonly DependencyProperty PlacementTargetProperty =
            DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(MessageBoxV2),
            new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });
        
        public UIElement PlacementTarget
        {
            get { return (UIElement)GetValue(MessageBoxV2.PlacementTargetProperty); }
            set { SetValue(MessageBoxV2.PlacementTargetProperty, value); }
        }



        public static readonly DependencyProperty MessageToUserProperty =
            DependencyProperty.Register("MessageToUser", typeof(MessageToUser), typeof(MessageBoxV2),
            new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        public MessageToUser MessageToUser
        {
            get { return (MessageToUser)GetValue(MessageBoxV2.MessageToUserProperty); }
            set { SetValue(MessageBoxV2.MessageToUserProperty, value); }
        }
        

        public MessageBoxV2()
        {
            InitializeComponent();

            // MessageToUser.PropertyChanged += this.MessageToUserPropertyChanged;

            //_popup_timer = new System.Timers.Timer(500 * 1); // 10 seconds
            //_popup_timer.Elapsed += popup_timer_Elapsed;
            //_popup_timer.Enabled = true;
            //_popup_timer.Stop();
        }


        public void stopMessage()
        {

            MessageToUser.IsOpen = false;
            timer?.Stop();
        }


        public void showPopUpMessage()
        {
            //MessageToUser.StaysOpen = true;
            MessageToUser.OpenProgress = 100;
            timer?.Start();
            //_popup_timer.Enabled = true;
            //_popup_timer.Start();
            //Console.WriteLine("Timer has started");
        }

        //void popup_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        void popup_timer_Elapsed(object? sender, EventArgs e)
        {
            //if(!MessageToUser.IsOpen)
            //{
            //    stopMessage();
            //    return;
            //}

            if(MessageToUser.Tipo == "Success")
                MessageToUser.OpenProgress -= 20;
            else if(MessageToUser.Tipo != "Waiting")
                MessageToUser.OpenProgress -= 10;

            if (MessageToUser.OpenProgress <= 0)
            {
                stopMessage();
                //_popup_timer.Enabled = false;
                //_popup_timer.Stop();
            }
            //string output = string.Format("{0},{1}\r\n", DateTime.Now.ToLongDateString(), (int)Math.Floor(timeSinceStart.TotalMinutes));
            //Console.Write(output);
        }
        

        public void MessageToUserPropertyChanged(object? sender, PropertyChangedEventArgs eventArgs)
        {
            if (sender == null)
                return;

            MessageToUser objSender = (MessageToUser)sender;
            if (eventArgs.PropertyName == "IsOpen" && objSender.IsOpen)
            {
                showPopUpMessage();
            }
        }

        private void PopUpController_Loaded(object sender, RoutedEventArgs e)
        {
            //Setup a timer to close the popup in 3 seconds 
            
            timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Tick += popup_timer_Elapsed;
            try
            {
                if (MessageToUser != null)
                {
                    MessageToUser.PropertyChanged -= this.MessageToUserPropertyChanged;
                    MessageToUser.PropertyChanged += this.MessageToUserPropertyChanged;
                }
            }
            catch { }
        }

        private void InformationPopUpCloseClick(object sender, MouseButtonEventArgs e)
        {

            MessageToUser.IsOpen = false;
            timer?.Stop();
            //_popup_timer.Enabled = false;
            //_popup_timer.Stop();
        }

        private void InformationPopUpClick(object sender, MouseButtonEventArgs e)
        {

            timer?.Stop();
        }
    }
}
