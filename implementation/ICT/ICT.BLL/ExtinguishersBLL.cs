using ICT.Core.DTO;
using ICT.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.BLL {
    public class ExtinguishersBLL {
        public static void InsertExtinguisher(InsertExtinguisherRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.Extinguishers.Find(dto.Id) == null)
                {
                    Extinguisher ex = new Extinguisher();
                    ex.Id = dto.Id;
                    ex.Id_Area = dto.Id_Area;
                    ex.Type = dto.Type;
                    ex.Description = dto.Description;
                    ex.ManufacturedDate = dto.ManufacturedDate;
                    ex.LastMaintenanceDate = dto.LastMaintenanceDate;
                    ex.MaintenanceDueDate = dto.MaintenanceDueDate;

                    iCTDbContext.Extinguishers.Add(ex);

                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void DeleteExtinguisher(DeleteExtinguisherRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.Extinguishers.Find(dto.Id) != null)
                {
                    iCTDbContext.Extinguishers.Remove(iCTDbContext.Extinguishers.Find(dto.Id));

                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void UpdateExtinguisher(UpdateExtinguisherRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                Extinguisher ex = iCTDbContext.Extinguishers.Find(dto.Id);

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

        public static ListExtinguishersResponseDTO ListScenarios()
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {

                List<ListItemExtinguishersResponseDTO> listItemScenarioResponseDTOs = iCTDbContext.Extinguishers
                        .Select(x => new ListItemExtinguishersResponseDTO { Id = x.Id, Id_Area = x.Id_Area, Type = x.Type, 
                            Description = x.Description, ManufacturedDate = x.ManufacturedDate, LastMaintenanceDate = x.LastMaintenanceDate, 
                            MaintenanceDueDate = x.MaintenanceDueDate }).ToList();

                return new ListExtinguishersResponseDTO { Items = listItemScenarioResponseDTOs, Total = listItemScenarioResponseDTOs.Count() };
            }
        }
    }
}
