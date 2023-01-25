using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class OrderHandler
    {
        private int orderID;
        private string orderRecipient;
        private string orderDescription;
        private List<ProductStock> productsOrdered;
        private List<ComponentStock> componentsOrdered;
        private string orderStatus;

        public virtual void setID(int id) { this.orderID = id; }
        public virtual void setRecipient(string recipient) { this.orderRecipient = recipient; }
        public virtual void setDescription(string description) { this.orderDescription = description; }
        public virtual void setOrderStatus(string status) { this.orderStatus = status; }
        public virtual int getID() { return this.orderID; }
        public virtual string getRecipient() { return this.orderRecipient; }
        public virtual string getDescription() { return this.orderDescription; }
        public virtual string getStatus() { return this.orderStatus; }
        public virtual List<ProductStock> getOrderedProducts() { return this.productsOrdered; }
        public virtual List<ComponentStock> getOrderedComponents() { return this.componentsOrdered; }

        //todo: Expand functionality to allow for editing of orders
        public virtual void addToOrder(Object item)
        {
            dynamic stock;
            int index = 0;

            try
            {
                stock = (ProductStock)item;
                index = productsOrdered.FindLastIndex(x => x.getItemID == stock.getItemID);
                if (productsOrdered == null)
                {
                    productsOrdered = new List<ProductStock>();
                }
                    productsOrdered.Add(stock);
            }
            catch (Exception)
            {
                stock = (ComponentStock)item;
                index = productsOrdered.FindLastIndex(x => x.getItemID == stock.getItemID);
                if (componentsOrdered == null)
                {
                    componentsOrdered = new List<ComponentStock>();
                }
                componentsOrdered.Add(stock);
            }
        }

        public virtual void addToOrder(ProductStock stock)
        {
            addToOrder(stock);
        }
        public virtual void addToOrder(ComponentStock stock)
        {
            addToOrder(stock);
        }


    }
}
