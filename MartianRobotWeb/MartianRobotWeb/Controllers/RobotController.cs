using BusinessLayer.Domain;
using BusinessLayer.Parsers;
using BusinessLayer.Services;
using MartianRobotWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartianRobotWeb.Controllers
{
    public class RobotController : Controller
    {
        private readonly INavigationService m_navigationService;

        public RobotController()
        {

        }

        public RobotController(INavigationService navigationService)
        {
            m_navigationService = navigationService;
        }

      

        public ActionResult Index()
        {
            return View();
        }
      
        /// <summary>
        /// Saves the size of the plateau.
        /// </summary>
        /// <param name="heightwidth"></param>
        /// <returns></returns>
        public ActionResult SubmitPlateau(string heightwidth)
        {
            string[] plateau = heightwidth.Split(' ');
            int width = Convert.ToInt32(plateau[0]);
            int height = Convert.ToInt32(plateau[1]);

            TempData["Plateau"] = new Plateau(width, height);
            ViewData.Model = new List<RobotModel>();
            return View();
        }

        public ActionResult AddRobot(string xydirection, string movements)
        {
            string[] splitDirection = xydirection.Split(' ');
            int x = Convert.ToInt32(splitDirection[0]);
            int y = Convert.ToInt32(splitDirection[1]);
            string direction = splitDirection[2];

            var robots = new List<RobotModel>();
            if (TempData["Robots"] != null)
            {
                robots = TempData["Robots"] as List<RobotModel>;
            }

            var position = new Position { X = x, Y = y, Direction = DirectionParser.Parse(direction) };
            var robot = new Robot(position);
            if (robots != null)
            {
                robots.Add(new RobotModel { Movements = movements, Robot = robot });

                TempData["Robots"] = ViewData.Model = robots;
            }

            return new ViewResult { ViewName = "SubmitPlateau", ViewData = ViewData };
        }

        /// <summary>
        /// Parses through each robot's commands and executes them.
        /// </summary>
        /// <returns></returns>
        public ActionResult StartExploration()
        {
            var results = new List<Position>();
            NavigationService nvgService = new NavigationService();
            PositionAvoid.positionsToAvoid = new List<Constant>();
            foreach (RobotModel model in (List<RobotModel>)TempData["Robots"])
            {               
                results.Add(nvgService.ExploreTerrain((Plateau)TempData["Plateau"], model.Robot, CommandParser.Parse(model.Movements)));
            }
       
            ViewData.Model = results;
            return View();
        }
    }
}
