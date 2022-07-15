using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class DeviceSubmittedActionBLL
    {

        public static void InsertDeviceSubmittedAction(InsertDeviceSubmittedActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.DeviceSubmittedActions.Find(dto.Id) == null)
                {
                    DeviceSubmittedAction newDeviceSubmittedAction = new DeviceSubmittedAction();

                    newDeviceSubmittedAction.Id = dto.Id;
                    newDeviceSubmittedAction.Id_Action = dto.Id_Action;
                    newDeviceSubmittedAction.Id_Device = dto.Id_Device;
                    newDeviceSubmittedAction.RequestDate = dto.RequestDate;
                    newDeviceSubmittedAction.ResponseDate = dto.ResponseDate;
                    newDeviceSubmittedAction.ResponseStatus = dto.ResponseStatus;

                    db.DeviceSubmittedActions.Add(newDeviceSubmittedAction);

                    db.SaveChanges();
                }
            }
        }

        public static void DeleteDeviceSubmittedAction(DeleteDeviceSubmittedActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.DeviceSubmittedActions.Find(dto.Id) != null)
                {
                    db.DeviceSubmittedActions.Remove(db.DeviceSubmittedActions.Find(dto.Id));

                    db.DeviceSubmittedActions.RemoveRange(db.DeviceSubmittedActions.Where(x => x.Id == dto.Id));

                    db.SaveChanges();
                }
            }
        }

        public static void UpdateDeviceSubmittedAction(UpdateDeviceSubmittedActionRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                DeviceSubmittedAction newDeviceSubmittedAction = db.DeviceSubmittedActions.Find(dto.Id);

                newDeviceSubmittedAction.RequestDate = dto.RequestDate;
                newDeviceSubmittedAction.ResponseDate = dto.ResponseDate;
                newDeviceSubmittedAction.ResponseStatus = dto.ResponseStatus;

                db.SaveChanges();
            }
        }

        public static ListDeviceSubmittedActionResponseDTO ListDeviceSubmittedAction()
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                List<ListItemDeviceSubmittedActionResponseDTO> listItemDeviceSubmittedActionResponseDTOs = db.DeviceSubmittedActions
                        .Select(x => new ListItemDeviceSubmittedActionResponseDTO
                        { 
                            Id = x.Id,
                            Id_Action = x.Id_Action,
                            Id_Device = x.Id_Device,
                            RequestDate = x.RequestDate,
                            ResponseDate = x.ResponseDate,
                            ResponseStatus = x.ResponseStatus,
                        }).ToList();

                return new ListDeviceSubmittedActionResponseDTO { Items = listItemDeviceSubmittedActionResponseDTOs, Total = listItemDeviceSubmittedActionResponseDTOs.Count() };
            }
        }
    }
}
