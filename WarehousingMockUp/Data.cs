using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class Data
    {
        private List<MaterialMaster> itemList;
        private List<ProductStock> productStockList;
        private List<ComponentStock> componentStockList;
        private List<PurchaseOrders> purchaseOrders;
        private List<SalesOrders> salesOrders;
        private List<ProductionOrders> productionOrders;
        private List<ProductionHandler> recipeList;

        public Data()
        {
            itemList = new List<MaterialMaster>();
            productStockList = new List<ProductStock>();
            componentStockList = new List<ComponentStock>();
            purchaseOrders = new List<PurchaseOrders>();
            salesOrders = new List<SalesOrders>();
            productionOrders = new List<ProductionOrders>();
            recipeList = new List<ProductionHandler>();
        }

        /// <summary>
        /// Adds a master reference of an item, a base component for the inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddToMasterList (MaterialMaster item)
        {
            int index = itemList.FindLastIndex(listItem => listItem.getMasterID == item.getMasterID);

            if (index == -1)
            {
                itemList.Add(item);
            }
            else
            {
                itemList[index] = item;
            }
        }

        public List<MaterialMaster> getMasterList()
        {
            return itemList;
        }

        public MaterialMaster getMasterReference(int itemID)
        {
            return itemList[itemID];
        }

        public List<ProductStock> getProductList()
        {
            return productStockList;
        }

        public List<ComponentStock> getComponentStockList()
        {
            return componentStockList;
        }

        public ProductStock getProduct(int itemID)
        {
            return productStockList[itemID];
        }

        public ComponentStock GetComponent(int itemID)
        {
            return componentStockList[itemID];
        }

        /// <summary>
        /// Adds a recipe for production orders to add components with
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="product"></param>
        /// <param name="componentsNeeded"></param>
        public void AddToRecipeList(int productionId, int product, int[,] componentsNeeded)
        {
            recipeList.Add(new ProductionHandler(productionId, componentsNeeded, product));
        }

        public ProductionHandler getRecipe(int id) { return recipeList[id]; }

        //todo: refactor this method ala OrderHandler's addToOrder
        /// <summary>
        /// Adds to stock, dependent on whether it's a component or not.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isComponent"></param>
        private void AddToStockList(Object item, bool isComponent)
        {
            int index;
            int masterIndex;
            ComponentStock componentItem = null;
            ProductStock productItem = null;

            if (isComponent)
            {
                componentItem = (ComponentStock)item;
                index = componentStockList.FindLastIndex(listItem => listItem.getItemID == componentItem.getItemID);
                masterIndex = itemList.FindLastIndex(listItem => listItem.getMasterID == componentItem.getMasterID);
            }
            else
            {
                productItem = (ProductStock)item;
                index = productStockList.FindLastIndex(listItem => listItem.getItemID == productItem.getItemID);
                masterIndex = itemList.FindLastIndex(listItem => listItem.getMasterID == productItem.getMasterID);
            }

            if (index == -1)
            {
                if (masterIndex > -1)
                {
                    if (isComponent)
                    {
                        componentStockList.Add((ComponentStock)item);
                    }
                    else
                    {
                        productStockList.Add(productItem);
                    }
                }
                else
                {
                    Console.WriteLine("Item does not exist.");
                }

            }
            else
            {
                
                if (isComponent)
                {
                    if (componentItem.getItemName == componentStockList[index].getItemName)
                    {
                        componentStockList[index].AddToAvailableStock(componentItem.getStock);
                    }
                    else
                    {
                        componentStockList[index] = componentItem;
                    }
                }
                else
                {
                    if (productItem.getItemName == productStockList[index].getItemName)
                    {
                        productStockList[index].AddToAvailableStock(productItem.getStock);
                    }
                    else
                    {
                        productStockList[index] = productItem;
                    }
                }
            }
        }

        /// <summary>
        /// Overload for AddToStockList for products
        /// </summary>
        /// <param name="item"></param>
        public void AddToStockList(ProductStock item)
        {
            AddToStockList(item, false);
        }

        /// <summary>
        /// Overload for AddToStockList for components
        /// </summary>
        /// <param name="item"></param>
        public void AddToStockList(ComponentStock item)
        {
            AddToStockList(item, true);
        }

        /// <summary>
        /// Adds order to the order queue
        /// </summary>
        /// <param name="productionOrder"></param>
        /// <param name="purchaseOrder"></param>
        /// <param name="salesOrder"></param>
        public void AddOrder(ProductionOrders? productionOrder, PurchaseOrders? purchaseOrder, SalesOrders? salesOrder)
        {
            dynamic order;

            if (productionOrder != null)
            {
                productionOrders.Add(productionOrder);
            }
            else if (purchaseOrder != null)
            {
                purchaseOrders.Add(purchaseOrder);
            }
            else if (salesOrder != null)
            {
                salesOrders.Add(salesOrder);
            }
        }

        /// <summary>
        /// Adds product to an order's list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="orderType"></param>
        public void AddProductToOrder(int id, ProductStock product, string orderType)
        {
            switch (orderType)
            {
                case "purchase":
                    GetSinglePurchaseOrder(id).addToOrder(product);
                    break;
                case "production":
                    GetSingleProductionOrder(id).addToOrder(product);
                    break;
                case "sale":
                    GetSingleSalesOrder(id).addToOrder(product);
                    break;
            }
        }

        /// <summary>
        /// Adds component to an order's list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="component"></param>
        /// <param name="orderType"></param>
        public void AddComponentToOrder(int id, ComponentStock component, string orderType)
        {
            switch (orderType)
            {
                case "purchase":
                    GetSinglePurchaseOrder(id).addToOrder(component);
                    break;
                case "production":
                    GetSingleProductionOrder(id).addToOrder(component);
                    break;
                case "sale":
                    GetSingleSalesOrder(id).addToOrder(component);
                    break;
            }
        }

        //todo: needs refactoring
        /// <summary>
        /// Returns specified production order list
        /// </summary>
        /// <returns></returns>
        public List<ProductionOrders> GetProductionOrderList()
        {
            return productionOrders;
        }

        /// <summary>
        /// Returns specified production order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductionOrders GetSingleProductionOrder(int id)
        {
            return productionOrders[id];
        }

        /// <summary>
        /// Returns sales order list
        /// </summary>
        /// <returns></returns>
        public List<SalesOrders> GetSalesOrderList()
        {
            return salesOrders;
        }

        /// <summary>
        /// Returns specified sales order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SalesOrders GetSingleSalesOrder(int id)
        {
            return salesOrders[id];
        }

        /// <summary>
        /// Returns purchase order list
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrders> GetPurchaseOrderList()
        {
            return purchaseOrders;
        }

        /// <summary>
        /// Returns specified purchase order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PurchaseOrders GetSinglePurchaseOrder(int id)
        {
            return purchaseOrders[id];
        }

        //todo: automatically create production order if products are insufficient, or automatically create purchase order if components are insufficient
        /// <summary>
        /// Compares order with the inventory stock, subtracting the stock if they are sufficient
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="orderType"></param>
        public void CompleteOrder(int orderID, string orderType)
        {
            dynamic order;
            bool sufficientStock;

            switch (orderType)
            {
                case "purchase":
                    order = GetSinglePurchaseOrder(orderID);
                    break;
                case "production":
                    order = GetSingleProductionOrder(orderID);
                    break;
                case "sale":
                    order = GetSingleSalesOrder(orderID);
                    break;
                default:
                    order = new OrderHandler();
                    break;
            }

            if (!orderType.Equals("purchase"))
            {
                if (order.getOrderedProducts().Count > 0)
                {
                    sufficientStock = true;
                    for (int i = 0; i < 2; i++)
                    {
                        if (!sufficientStock)
                        {
                            break;
                        }
                        foreach (ProductStock product in order.getOrderedProducts())
                        {
                            if (productStockList[product.getItemID].getStock >= product.getStock)
                            {
                                if (i > 0)
                                {
                                    productStockList[product.getItemID].SubtractFromStock(product.getStock);
                                }
                            }
                            else
                            {
                                sufficientStock = false;
                                break;
                            }
                        }
                    }
                }

                if (order.getOrderedComponents().Count > 0)
                {
                    sufficientStock = true;
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (ComponentStock components in order.getOrderedComponents())
                        {
                            if (componentStockList[components.getItemID].getStock >= components.getStock)
                            {
                                if (i > 0)
                                {
                                    componentStockList[components.getItemID].SubtractFromStock(components.getStock);
                                }
                            }
                            else
                            {
                                sufficientStock = false; 
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
