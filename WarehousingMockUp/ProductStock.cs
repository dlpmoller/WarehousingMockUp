using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class ProductStock : StockHandler
    {
        public ProductStock(int i, MaterialMaster masterItem, int startStock)
        {
                    setItemID(i);
                    setMasterID(masterItem.getMasterID);
                    AddToAvailableStock(startStock);
        }
    }
}
