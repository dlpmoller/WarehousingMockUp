using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class ComponentStock : StockHandler
    {
        public ComponentStock(int i, MaterialMaster masterItem, int startStock)
        {

                    setItemID(i);
                    setMasterID(masterItem.getMasterID);
                    AddToAvailableStock(0);
        }
    }
}
