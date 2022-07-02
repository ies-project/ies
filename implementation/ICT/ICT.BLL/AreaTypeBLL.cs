using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class AreaTypeBLL
    {
        public static void InsertAreaType(InsertAreaTypeRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.AreaTypes.Find(dto.Id) == null)
                {
                    AreaType at = new AreaType();
                    at.Id = dto.Id;
                    at.Name = dto.Name;
                    at.Description = dto.Description;

                    iCTDbContext.AreaTypes.Add(at);
                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void DeleteAreaType(DeleteAreaTypeDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.AreaTypes.Find(dto.Id) != null)
                {
                    iCTDbContext.AreaTypes.Remove(iCTDbContext.AreaTypes.Find(dto.Id));
                    iCTDbContext.SaveChanges();
                }
            }
        }

        public static void UpdateAreaType(UpdateAreaTypeRequestDTO dto)
        {
            using(ICTDbContext iCTDbContext = new ICTDbContext())
            {
                AreaType at = iCTDbContext.AreaTypes.Find(dto.Id);
                at.Name = dto.Name;
                at.Description= dto.Description;
                iCTDbContext.SaveChanges();
            }
        }

        public static ListAreaTypeResponseDTO listAreaType()
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                List<ListItemAreaTypeResponseDTO> listItemAreaTypeResponseDTOs = iCTDbContext.AreaTypes
                    .Select(x => new ListItemAreaTypeResponseDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();

                return new ListAreaTypeResponseDTO
                {
                    Items = listItemAreaTypeResponseDTOs,
                    Total = listItemAreaTypeResponseDTOs.Count()
                };
            }
        }
    }
}
