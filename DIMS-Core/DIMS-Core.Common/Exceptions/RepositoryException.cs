using System;

namespace DIMS_Core.Common.Exceptions
{
    public static class RepositoryException
    {
        public static void IsIdValid(int id)
        {
            if(id<=0)
            {
                throw new InvalidArgumentException("id");
            }
        }

        public static void IsEntityExists(object entity,string entityName)
        {
            if(entity is null)
            {
                throw new ObjectNotFoundException(entityName);
            }
        }
    }
}