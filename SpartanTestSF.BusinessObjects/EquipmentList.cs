using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanTestSF.BusinessObjects
{
    public class EquipmentList
    {
        public List<SerialisedEquipment> SerialisedEquipment { get; set; }
        public List<EquipmentType> EquipmentType { get; set; }
    }

}
