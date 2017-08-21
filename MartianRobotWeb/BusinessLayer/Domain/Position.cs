/// <summary>
/// Stores the exact location of the robots during traversal on Mars.
/// </summary>

namespace BusinessLayer.Domain
{
    public class Position
    {
        public int X;
        public int Y;
        public Direction Direction;
        public string ErrorMessage;

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            var comparingObjet = (Position)obj;

            return comparingObjet.Direction == Direction &&
                   (comparingObjet.X == X && (comparingObjet.Y == Y));
        }
    }
}