using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public ActionResult Index()
        {
            return View();
        }


       
        public ActionResult ViewPage1(string ID,string NAME,string AGE, string insert,string update,string delete,string ID_Del)
        {
            PeopleModel model = new PeopleModel
            {
                ID = ID,
                NAME = NAME,
                AGE = AGE,
                ID_Del = ID_Del
            };
            //中斷點↙
            if (insert == "1") 
            {
                model.CreatePplList(model.ID,model.NAME,model.AGE);
            }

            if(update == "1")
            {
                model.EditPplList(model.ID, model.NAME, model.AGE);
            }else if (update == "updatemono")
            {
                model.EditPplMono(model.ID, model.NAME, model.AGE);
            }

            if (delete == "1")
            {
                model.DeletePplList(model.ID);
            }else if (delete == "deletemono")
            {
                model.DeletePplMono(model.ID_Del);
            }
           
            //中斷點↙
            model.GetPeopleList();

           
            return View(model);
        }

        [HttpPost]
        public ActionResult ADD(string ID) {
            PeopleModel model = new PeopleModel();
            model.ID = ID;
            return View(model);//中斷點←
        }

        


    }
    
}