using System;
using System.Collections.Generic;
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
using WPF.Toast.Controls;

namespace DemoApp
{
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
                NotificationMessage = "I am toast action"
            };
        }

        private void ToastContent_Button_Click(object sender, RoutedEventArgs e)
        {
            new ToastContent
            {
                Title = "Notification: This is Toast Content",
                NotificationMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean lacinia lacus ut tempor pellentesque.."
            };
        }
    }
}
