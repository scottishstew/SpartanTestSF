using Newtonsoft.Json;
using SpartanTestSF.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpartanTestSF.Core
{
    public class EquipmentManager
    {
        private static EquipmentList AllEquipmentItems;

        /// <summary>
        /// Gets All Equipment items to display on screen, deserializes json and returns objects
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static void PopulateEquipmentItems(string json)
        {
            //take in JSON data and convert to objects
            AllEquipmentItems = DeSerializeJSON(json);
        }

        public static EquipmentList GetAllEquipmentItems()
        {
            return AllEquipmentItems;
        }

        /// <summary>
        /// Deserializes JSON into Business Objects
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static EquipmentList DeSerializeJSON(string json)
        {
            EquipmentList retvar = new EquipmentList();

            try
            {
                retvar = JsonConvert.DeserializeObject<EquipmentList>(json);

                foreach (var equip in retvar.SerialisedEquipment)
                {
                    var equipType = retvar.EquipmentType.Where(i => i.Id == equip.EquipmentTypeId).SingleOrDefault();

                    //assign equipment type to equipment object if returned
                    if (equipType != null)
                    {
                        equip.EquipmentType = equipType;
                    }
                }
                return retvar;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets Equipment by the Equipments unique identifier (Unit Number)
        /// </summary>
        /// <param name="unitNo"></param>
        /// <returns></returns>
        public static List<SerialisedEquipment> GetEquipmentItemsByUnitNo(string unitNo)
        {
            List<SerialisedEquipment> retvar = new List<SerialisedEquipment>();

            if (AllEquipmentItems.SerialisedEquipment != null)
            {
                //query by unit no
                retvar = AllEquipmentItems.SerialisedEquipment.Where(i => i.ExternalId == unitNo).ToList();
            }

            return retvar;

        }

        /// <summary>
        /// Gets Equipment by the Equipment Type Item No
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
        public static List<SerialisedEquipment> GetEquipmentItemsByItemNo(string itemNo)
        {
            List<SerialisedEquipment> retvar = new List<SerialisedEquipment>();

            if (AllEquipmentItems.SerialisedEquipment != null)
            {
                //query by item no
                retvar = AllEquipmentItems.SerialisedEquipment.Where(i => i.EquipmentType.ExternalId == itemNo).ToList();
            }

            return retvar;

        }
    }
}