namespace EComm_Store_API.Utilities
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int productCount, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductCount = productCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set;}
        public int ProductCount { get; set;}
        public IReadOnlyList<T> Data { get; set; }
    }
}