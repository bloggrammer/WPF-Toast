using System;
using System.Windows.Media;

namespace WPF.Toast.Controls
{
    /// <summary>
    /// Interaction logic for ToastAction.xaml
    /// </summary>
    public partial class ToastAction : ToastBase
    {
        public ToastAction()
        {
            InitializeComponent();
            try
            {
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri(@"Resources\Windows Proximity Notification.wav"));
                mediaPlayer.Play();
            }
            catch { }
        }
        public bool IsCancel { get; set; }
        public bool IsOK { get; set; }
        public bool IsSnoozed { get; set; }
        public int SnoozedIndex { get; set; }
        public override bool IsToastAction { get; set; } = true;
        private void OnOkClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsCancel = (bool)cancelAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            SOMANotificationEvent?.Invoke();
            CloseAction();
        }

        private void OnCancelClick(object sender, System.Windows.RoutedEventArgs e)
        {
            IsCancel = true;
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            SOMANotificationEvent?.Invoke();
            CloseAction();
        }
        public event ToastNotification SOMANotificationEvent;
    }

    public delegate void ToastNotification();
}
