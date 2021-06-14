using System;
using WPF.Toast.Interfaces;

namespace WPF.Toast.Controls
{
    /// <summary>
    /// Interaction logic for ToastAction.xaml
    /// </summary>
    public partial class ToastAction : ToastBase
    {
        /// <param name="fadeTimeOut">Timer for fade out in seconds</param>
        public ToastAction(IToastActionContent content, int? fadeTimeOut = null) : base(fadeTimeOut)
        {
            InitializeComponent();
            if (content == null)
                throw new ArgumentNullException("The toast action content was not set.");

            content.ToastClosed += ActionContent_ToastClosed;
            Content = content;
        }

        private void ActionContent_ToastClosed(object sender) => CloseAction();

        public override bool IsToastAction { get; set; } = true;
    }
}
