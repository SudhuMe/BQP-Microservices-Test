using System;

namespace Abstraction;

public abstract class DomainException : Exception
{
    public int ExceptionCode { get; }
    public DomainException(string message, int exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }
}