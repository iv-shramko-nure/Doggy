namespace Web
{
  public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }

        public T data { get; set; }
    }
}
