using BusinessLayer.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotTest
{
    [TestFixture]
    public class MovementTests
    {
        [Test]
        public void Test_Robot_Can_Move_Forward_One_Square_When_Facing_North()
        {
            var startPosition = new Position { Direction = Direction.North, X = 0, Y = 0 };
            var robot = new Robot(startPosition);
            robot.MoveFoward(new Plateau(10, 10));

            var newPosition = robot.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.North, X = 0, Y = 1 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Robot_Can_Move_Forward_One_Square_When_Facing_South()
        {
            var startPosition = new Position { Direction = Direction.South, X = 0, Y = 1 };
            var robot = new Robot(startPosition);
            robot.MoveFoward(new Plateau(10, 10));
            var newPosition = robot.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.South, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Robot_Can_Move_Forward_One_Square_When_Facing_East()
        {
            var startPosition = new Position { Direction = Direction.East, X = 0, Y = 0 };
            var robot = new Robot(startPosition);
            robot.MoveFoward(new Plateau(10, 10));

            var newPosition = robot.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.East, X = 1, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }

        [Test]
        public void Test_Robot_Can_Move_Forward_One_Square_When_Facing_West()
        {
            var startPosition = new Position { Direction = Direction.West, X = 1, Y = 0 };
            var robot = new Robot(startPosition);
            robot.MoveFoward(new Plateau(10, 10));

            var newPosition = robot.GetCurrentPosition();
            var expectedPosition = new Position { Direction = Direction.West, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }


    }
}
