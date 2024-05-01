namespace TaxReporter.Exceptions.Rol
{
    public class GetRolFailedException : Exception
    {
        public override string Message { get; }

        public GetRolFailedException() : base() 
        {
            Message = "No role found";
        }

    }
}
