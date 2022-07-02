using ICT.Core.DTO;
using ICT.DAL.DB;

public class AreaBLL
{

    public static void InsertArea(InsertAreaRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            Area newArea = new Area();

            newArea.Id = dto.Id;

            newArea.Id_Building = dto.Id_Building;

            newArea.Id_Type = dto.Id_Type;

            newArea.Name = dto.Name;

            newArea.Floor = dto.Floor;

            newArea.NumFireBalls = dto.NumFireBalls;

            newArea.NumSpringles = dto.NumSpringles;

            newArea.NumBocasSingulares = dto.NumBocasSingulares;

            newArea.NumBocasSiameses = dto.NumBocasSiameses;

            db.Areas.Add(newArea);

            db.SaveChanges();
        }
    }

    public static void DeleteArea(DeleteAreaRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            db.Areas.Remove(db.Areas.Find(dto.Id));

            db.Areas.RemoveRange(db.Areas.Where(x => x.Id == dto.Id));

            db.SaveChanges();

        }
    }

    public static void UpdateArea(UpdateAreaRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {
            Area newArea = db.Areas.Find(dto.Id);

            newArea.Name = dto.Name;

            newArea.Floor = dto.Floor;

            newArea.NumFireBalls = dto.NumFireBalls;

            newArea.NumSpringles = dto.NumSpringles;

            newArea.NumBocasSingulares = dto.NumBocasSingulares;

            newArea.NumBocasSiameses = dto.NumBocasSiameses;

            db.Areas.Add(newArea);

            db.SaveChanges();
        }
    }

    public static ListAreaResponseDTO ListArea()
    {
        using (ICTDbContext db = new ICTDbContext())
        {
            List<ListItemAreaResponseDTO> listItemAreaResponseDTOs = db.Areas
                    .Select(x => new ListItemAreaResponseDTO
                    {
                        Id = x.Id,
                        Id_Building = x.Id_Building,
                        Id_Type = x.Id_Type,
                        Floor = x.Floor,
                        NumFireBalls = x.NumFireBalls,
                        NumSpringles = x.NumSpringles,
                        NumBocasSingulares = x.NumBocasSingulares,
                        NumBocasSiameses = x.NumBocasSiameses,
                        
                    }).ToList();

            return new ListAreaResponseDTO
            {
                Items = listItemAreaResponseDTOs,
                Total = listItemAreaResponseDTOs.Count()
            };
        }
    }
}