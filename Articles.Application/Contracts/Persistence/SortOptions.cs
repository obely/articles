namespace Articles.Application.Contracts.Persistence
{
    public class SortOptions
    {
        public string SortKey { get; set; }
        public bool Ascending { get; set; }
        public bool IsEmpty => string.IsNullOrEmpty(SortKey);

        public SortOptions()
        {
            Ascending = true;
        }
    }
}
