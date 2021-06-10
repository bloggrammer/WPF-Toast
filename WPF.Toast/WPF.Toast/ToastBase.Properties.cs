using System.ComponentModel;
using System.Windows;
using WPF.Toast.Enums;

namespace WPF.Toast {
    public partial class ToastBase {

        [Bindable(true)]
        public string NotificationMessage {
            get { return (string)GetValue(NotificationMessageProperty); }
            set { SetValue(NotificationMessageProperty, value); }
        }
        public static readonly DependencyProperty NotificationMessageProperty =
            DependencyProperty.Register(nameof(NotificationMessage), typeof(string), typeof(ToastBase));


        [Bindable(true)]
        public Positions Position {
            get { return (Positions)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register(nameof(Position), typeof(Positions), typeof(ToastBase), new PropertyMetadata(Positions.Central,PositionChanged));

        private static void PositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var toast = d as ToastBase;
            toast.Position = (Positions)e.NewValue;
        }
    }
}
