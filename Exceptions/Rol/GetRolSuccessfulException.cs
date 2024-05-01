namespace TaxReporter.Exceptions.Rol
{
    public class GetRolSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetRolSuccessfulException() : base() 
        {
            Message = "Successful roles";
        }

    }
}
