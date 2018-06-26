using SpartanTestSF.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpartanTestSF.Controllers
{
    public class WebAPIController : ApiController
    {
        /// <summary>
        /// Web API to search for equipment via Unit Number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SerialisedEquipment> GetEquipmentByUnitNo(string value)
        {
            List<SerialisedEquipment> retvar = SpartanTestSF.Core.EquipmentManager.GetEquipmentItemsByUnitNo(value);

            return retvar;
        }

        /// <summary>
        /// Web API to get all equipment
        /// </summary>
        /// <returns></returns>
        public List<SerialisedEquipment> GetAllEquipment()
        {
           EquipmentList equipmentItems = SpartanTestSF.Core.EquipmentManager.GetAllEquipmentItems();
           List<SerialisedEquipment> retvar = equipmentItems.SerialisedEquipment;
           return retvar;
        }

        /// <summary>
        /// Web API to search for equipment via Item No
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SerialisedEquipment> GetEquipmentByItemNo(string value)
        {
            List<SerialisedEquipment> retvar = SpartanTestSF.Core.EquipmentManager.GetEquipmentItemsByItemNo(value);
            return retvar;
        }

    }
}