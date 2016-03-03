namespace PhantomNet
{
    public class ErrorDescriber
    {
        public virtual EntityError DefaultError()
        {
            return new EntityError {
                Code = nameof(DefaultError),
                Description = Resources.DefaultError
            };
        }
    }
}
