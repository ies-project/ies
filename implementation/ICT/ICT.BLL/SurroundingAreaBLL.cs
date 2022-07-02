using ICT.Core.DTO;
using ICT.DAL.DB;

public class SurroundingAreaBLL
{

    public static void InsertSurroundingArea(InsertSurroundingAreaRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            SurroundingArea newSurroundingArea = new SurroundingArea();

            newSurroundingArea.Id = dto.Id;

            newSurroundingArea.Id_Area = dto.Id_Area;

            db.SurroundingAreas.Add(newSurroundingArea);

            db.SaveChanges();
        }
    }

    public static void DeleteSurroundingArea(DeleteSurroundingAreaRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            db.SurroundingAreas.Remove(db.SurroundingAreas.Find(dto.Id));

            db.SurroundingAreas.RemoveRange(db.SurroundingAreas.Where(x => x.Id == dto.Id));

            db.SaveChanges();

        }
    }

    public static ListSurroundingAreaResponseDTO ListSurroundingArea()
    {
        using (ICTDbContext db = new ICTDbContext())
        {
            List<ListItemSurroundingAreaResponseDTO> listItemSurroundingAreaResponseDTOs = db.SurroundingAreas
                    .Select(x => new ListItemSurroundingAreaResponseDTO
                    {
                        Id = x.Id,
                        Id_Area = x.Id_Area,               
                    }).ToList();

            return new ListSurroundingAreaResponseDTO
            {
                Items = listItemSurroundingAreaResponseDTOs,
                Total = listItemSurroundingAreaResponseDTOs.Count()
            };
        }
    }
}