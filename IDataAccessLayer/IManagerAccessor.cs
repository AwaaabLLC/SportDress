using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace IDataAccessLayer
{
    public interface IManagerAccessor
    {
        List<Images> selectProductImages();
        List<Products> selectProducts();
        List<ProductSizes> selectProductSizes();
        List<ProductTypes> selectProductTypes();
    }
}
