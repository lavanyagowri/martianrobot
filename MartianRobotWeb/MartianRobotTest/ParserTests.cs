﻿using BusinessLayer.Domain;
using BusinessLayer.Parsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotTest
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase("N", Direction.North)]
        [TestCase("E", Direction.East)]
        [TestCase("W", Direction.West)]
        [TestCase("S", Direction.South)]
        [Test]
        public void Test_DirectionalParser_Parses_Correctly(string input, Direction output)
        {
            Assert.AreEqual(DirectionParser.Parse(input), output);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Move_Forward()
        {
            var results = CommandParser.Parse("f");
            Assert.AreEqual(results.First(), Command.MoveForward);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Turn_Left()
        {
            var results = CommandParser.Parse("l");
            Assert.AreEqual(results.First(), Command.TurnLeft);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Turns_Right()
        {
            var results = CommandParser.Parse("r");
            Assert.AreEqual(results.First(), Command.TurnRight);
        }

        [Test]
        public void Test_CommandParser_Parses_Correctly_Multiple_Commands()
        {
            var results = CommandParser.Parse("rlFlr");
            Assert.AreEqual(results[0], Command.TurnRight);
            Assert.AreEqual(results[1], Command.TurnLeft);
            Assert.AreEqual(results[2], Command.MoveForward);
            Assert.AreEqual(results[3], Command.TurnLeft);
            Assert.AreEqual(results[4], Command.TurnRight);
        }
    }
}
