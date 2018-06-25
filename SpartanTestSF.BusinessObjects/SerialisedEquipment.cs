using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanTestSF.BusinessObjects
{
    public class SerialisedEquipment
    {
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public int MeterReading { get; set; }
    }
}
