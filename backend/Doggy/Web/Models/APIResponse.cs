namespace Web.Models
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }

        public T data { get; set; }
    }

    public class APIResponse
    {
        public bool IsSuccess { get; set; }
    }
}
