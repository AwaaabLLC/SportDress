using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogicLayer
{
    public interface IManagerManager
    {
        List<Images> getProductImages();
        List<Products> getProducts();
        List<ProductSizes> getProductSize();
        List<ProductTypes> getProductType();
    }
}
