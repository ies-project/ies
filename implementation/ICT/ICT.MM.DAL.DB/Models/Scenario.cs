using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace ICT.MM.DAL.DB.Models {
    /// <summary>
    /// 
    /// </summary>
    public class Scenario {

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(64)]
        public String Name { get; set; }

        [Required]
        [StringLength(64)]
        public String Description { get; set; }

    }
}
