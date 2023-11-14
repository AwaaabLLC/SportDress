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
        public int addProductImage(Images productImage);
        public List<Images> getProductImages();
        public List<Products> getProducts();
        public List<ProductSizes> getProductSize();
        public List<ProductTypes> getProductType();
    }
}
