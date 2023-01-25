using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class PurchaseOrders : OrderHandler
    {
        public PurchaseOrders(int id, string description, string recipient) {
            setDescription(description);
            setID(id);
            setRecipient(recipient);
            setOrderStatus("Active");
        }
    }
}
