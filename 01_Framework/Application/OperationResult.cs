namespace _01_Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceeded { get; private set; }
        public string Message { get; private set; }

        public OperationResult Succeeded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}