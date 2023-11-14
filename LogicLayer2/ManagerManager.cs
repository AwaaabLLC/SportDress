using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;
using IDataAccessLayer;
using ILogicLayer;

namespace LogicLayer
{
    public class ManagerManager : IManagerManager
    {
        private IManagerAccessor managerAccessor = new ManagerAccessor();

        public int addProductImage(Images productImage)
        {
            int result = 0;
            result = managerAccessor.insertProductImage(productImage);
            return result;
        }

        public List<Images> getProductImages()
        {
            List<Images> images = new List<Images>();
            images = managerAccessor.selectProductImages();
            return images;
        }

        public List<Products> getProducts()
        {
            List<Products> products = new List<Products>();
            products = managerAccessor.selectProducts();
            return products;
        }

        public List<ProductSizes> getProductSize()
        {
            List<ProductSizes> productSizes = new List<ProductSizes>();
            productSizes = managerAccessor.selectProductSizes();
            return productSizes;
        }

        public List<ProductTypes> getProductType()
        {
            List<ProductTypes> productTypes = new List<ProductTypes>();
            productTypes = managerAccessor.selectProductTypes();
            return productTypes;
        }
    }
}
