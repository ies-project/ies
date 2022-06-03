using System.ComponentModel.DataAnnotations;

namespace ICT.MM.DAL.DB.Models {

    public class DeviceTypes {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        public string Description { get; set; }

    }

}


