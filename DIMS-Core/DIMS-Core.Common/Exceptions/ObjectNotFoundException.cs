using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    public class ObjectNotFoundException : BaseException
    {
        public ObjectNotFoundException(string entityName) : base($"Object not fount for {entityName}") { }
    }
}
