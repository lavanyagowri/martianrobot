
using System.Linq;

namespace BusinessLayer.Domain
{
    public class Robot
    {
        private readonly Position m_currentPosition;

        public Robot(Position currentPosition)
        {
            m_currentPosition = currentPosition;
        }

        /// <summary>
        /// Robot will move to the specified direction if it does not fall of the border.
        /// </summary>
        /// <param name="p"></param>
        public bool MoveFoward(Plateau p)
        {
            int newX = m_currentPosition.X;
            int newY = m_currentPosition.Y;

            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    newY += 1;
                    break;
                case Direction.East:
                    newX += 1;
                    break;
                case Direction.South:
                    newY -= 1;
                    break;
                case Direction.West:
                    newX -= 1;
                    break;
            }
            
            //This detailed comparision is required to check if a robot was lost in the same postion before
            Constant c = new Constant { positionToAvoidX = m_currentPosition.X.ToString(), positionToAvoidY = m_currentPosition.Y.ToString(), positionToAvoidDirection = m_currentPosition.Direction.ToString() };
            Constant compared = PositionAvoid.positionsToAvoid.Where(o => o.positionToAvoidX == c.positionToAvoidX.ToString() && o.positionToAvoidY == c.positionToAvoidY && o.positionToAvoidDirection == c.positionToAvoidDirection).FirstOrDefault();
            if (compared == null)
            {
                if (IsInBounds(newX, newY, p.Length, p.Height))
                {
                    m_currentPosition.X = newX;
                    m_currentPosition.Y = newY;
                }
                else
                {
                    m_currentPosition.ErrorMessage = "LOST";
                    PositionAvoid.positionsToAvoid.Add(new Constant { positionToAvoidX = m_currentPosition.X.ToString(), positionToAvoidY = m_currentPosition.Y.ToString(), positionToAvoidDirection = m_currentPosition.Direction.ToString() });
                    return false;
                }
            }            
            return true;
        }

        /// <summary>
        /// Checks if the next movements of a robot will put the robot out of grid.
        /// </summary>
        public bool IsInBounds(int x, int y, int MaxX, int MaxY)
        {
            return x >= 0 && y >= 0 && x <= MaxX && y <= MaxY;
        }


        public Position GetCurrentPosition()
        {
            return m_currentPosition;
        }

        public void Rotate(Rotation direction)
        {
            switch (direction)
            {
                case Rotation.Left:
                    RotateLeft();
                    break;

                case Rotation.Right:
                    RotateRight();
                    break;
            }
        }

        private void RotateRight()
        {
            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.North;
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.North;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.South;
                    break;
            }
        }
    }
}
