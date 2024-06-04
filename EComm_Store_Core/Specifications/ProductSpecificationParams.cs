namespace EComm_Store_Core.Specifications
{
    public class ProductSpecificationParams
    {
        private const int _maxPageSize = 50;
        private int _pageSize = 6;
        private string _search;

        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }

        public int? BrandID { get; set; }
        public int? TypeID { get; set; }
        public string Sort { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}