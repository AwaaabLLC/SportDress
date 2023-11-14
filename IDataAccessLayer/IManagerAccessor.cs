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
        public int insertProductImage(Images productImage);
        public List<Images> selectProductImages();
        public List<Products> selectProducts();
        public List<ProductSizes> selectProductSizes();
        public List<ProductTypes> selectProductTypes();
    }
}
