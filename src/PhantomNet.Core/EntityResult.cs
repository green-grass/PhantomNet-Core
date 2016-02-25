using System.Collections.Generic;
using System.Linq;

namespace PhantomNet
{
    public class EntityResult
    {
        private static readonly EntityResult _success = new EntityResult { Succeeded = true };
        private List<EntityError> _errors = new List<EntityError>();

        public bool Succeeded { get; protected set; }

        public IEnumerable<EntityError> Errors => _errors;

        public static EntityResult Success => _success;

        public static EntityResult Failed(params EntityError[] errors)
        {
            var result = new EntityResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   $"Failed: {string.Join(", ", Errors.Select(x => x.Code).ToList())}";
        }
    }
}
