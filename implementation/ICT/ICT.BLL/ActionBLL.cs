using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class ActionBLL
    {

        public static void InsertAction(InsertActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.Actions.Find(dto.Id) == null)
                {
                    DAL.DB.Action newAction = new DAL.DB.Action();

                    newAction.Id = dto.Id;
                    newAction.Name = dto.Name;
                    newAction.Description = dto.Description;

                    db.Actions.Add(newAction);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteAction(DeleteActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                db.Actions.RemoveRange(db.Actions.Where(x => x.Id == dto.Id));

                if(db.Actions.Find(dto.Id) != null)
                {
                    db.Actions.Remove(db.Actions.Find(dto.Id));
                    db.SaveChanges();
                }
            }                 
        }

        public static void UpdateAction(UpdateActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                DAL.DB.Action newAction = db.Actions.Find(dto.Id);
                newAction.Name = dto.Name;
                newAction.Description = dto.Description;
               
                db.SaveChanges();
            }
        }

        public static ListActionResponseDTO ListAction()
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                List<ListItemActionResponseDTO> listItemActionResponseDTOs = db.Actions
                    .Select(x => new ListItemActionResponseDTO
                    { 
                        Id = x.Id, 
                        Name = x.Name, 
                        Description = x.Description,
                    }).ToList();
                return new ListActionResponseDTO
                {
                    Items = listItemActionResponseDTOs,
                    Total = listItemActionResponseDTOs.Count()
                };
            }
        }
    }
}