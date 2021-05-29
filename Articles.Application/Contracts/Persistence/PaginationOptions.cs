namespace Articles.Application.Contracts.Persistence
{
    public class PaginationOptions
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public bool IsEmpty => Page == 0 && Size == 0;
    }
}
