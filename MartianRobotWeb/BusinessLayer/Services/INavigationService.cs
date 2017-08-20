using BusinessLayer.Domain;
using System.Collections.Generic;

/// <summary>
/// Using an interface here, lets us be able to broaden the program when needed.
/// It specifies the actions that can be done on Mars.
/// </summary>

namespace BusinessLayer.Services
{
    public interface INavigationService
    {
        Position ExploreTerrain(Plateau plateau, Robot robot, List<Command> commands);
    }
}