namespace Fenit.Toolbox.Core.Response
{
    public class Response<T> : Response
    {
        public T Value { get; private set; }

        public void AddValue(T el)
        {
            Value = el;
        }
    }
}