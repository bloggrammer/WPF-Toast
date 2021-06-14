using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.Toast.Controls;
using WPF.Toast.Enums;

namespace DemoApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToastAction_Button_Click(object sender, RoutedEventArgs e)
        {
            new ToastAction(_fadeTimeOut)
            {
                Title = "Notification: This is Toast Action",
                NotificationMessage = "I am toast action",
                Position = _positions != null ? _positions.Value : Positions.Central,
                PositionReference = _positionReference != null ? _positionReference.Value : PositionReference.Owner,
                Content = new ToastActionContent(),
                Owner = this
            };
        }

        private void ToastContent_Button_Click(object sender, RoutedEventArgs e)
        {
            new ToastContent(_fadeTimeOut) {
                Title = "Notification: This is Toast Content",
                NotificationMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean lacinia lacus ut tempor pellentesque..",
                Position = _positions != null ? _positions.Value : Positions.Central,
                PositionReference = _positionReference != null ? _positionReference.Value : PositionReference.Owner,
                Owner = this,
            };
        }

        private void Position_Checked(object sender, RoutedEventArgs e) {
            var radioButton = sender as RadioButton;
            var value = (Positions)Enum.Parse(typeof(Positions),radioButton.Content.ToString());
            _positions = value;
        }

        private void PositionReference_Checked(object sender, RoutedEventArgs e) {
            var radioButton = sender as RadioButton;
            var value = (PositionReference)Enum.Parse(typeof(PositionReference), radioButton.Content.ToString());
            _positionReference = value;
        }
        
        private void TimeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fadeTimeOut = (int) e.NewValue;
            TimeLabel.Content = $"Show time in seconds: {_fadeTimeOut}s (Set 0 for default timing)";
        }

        private void ToastCloseButtonBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e) {
            if (Application.Current.Resources.Contains("ToastCloseButtonBackground"))
                Application.Current.Resources.Remove("ToastCloseButtonBackground");
            Application.Current.Resources.Add("ToastCloseButtonBackground", new SolidColorBrush(e.NewValue.Value));
        }

        private void ToastCloseButtonForeground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e) {
            if (Application.Current.Resources.Contains("ToastCloseButtonForeground"))
                Application.Current.Resources.Remove("ToastCloseButtonForeground");
            Application.Current.Resources.Add("ToastCloseButtonForeground", new SolidColorBrush(e.NewValue.Value));
        }

        private void ToastBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e) {
            if (Application.Current.Resources.Contains("ToastBackground"))
                Application.Current.Resources.Remove("ToastBackground");
            Application.Current.Resources.Add("ToastBackground", new SolidColorBrush(e.NewValue.Value));
        }

        private void ToastBorderBrush_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e) {
            if (Application.Current.Resources.Contains("ToastBorderBrush"))
                Application.Current.Resources.Remove("ToastBorderBrush");
            Application.Current.Resources.Add("ToastBorderBrush", new SolidColorBrush(e.NewValue.Value));
        }

        private void ToastContentForeground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e) {
            if (Application.Current.Resources.Contains("ToastContentForeground"))
                Application.Current.Resources.Remove("ToastContentForeground");
            Application.Current.Resources.Add("ToastContentForeground", new SolidColorBrush(e.NewValue.Value));
        }

        private void ToastHeaderBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e) {
            if (Application.Current.Resources.Contains("ToastHeaderBackground"))
                Application.Current.Resources.Remove("ToastHeaderBackground");
            Application.Current.Resources.Add("ToastHeaderBackground", new SolidColorBrush(e.NewValue.Value));
        }


        private Positions? _positions;
        private PositionReference? _positionReference;
        private int _fadeTimeOut;
    }
}
