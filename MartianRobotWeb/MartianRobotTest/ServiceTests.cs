using BusinessLayer.Domain;
using BusinessLayer.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotTest
{
    [TestFixture]
    public class ServiceTests
    {

        [Test]
        public void Test_NavigationService_Moves_Robot_Correctly_Forward_One_Square()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();
            commands.Add(Command.MoveForward);
            var startPosition = new Position { Direction = Direction.North, X = 0, Y = 0 };
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 1 };
            var robot = new Robot(startPosition);

            Position position = service.ExploreTerrain(plateau, robot, commands);
            Assert.AreEqual(position, expectedPosition);
        }

        [Test]
        public void Test_NavigationService_Moves_Robot_Correctly_Forward_Multiple_Square()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.North, X = 0, Y = 0 };
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 5 };
            var robot = new Robot(startPosition);

            Position position = service.ExploreTerrain(plateau, robot, commands);
            Assert.AreEqual(position, expectedPosition);
        }


        [Test]
        public void Test_NavigationService_Moves_Robot_Correctly_Forward_Multiple_Square_In_Multiple_Directions()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.North, X = 3, Y = 0 };
            var expectedPosition = new Position { Direction = Direction.North, X = 1, Y = 2 };
            var robot = new Robot(startPosition);

            Position position = service.ExploreTerrain(plateau, robot, commands);
            Assert.AreEqual(position, expectedPosition);
        }

        [Test]
        public void Test_NavigationService_Moves_Robot_Correctly_According_To_Supplied_Test_Data_One()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnLeft);

            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.North, X = 1, Y = 2 };
            var expectedPosition = new Position { Direction = Direction.North, X = 1, Y = 3 };
            var robot = new Robot(startPosition);

            Position position = service.ExploreTerrain(plateau, robot, commands);
            Assert.AreEqual(position, expectedPosition);
        }


        [Test]
        public void Test_NavigationService_Moves_Robot_Correctly_According_To_Supplied_Test_Data_Two()
        {
            INavigationService service = new NavigationService();
            Plateau plateau = new Plateau(5, 5);
            List<Command> commands = new List<Command>();

            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);
            commands.Add(Command.TurnRight);
            commands.Add(Command.TurnRight);
            commands.Add(Command.MoveForward);

            var startPosition = new Position { Direction = Direction.East, X = 3, Y = 3 };
            var expectedPosition = new Position { Direction = Direction.East, X = 5, Y = 1 };
            var robot = new Robot(startPosition);

            Position position = service.ExploreTerrain(plateau, robot, commands);
            Assert.AreEqual(position, expectedPosition);
        }
    }
}
