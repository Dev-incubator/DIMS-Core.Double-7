namespace DIMS_Core.Common.Exceptions
{
    public class InvalidArgumentException  : BaseException
    {
        public InvalidArgumentException(string parameterName) : base($"Invalid argument value of {parameterName}") { }
    }
}