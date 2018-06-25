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
            List<SerialisedEquipment> equipmentItems = SpartanTestSF.Core.EquipmentManager.GetEquipmentItemsByUnitNo(value);

            return equipmentItems;
        }

        /// <summary>
        /// Web API to search for equipment via Item No
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SerialisedEquipment> GetEquipmentByItemNo(string value)
        {
            List<SerialisedEquipment> equipmentItems = SpartanTestSF.Core.EquipmentManager.GetEquipmentItemsByItemNo(value);
            return equipmentItems;
        }

    }
}