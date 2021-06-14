namespace WPF.Toast.Controls
{
    /// <summary>
    /// Interaction logic for ToastAction.xaml
    /// </summary>
    public partial class ToastAction : ToastBase
    {
        /// <param name="fadeTimeOut">Timer for fade out in seconds</param>
        public ToastAction(int? fadeTimeOut = null) : base(fadeTimeOut)
        {
            InitializeComponent();
        }

        public override bool IsToastAction { get; set; } = true;
    }
}
