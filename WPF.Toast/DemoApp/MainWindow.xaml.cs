using System.Windows;
using WPF.Toast.Controls;

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
            new ToastAction 
            {
                Title = "Notification: This is Toast Action",
                NotificationMessage = "I am toast action",
                Position = WPF.Toast.Enums.Positions.East
            };
        }

        private void ToastContent_Button_Click(object sender, RoutedEventArgs e)
        {
            new ToastContent
            {
                Title = "Notification: This is Toast Content",
                NotificationMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean lacinia lacus ut tempor pellentesque..",
                Position = WPF.Toast.Enums.Positions.West
            };
        }
    }
}
