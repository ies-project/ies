using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class BuildingBLL
    {

        public static void InsertBuilding(InsertBuildingRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.Buildings.Find(dto.Id) == null)
                {
                    Building bd = new Building();
                    bd.Name = dto.Name;
                    bd.Address = dto.Address;
                    bd.Type = dto.Type;

                    iCTDbContext.Buildings.Add(bd);
                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void DeleteBuilding(DeleteBuildingRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                iCTDbContext.Areas.RemoveRange(iCTDbContext.Areas.Where(x => x.Id_Building == dto.Id));

                if(iCTDbContext.Buildings.Find(dto.Id) != null)
                {
                    iCTDbContext.Buildings.Remove(iCTDbContext.Buildings.Find(dto.Id));
                    iCTDbContext.SaveChanges();
                }
            }                 
        }

        public static void UpdateBuilding(UpdateBuildingRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                Building bd = iCTDbContext.Buildings.Find(dto.Id);
                bd.Name = dto.Name;
                bd.Address = dto.Address;
                bd.Type = dto.Type;
                iCTDbContext.SaveChanges();
            }
        }

        public static ListBuildingResponseDTO listBuilding()
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                List<ListItemBuildingResponseDTO> listItemBuildingResponseDTOs = iCTDbContext.Buildings
                    .Select(x => new ListItemBuildingResponseDTO { 
                        Id = x.Id, 
                        Name = x.Name, 
                        Address = x.Address, 
                        Type = x.Type 
                    }).ToList();

                return new ListBuildingResponseDTO
                {
                    Items = listItemBuildingResponseDTOs,
                    Total = listItemBuildingResponseDTOs.Count()
                };
            }
        }
    }
}