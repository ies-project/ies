using ICT.Core.DTO;
using ICT.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.BLL {
    public class FireHoseReelBLL {
        public static void InsertFireHoseReelBLL(InsertFireHoseReelRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.FireHoseReels.Find(dto.Id) == null)
                {
                    FireHoseReel fhr = new FireHoseReel();
                    fhr.Id = dto.Id;
                    fhr.Id_Area = dto.Id_Area;
                    fhr.Type = dto.Type;
                    fhr.Description = dto.Description;
                    fhr.ManufacturedDate = dto.ManufacturedDate;
                    fhr.LastMaintenanceDate = dto.LastMaintenanceDate;
                    fhr.MaintenanceDueDate = dto.MaintenanceDueDate;

                    iCTDbContext.FireHoseReels.Add(fhr);

                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void DeleteFireHoseReelBLL(DeleteFireHoseReelRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.FireHoseReels.Find(dto.Id) != null)
                {
                    iCTDbContext.FireHoseReels.Remove(iCTDbContext.FireHoseReels.Find(dto.Id));

                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void UpdateFireHoseReelBLL(UpdateFireHoseReelRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                FireHoseReel ex = iCTDbContext.FireHoseReels.Find(dto.Id);

                ex.Id = dto.Id;
                ex.Id_Area = dto.Id_Area;
                ex.Type = dto.Type;
                ex.Description = dto.Description;
                ex.ManufacturedDate = dto.ManufacturedDate;
                ex.LastMaintenanceDate = dto.LastMaintenanceDate;
                ex.MaintenanceDueDate = dto.MaintenanceDueDate;

                iCTDbContext.SaveChanges();
            }
        }

        public static ListFireHoseReelResponseDTO ListFireHoseReelBLL()
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {

                List<ListItemFireHoseReelResponseDTO> listItemFireHoseReelResponseDTOs = iCTDbContext.FireHoseReels
                        .Select(x => new ListItemFireHoseReelResponseDTO
                        { Id = x.Id, Id_Area = x.Id_Area, Type = x.Type, 
                            Description = x.Description, ManufacturedDate = x.ManufacturedDate, LastMaintenanceDate = x.LastMaintenanceDate, 
                            MaintenanceDueDate = x.MaintenanceDueDate 
                        }).ToList();

                return new ListFireHoseReelResponseDTO { Items = listItemFireHoseReelResponseDTOs, Total = listItemFireHoseReelResponseDTOs.Count() };
            }
        }
    }
}
