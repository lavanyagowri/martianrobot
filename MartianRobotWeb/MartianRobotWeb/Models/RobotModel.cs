using BusinessLayer.Domain;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// stores basic data about the robot.
/// </summary>
namespace MartianRobotWeb.Models
{
    public class RobotModel
    {
           
        public Robot Robot;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter valid directions")]
        public string Movements;
    }
}