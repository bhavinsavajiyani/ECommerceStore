using EComm_Store_Core.Entities;

namespace EComm_Store_Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productParams) : base(
            p => (
                (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandID.HasValue || p.ProductBrandID == productParams.BrandID) &&
                (!productParams.TypeID.HasValue || p.ProductTypeID == productParams.TypeID)
            )
        )
        {
            
        }
    }
}