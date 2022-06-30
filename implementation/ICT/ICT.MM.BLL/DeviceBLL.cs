using ICT.MM.DAL.DB;

//ICT.MM.DAL.DB.ICTDbContext iCTDbContext = new ICT.MM.DAL.DB.ICTDbContext();

public class DeviceBLL
{

    public void insertDevice(int id, int id_DeviceType, string name, string description, DateTime ManufacturedDate, DateTime LastMaintenanceDate, 
        DateTime MaintenanceDueDate, string ManufacturedBy, string CreatedBy, DateTime CreatedDate, string ModifiedBy, DateTime ModifiedDate)
    {
        ICTDbContext db = new ICTDbContext();

        Device newDevice = new Device();

        newDevice.Id = id;
        newDevice.Id_DeviceType = id_DeviceType;
        newDevice.Name = name;
        newDevice.Description = description;
        newDevice.ManufacturedDate = ManufacturedDate;
        newDevice.LastMaintenanceDate = LastMaintenanceDate;
        newDevice.MaintenanceDueDate = MaintenanceDueDate;
        newDevice.ManufacturedBy = ManufacturedBy;
        newDevice.CreatedBy = CreatedBy;
        newDevice.CreatedDate = CreatedDate;
        newDevice.ModifiedBy = ModifiedBy;
        newDevice.ModifiedDate = ModifiedDate;

        db.Devices.Add(newDevice);

        db.SaveChanges();
    }

    public void deleteDevice(int idDevice)
    {
        ICTDbContext db = new ICTDbContext();

        db.Devices.Remove(db.Devices.Find(idDevice));

        db.ScenarioDevices.RemoveRange(db.ScenarioDevices.Where(x => x.Id_Device == idDevice));

        db.SaveChanges();

    }

    public void updateDevice()
    {
        ICTDbContext db = new ICTDbContext();

        db.SaveChanges();
    }

    public void listDevice()
    {
        ICTDbContext db = new ICTDbContext();

        db.SaveChanges();
    }
}



//iCTDbContext.SaveChanges();