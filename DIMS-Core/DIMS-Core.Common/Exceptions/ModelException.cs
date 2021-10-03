using System;

namespace DIMS_Core.Common.Exceptions
{
    public static class ModelException
    {
        public static void IsNotNull<T>(T model, string modelName)
        {
            if (model is null)
            {
                throw new ArgumentNullException(modelName);
            }
        }
    }
}