﻿using PhantomNet.Core;

namespace PhantomNet
{
    public class ErrorDescriber
    {
        public virtual GenericError DefaultError()
        {
            return new GenericError {
                Code = nameof(DefaultError),
                Description = Resources.DefaultError
            };
        }
    }
}
