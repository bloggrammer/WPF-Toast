using System;

namespace WPF.Toast.Exceptions {
    public class InvalidOwnerException : NullReferenceException{
        public InvalidOwnerException() : base("The owner property of the toast control was not set") { }
    }
}
