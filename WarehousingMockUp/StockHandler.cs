using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    internal class StockHandler
    {
        private int itemID;
        private int mID;
        private int stock;

        public virtual void setItemID(int itemID)
        {
            this.itemID = itemID;
        }

        public virtual int getItemID
        {
            get { return this.itemID; }
        }

        public virtual void setMasterID(int masterID)
        {
            this.mID = masterID;
        }

        public virtual int getMasterID
        {
            get { return this.mID; }
        }

        public virtual void AddToAvailableStock(int stockAddition)
        {
            this.stock += stockAddition;
        }

        public virtual bool SubtractFromStock(int stockSubtraction)
        {
            bool bretval = false;
            
            if (this.stock - stockSubtraction >= 0) {
                this.stock-= stockSubtraction;
                bretval = true;
            }

            return bretval;
        }

        public virtual int getStock
        {
            get { return this.stock; }
        }

        //todo: re-do this
        /// <summary>
        /// Returns item names
        /// </summary>
        /// <param name="masterList"></param>
        /// <returns></returns>
        public virtual string getItemName(List<MaterialMaster> masterList)
        {
            foreach (MaterialMaster item in masterList)
            {
                if (mID == item.getMasterID)
                {
                    return item.getName;
                }
            }
            return "Item does not exist";
        }

        //todo: Re-do this
        /// <summary>
        /// Returns item descriptions
        /// </summary>
        /// <param name="masterList"></param>
        /// <returns></returns>
        public virtual string getItemDescription(List<MaterialMaster> masterList)
        {
            foreach (MaterialMaster item in masterList)
            {
                if (mID == item.getMasterID)
                {
                    return item.getDescription;
                }
            }
            return "Item does not exist";
        }
    }
}
