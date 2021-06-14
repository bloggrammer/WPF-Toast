using System;
using System.Windows.Controls;

namespace DemoApp {
    /// <summary>
    /// Interaction logic for ToastActionContent.xaml
    /// </summary>
    public partial class ToastActionContent : UserControl {
        public ToastActionContent() {
            InitializeComponent();
        }

        public bool IsCancel { get; set; }
        public bool IsOK { get; set; }
        public bool IsSnoozed { get; set; }
        public int SnoozedIndex { get; set; }

        private void OnOkClick(object sender, System.Windows.RoutedEventArgs e) {
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsCancel = (bool)cancelAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            ToastNotificationEvent?.Invoke();
           
           // Utilize the tag as the close action
           var close = Tag as Action;
            close();
        }

        private void OnCancelClick(object sender, System.Windows.RoutedEventArgs e) {
            IsCancel = true;
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            ToastNotificationEvent?.Invoke();

            // Utilize the tag as the close action
            var close = Tag as Action;
            close();
        }
        public event ToastNotification ToastNotificationEvent;
    }

    public delegate void ToastNotification();
}
