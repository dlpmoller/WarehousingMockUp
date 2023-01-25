using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class ProductionHandler
    {
        private int recipeID;
        private int productID;
        private int[,] componentsNeeded;
        public int[,] getRecipe() { return componentsNeeded; }
        public int getProduct() { return productID; }
        public int getID() { return recipeID; }

        public ProductionHandler(int id, int[,] componentRequirements, int product)
        {
            this.recipeID = id;
            this.componentsNeeded = componentRequirements;
            this.productID = product;
        }
    }
}
