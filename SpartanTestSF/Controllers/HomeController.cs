using SpartanTestSF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpartanTestSF.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Called when website is loaded, gets JSON data and stores them as objects in the Core project
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            HomeModel myModel = new HomeModel();

            //load JSON file and read text
            string path = Path.Combine(Server.MapPath("~/Content"), "EquipmentData.json");
            string json = System.IO.File.ReadAllText(path);

            //create list of equipment objects using JSON file
            SpartanTestSF.Core.EquipmentManager.PopulateEquipmentItems(json);

            //add equipment objects to model and pass it to view
            myModel.EquipmentItems = SpartanTestSF.Core.EquipmentManager.GetAllEquipmentItems();

            return View(myModel);
        }
    }
}