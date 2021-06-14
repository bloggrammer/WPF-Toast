using System;
using System.Windows.Controls;

namespace DemoApp.SamplesContent
{
    /// <summary>
    /// Interaction logic for SampleContentOne.xaml
    /// </summary>
    public partial class SampleContentOne : Border
    {
        public SampleContentOne()
        {
            InitializeComponent();
        }
        private void OnOkClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsCancel = (bool)cancelAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            Close();
        }

        private void OnCancelClick(object sender, System.Windows.RoutedEventArgs e)
        {
            IsCancel = true;
            SnoozedIndex = snoozedSelection.SelectedIndex;
            IsSnoozed = (bool)snoozedAction.IsChecked;
            IsOK = (bool)okAction.IsChecked;
            Close();
        }

        private void Close()
        {
            if (Tag is Action action)
                action();
        }
        public bool IsCancel { get; set; }
        public bool IsOK { get; set; }
        public bool IsSnoozed { get; set; }
        public int SnoozedIndex { get; set; }


    }
}
