using System;

namespace WPF.Toast.Exceptions {
    internal class InvalidOwnerException : NullReferenceException{
        public InvalidOwnerException() : base("The owner property of the toast control was not set") { }
    }
}
