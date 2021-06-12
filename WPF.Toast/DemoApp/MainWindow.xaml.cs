using System;
using System.Windows;
using System.Windows.Controls;
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
                Owner = this
            };
        }

        private void ToastContent_Button_Click(object sender, RoutedEventArgs e)
        {
            new ToastContent(_fadeTimeOut)
            {
                Title = "Notification: This is Toast Content",
                NotificationMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean lacinia lacus ut tempor pellentesque..",
                Position = _positions != null? _positions.Value : Positions.Central,
                PositionReference = _positionReference !=null ? _positionReference.Value: PositionReference.Owner,
                Owner = this
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

        private Positions? _positions;
        private PositionReference? _positionReference;
        private int _fadeTimeOut;
    }
}
