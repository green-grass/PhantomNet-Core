using PhantomNet.Core.Properties;

namespace PhantomNet
{
    public class ErrorDescriber
    {
        public virtual GenericError DefaultError()
        {
            return new GenericError {
                Code = nameof(DefaultError),
                Description = Strings.DefaultError
            };
        }
    }
}
