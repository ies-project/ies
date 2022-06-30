using ICT.MM.DAL.DB;

namespace ICT.MM.BLL
{
    public class DeviceTypesBLL
    {
        public void insertDeviceType(int id, string name, string description)
        {
            ICTDbContext db = new ICTDbContext();

            DeviceType newDeviceType = new DeviceType();

            newDeviceType.Id = id;
            newDeviceType.Name = name;
            newDeviceType.Description = description;

            db.Add(newDeviceType);

            db.SaveChanges();
        }

        public void deleteDeviceType(int id)
        {
            ICTDbContext db = new ICTDbContext();

            db.DeviceTypes.Remove(db.DeviceTypes.Find(id));

            db.SaveChanges();
        }

        public void updateDeviceType(int id, string name, string description)
        {
            ICTDbContext db = new ICTDbContext();

            DeviceType newDeviceType = db.DeviceTypes.Find(id);

            newDeviceType.Id = id;
            newDeviceType.Name = name;
            newDeviceType.Description = description;

            db.SaveChanges();
        }

        public ICollection<DeviceType> listDeviceType()
        {
            ICTDbContext db = new ICTDbContext();

            ICollection<DeviceType> deviceTypeList = db.DeviceTypes.ToList();

            db.SaveChanges();

            return deviceTypeList;
        }

    }
}
