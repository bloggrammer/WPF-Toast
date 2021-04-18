using System;
using System.Windows.Media;

namespace WPF.Toast.Controls
{
    /// <summary>
    /// Interaction logic for ToastContent.xaml
    /// </summary>
    public partial class ToastContent : ToastBase
    {
        public ToastContent()
        {
            InitializeComponent();
            
        }
        public override bool IsToastAction { get; set; } = false;
    }
}
