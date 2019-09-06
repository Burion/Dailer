using System;

namespace DailerApp.Exceptions
{
    public class NoSuchTypeInDbContextException: Exception
    {
        public NoSuchTypeInDbContextException(Type type)
        {
            MissingType = type;
        }

        public override string Message { get {return $"Type {MissingType.ToString()} not found in DbContext" ;} }
        public Type MissingType;
    }
}