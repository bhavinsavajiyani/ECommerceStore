using EComm_Store_Core.Entities;

namespace EComm_Store_Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductsWithBrandsAndTypesSpecification(int id) : base(product => product.ID == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}