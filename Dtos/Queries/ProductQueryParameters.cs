namespace SmartInventory.Api.Dtos.Queries
{
    public sealed class ProductQueryParameters
    {
        public string? Search {  get; set; }
        public decimal ? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
