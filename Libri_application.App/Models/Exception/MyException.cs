namespace Libri_application.App.Models.Exception
{
    public class MyException : System.Exception 
    {
        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, System.Exception inner) : base(message, inner) { }

    }
}
