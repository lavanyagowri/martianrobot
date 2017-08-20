using BusinessLayer.Domain;
using System.Collections.Generic;

/// <summary>
/// Parses the commands to program friendly variables.
/// </summary>
namespace BusinessLayer.Parsers
{
    public static class CommandParser
    {
        public static List<Command> Parse(string movements)
        {
            var commands = new List<Command>();
            foreach (char c in movements.ToUpper())
            {
                switch (c)
                {
                    case 'L':
                        commands.Add(Command.TurnLeft);
                        break;
                    case 'R':
                        commands.Add(Command.TurnRight);
                        break;
                    case 'F':
                        commands.Add(Command.MoveForward);
                        break;
                }
            }

            return commands;
        }
    }
}
