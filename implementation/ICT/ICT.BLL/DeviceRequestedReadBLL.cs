using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class DeviceRequestedReadBLL
    {

        public static void InsertDeviceRequestedRead(InsertDeviceRequestedReadRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.DeviceRequestedReads.Find(dto.Id) == null)
                {
                    DeviceRequestedRead newDeviceRequestedRead = new DeviceRequestedRead();

                    newDeviceRequestedRead.Id = dto.Id;
                    newDeviceRequestedRead.Id_Device = dto.Id_Device;
                    newDeviceRequestedRead.RequestDate = dto.RequestDate;
                    newDeviceRequestedRead.ResponseDate = dto.ResponseDate;
                    newDeviceRequestedRead.ResponseStatus = dto.ResponseStatus;
                    newDeviceRequestedRead.ResponseBody = dto.ResponseBody;

                    db.DeviceRequestedReads.Add(newDeviceRequestedRead);

                    db.SaveChanges();
                }
            }
        }

        public static void DeleteDeviceRequestedRead(DeleteDeviceRequestedReadRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.DeviceRequestedReads.Find(dto.Id) != null)
                {
                    db.DeviceRequestedReads.Remove(db.DeviceRequestedReads.Find(dto.Id));

                    db.DeviceRequestedReads.RemoveRange(db.DeviceRequestedReads.Where(x => x.Id == dto.Id));

                    db.SaveChanges();
                }
            }
        }

        public static void UpdateDeviceRequestedRead(UpdateDeviceRequestedReadRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                DeviceRequestedRead newDeviceRequestedRead = db.DeviceRequestedReads.Find(dto.Id);

                newDeviceRequestedRead.RequestDate = dto.RequestDate;
                newDeviceRequestedRead.ResponseDate = dto.ResponseDate;
                newDeviceRequestedRead.ResponseStatus = dto.ResponseStatus;
                newDeviceRequestedRead.ResponseBody = dto.ResponseBody;

                db.SaveChanges();
            }
        }

        public static ListDeviceRequestedReadResponseDTO ListDeviceRequestedRead()
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                List<ListItemDeviceRequestedReadResponseDTO> listItemDeviceRequestedReadResponseDTOs = db.DeviceRequestedReads
                        .Select(x => new ListItemDeviceRequestedReadResponseDTO
                        { 
                            Id = x.Id,
                            Id_Device = x.Id_Device,
                            RequestDate = x.RequestDate,
                            ResponseDate = x.ResponseDate,
                            ResponseStatus = x.ResponseStatus,
                            ResponseBody = x.ResponseBody
                        }).ToList();

                return new ListDeviceRequestedReadResponseDTO { Items = listItemDeviceRequestedReadResponseDTOs, Total = listItemDeviceRequestedReadResponseDTOs.Count() };
            }
        }
    }
}
