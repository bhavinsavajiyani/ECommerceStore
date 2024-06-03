using System.Security.Cryptography;
using EComm_Store_Core.Entities;

namespace EComm_Store_Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification(string sort, int? brandID, int? typeID) : base(
            p => (
                (!brandID.HasValue || p.ProductBrandID == brandID) &&
                (!typeID.HasValue || p.ProductTypeID == typeID)
            )
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithBrandsAndTypesSpecification(int id) : base(product => product.ID == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}