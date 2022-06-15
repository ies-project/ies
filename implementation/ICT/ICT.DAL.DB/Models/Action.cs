using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Action class
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Primary key of Action
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Action
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the Action
        /// </summary>
        public string Description { get; set; }
        public ICollection<DeviceSubmittedAction> DeviceSubmittedActions { get; set; }

    }
}




