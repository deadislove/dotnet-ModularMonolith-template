﻿namespace ModularMonolith.Template.SharedKernel.Exceptions
{
    public abstract class BaseException: Exception
    {
        public virtual string Code { get; } = "error";

        protected BaseException(string message) : base(message) { }
        protected BaseException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
