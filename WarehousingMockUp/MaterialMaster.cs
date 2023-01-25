using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousingMockUp
{
    /// <summary>
    /// Standin for a master table representing every item in the warehouse.
    /// </summary>
    internal class MaterialMaster
    {
        private int masterID;
        private string name;
        private string description;
        private bool isComponent;

        private void setMasterID (int masterID)
        {
            this.masterID = masterID;
        }

        private void setName (string name)
        {
            this.name = name;
        }

        private void setDescription (string description) 
        { 
            this.description = description;
        }

        private void setComponent (bool isComponent)
        {
            this.isComponent = isComponent;
        }

        public int getMasterID
        {
            get { return this.masterID; }
        }

        public string getName
        {
            get { return this.name; }
        }

        public string getDescription
        {
            get { return this.description; }
        }

        public bool componentStatus
        {
            get { return this.componentStatus; }
        }

        public MaterialMaster (int id, string name, string description, bool isComponent)
        {
            setDescription(description);
            setMasterID(id);
            setName(name);
            setComponent(isComponent);
        } 
    }
}
