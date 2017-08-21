/// <summary>
/// Stores the positions where the robots would get lost. So that in future robots would not get lost in the same position.
/// </summary>

namespace BusinessLayer.Domain
{
    public class Constant
    {
        public Constant()
        { }
        public string positionToAvoidX {get;set;}
        public string positionToAvoidY { get; set; }
        public string positionToAvoidDirection { get; set; }
    }
}
