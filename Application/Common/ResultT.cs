namespace Application.Common
{
#nullable enable 
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }


        public TValue Value => IsSuccess
            ? _value! :
            throw new InvalidOperationException("The value of  a failure result can not be accessed. ");

        public static implicit operator Result<TValue?>(TValue? value) => Create(value);

        public static Result<TValue?> Failure(Error error) => new(default(TValue), false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
        public static Result<TValue> Create<TValue>(TValue value) =>
    value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    }
}