using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WPF.Toast.Enums;
using WPF.Toast.Exceptions;
using static WPF.Toast.Utils.PositionCalculator;


namespace WPF.Toast
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF.Toast"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF.Toast;assembly=WPF.Toast"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ToastBase/>
    ///
    /// </summary>
    public abstract partial class ToastBase : Window
    {
        static ToastBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastBase),
                new FrameworkPropertyMetadata(typeof(ToastBase)));
        }

        /// <param name="fadeTimeOut">Timer for fade out in seconds</param>
        public ToastBase(int? fadeTimeOut = null)
        {
            Width = 350;
            Height = 75;
            Visibility = Visibility.Visible;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Topmost = true;
            AllowsTransparency = true;
            Opacity = 0;
            BorderThickness = new Thickness(1);
            BorderBrush = Brushes.White;
            Background = Brushes.Black;

            _fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 0.8,
                Duration = new Duration(TimeSpan.Parse("0:0:1.5"))
            };
            _fadeOutAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = new Duration(TimeSpan.Parse("0:0:1.5"))
            };

            Loaded += ToastBase_Loaded;
            _fadeTimout = fadeTimeOut;
        }
        public override void OnApplyTemplate()
        {
            if (Template.FindName("PART_CloseButton", this) is ButtonBase closeButton)
                closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _activeTimer?.Stop();
            FadeOut();
        }

        private void ToastBase_Loaded(object sender, RoutedEventArgs e)
        {
            Tuple<double, double> topLeft;
            if (PositionReference == PositionReference.Screen)
                topLeft = GetFromWindow(Position, Width, Height, BorderThickness);
            else
            {
                if (Owner is null)
                    throw new InvalidOwnerException();
                topLeft = GetFromOwner(new Rect(new Point(Owner.Left, Owner.Top), Owner.RenderSize), Position, Width, Height, BorderThickness);
            }

            Top = topLeft.Item1;
            Left = topLeft.Item2;
            _fadeInAnimation.Completed += FadeInAnimation_Completed;

            BeginAnimation(OpacityProperty, _fadeInAnimation);
        }

        private void FadeInAnimation_Completed(object sender, EventArgs e)
        {
            _activeTimer = new DispatcherTimer();
            if (_fadeTimout.HasValue && _fadeTimout > 0)
                _activeTimer.Interval = TimeSpan.FromSeconds(_fadeTimout.Value);
            else if (IsToastAction)
                _activeTimer.Interval = TimeSpan.FromMinutes(1);
            else
                _activeTimer.Interval = TimeSpan.FromSeconds(15);

            _activeTimer.Tick += delegate (object obj, EventArgs ea) { FadeOut(); };

            _activeTimer.Start();
        }

        private void FadeOut()
        {
            _fadeOutAnimation.Completed += delegate (object sender, EventArgs e) { Close(); };

            BeginAnimation(OpacityProperty, _fadeOutAnimation, HandoffBehavior.SnapshotAndReplace);
        }

        protected void CloseAction()
        {
            _activeTimer?.Stop();
            FadeOut();
        }
        public abstract bool IsToastAction { get; set; }
        private readonly DoubleAnimation _fadeInAnimation;
        private readonly DoubleAnimation _fadeOutAnimation;
        private DispatcherTimer _activeTimer;

        /// <summary>
        /// FadeOut timer in seconds
        /// </summary>
        private int? _fadeTimout;
    }
}
