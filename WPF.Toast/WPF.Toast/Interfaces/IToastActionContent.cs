using WPF.Toast.Events;

namespace WPF.Toast.Interfaces
{
    public interface IToastActionContent
    {
        /// <summary>
        ///  Occurs when the toast action control is about to close.
        /// </summary>
        event ToastActionContentEventHandler ToastClosed;
    }
}
