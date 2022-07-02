using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class UpdateAreaRequestDTO {
        public int Id { get; set; }
        public int Id_Building { get; set; }
        public int Id_Type { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public int NumFireBalls { get; set; }
        public int NumSpringles { get; set; }
        public int NumBocasSingulares { get; set; }
        public int NumBocasSiameses { get; set; }
    }
}
