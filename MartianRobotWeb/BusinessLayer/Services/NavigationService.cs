using BusinessLayer.Domain;
using System;
using System.Collections.Generic;


namespace BusinessLayer.Services
{
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Calls appropriate methods to move robot to follow its commands
        /// </summary>
        public Position ExploreTerrain(Plateau plateau, Robot robot, List<Command> commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case Command.MoveForward:
                        robot.MoveFoward(plateau);
                        break;
                    case Command.TurnLeft:
                        robot.Rotate(Rotation.Left);
                        break;
                    case Command.TurnRight:
                        robot.Rotate(Rotation.Right);
                        break;
                }
            }

            return robot.GetCurrentPosition();
        }
    }
}
