using BusinessLayer.Domain;
using BusinessLayer.Services;
using MartianRobotWeb.Controllers;
using MartianRobotWeb.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotTest
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<INavigationService> m_navigationService;

        [TestFixtureSetUp]
        public void Setup()
        {
            m_navigationService = new Mock<INavigationService>();
        }

        [Test]
        public void Test_Robot_Controller_Add_Robot_Persisted()
        {
            RobotController controller = new RobotController(m_navigationService.Object);

            controller.AddRobot("1 2", "FRF");

            Assert.IsNotNull(controller.TempData["Robots"]);
            List<RobotModel> list = (List<RobotModel>)controller.TempData["Robots"];


            Assert.IsTrue(list.Count == 1);
            RobotModel model = list[0];
            Assert.IsTrue(model.Movements.ToCharArray().First() == 'M');
            Assert.IsTrue(model.Robot.GetCurrentPosition().Direction == Direction.North);
            Assert.IsTrue(model.Robot.GetCurrentPosition().X == 1);
            Assert.IsTrue(model.Robot.GetCurrentPosition().Y == 2);
        }

        [Test]
        public void Test_Robot_Controller_Add_Plateau_Persisted()
        {
            RobotController controller = new RobotController(m_navigationService.Object);
            controller.SubmitPlateau("1 2");
            Assert.IsNotNull(controller.TempData["Plateau"]);
            Plateau plateau = (Plateau)controller.TempData["Plateau"];
            Assert.IsTrue(plateau.Length == 2);
            Assert.IsTrue(plateau.Height == 1);
        }

        /* Should only test one thing really */
        [Test]
        public void Test_Robot_Controller_Start_Exploration_Calls_Navigation_Service_For_Each_Robot_And_Sets_View_Data_Model()
        {
            RobotController controller = new RobotController(m_navigationService.Object);
            List<RobotModel> robots = new List<RobotModel>();
            RobotModel robot1 = new RobotModel
            {
                Movements = "M",
                Robot = new Robot(new Position() { Direction = Direction.North, X = 0, Y = 0 })
            };

            RobotModel robot2 = new RobotModel
            {
                Movements = "M",
                Robot = new Robot(new Position() { Direction = Direction.North, X = 1, Y = 0 })
            };

            robots.Add(robot1);
            robots.Add(robot2);

            controller.TempData["Robots"] = robots;
            controller.TempData["Plateau"] = new Plateau(1, 2);
            controller.StartExploration();
            m_navigationService.Verify(n => n.ExploreTerrain(It.IsAny<Plateau>(), It.IsAny<Robot>(), It.IsAny<List<Command>>()), Times.Exactly(2));
            Assert.IsNotNull(controller.ViewData.Model);
        }
    }
}
