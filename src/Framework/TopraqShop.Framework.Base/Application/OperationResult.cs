namespace TopraqShop.Framework.Base.Application
{
    public class OperationResult
    {
        public string Message { get;private set; }
        public bool IsSucceeded { get; private set; }

        public OperationResult Succeeded(string message = "Operation has done successfully")
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