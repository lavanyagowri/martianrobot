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
    public class DirectionalTests
    {
        [TestCase(Direction.West, Rotation.Left, Direction.South)]
        [TestCase(Direction.West, Rotation.Right, Direction.North)]
        [TestCase(Direction.East, Rotation.Left, Direction.North)]
        [TestCase(Direction.East, Rotation.Right, Direction.South)]
        [TestCase(Direction.South, Rotation.Left, Direction.East)]
        [TestCase(Direction.South, Rotation.Right, Direction.West)]
        [TestCase(Direction.North, Rotation.Left, Direction.West)]
        [TestCase(Direction.North, Rotation.Right, Direction.East)]
        [Test]
        public void Test_Robot_Can_Rotate_90_Degrees(Direction startDirection, Rotation rotateDirection, Direction endDirection)
        {
            var startPosition = new Position { Direction = startDirection, X = 0, Y = 0 };
            var robot = new Robot(startPosition);

            robot.Rotate(rotateDirection);

            var newPosition = robot.GetCurrentPosition();
            var expectedPosition = new Position { Direction = endDirection, X = 0, Y = 0 };

            Assert.AreEqual(newPosition, expectedPosition);
        }
    }
}
