using System;
using System.Windows.Media;

namespace WPF.Toast.Controls
{
    /// <summary>
    /// Interaction logic for ToastContent.xaml
    /// </summary>
    public partial class ToastContent : ToastBase
    {
        public ToastContent() : this(null)
        {
            
        }
        
        /// <param name="fadeTimeOut">Timer for fade out in seconds</param>
        public ToastContent(int? fadeTimeOut) : base(fadeTimeOut)
        {
            InitializeComponent();
        }

        public override bool IsToastAction { get; set; } = false;
    }
}
