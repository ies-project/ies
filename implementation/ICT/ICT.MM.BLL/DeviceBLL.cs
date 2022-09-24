using ICT.MM.Core.DTO;
using ICT.MM.DAL.DB;

public class DeviceBLL {
    /// <summary>
    /// Adiciona um device na base de dados utilizando o dto passado como parametro
    /// </summary>
    /// <param name="dto"></param>
    public static void InsertDevice(InsertDeviceRequestDTO dto)
    {
        //inicializa uma conexao com a base de dados
        using (ICTDbContext db = new ICTDbContext())
        {
            //tenta encontrar um device cujo id seja igual ao id passado pelo dto
            if (db.Devices.Find(dto.Id) == null && db.DeviceTypes.Find(dto.Id_DeviceType) != null)
            {
                //inicializa um novo device
                Device newDevice = new Device();

                newDevice.Id = dto.Id;
                newDevice.Id_DeviceType = dto.Id_DeviceType;
                newDevice.Name = dto.Name;
                newDevice.Description = dto.Description;
                newDevice.ManufacturedDate = dto.ManufacturedDate;
                newDevice.LastMaintenanceDate = dto.LastMaintenanceDate;
                newDevice.MaintenanceDueDate = dto.MaintenanceDueDate;
                newDevice.ManufacturedBy = dto.ManufacturedBy;
                newDevice.CreatedBy = dto.CreatedBy;
                newDevice.CreatedDate = dto.CreatedDate;
                newDevice.ModifiedBy = dto.ModifiedBy;
                newDevice.ModifiedDate = dto.ModifiedDate;

                //adiciona o device á base de dados
                db.Devices.Add(newDevice);

                //atualiza a base de dados com as mudanças feitas
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Elimina um device da base de dados utilizando o dto passado como parametro
    /// </summary>
    /// <param name="dto"></param>
    public static void DeleteDevice(DeleteDeviceRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            if (db.Devices.Find(dto.Id) != null)
            {
                db.Devices.Remove(db.Devices.Find(dto.Id));

                if(db.ScenarioDevices.Where(x => x.Id_Device == dto.Id).Any())
                    db.ScenarioDevices.RemoveRange(db.ScenarioDevices.Where(x => x.Id_Device == dto.Id));

                db.SaveChanges();
            }
        }
    }
    /// <summary>
    /// Atualiza um device da base de dados utilizando o dto passado como parametro
    /// </summary>
    /// <param name="dto"></param>
    public static void UpdateDevice(UpdateDeviceRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {
            Device newDevice = db.Devices.Find(dto.Id);

            newDevice.Id_DeviceType = dto.Id_DeviceType;
            newDevice.Name = dto.Name;
            newDevice.Description = dto.Description;
            newDevice.ManufacturedDate = dto.ManufacturedDate;
            newDevice.LastMaintenanceDate = dto.LastMaintenanceDate;
            newDevice.MaintenanceDueDate = dto.MaintenanceDueDate;
            newDevice.ManufacturedBy = dto.ManufacturedBy;
            newDevice.CreatedBy = dto.CreatedBy;
            newDevice.CreatedDate = dto.CreatedDate;
            newDevice.ModifiedBy = dto.ModifiedBy;
            newDevice.ModifiedDate = dto.ModifiedDate;

            db.SaveChanges();
        }
    }

    /// <summary>
    /// Retorna uma lista com todos os devices existentes na base de dados
    /// </summary>
    /// <returns></returns>
    public static ListDeviceResponseDTO ListDevices()
    {
        using (ICTDbContext db = new ICTDbContext())
        {
            List<ListItemDeviceResponseDTO> listItemDeviceResponseDTOs = db.Devices
                    .Select(x => new ListItemDeviceResponseDTO { Id = x.Id, 
                                                                 Id_DeviceType = x.Id_DeviceType, 
                                                                 Name = x.Name, 
                                                                 Description = x.Description,
                                                                 ManufacturedDate = x.ManufacturedDate,
                                                                 LastMaintenanceDate = x.LastMaintenanceDate,
                                                                 MaintenanceDueDate = x.MaintenanceDueDate,
                                                                 ManufacturedBy= x.ManufacturedBy,
                                                                 CreatedBy = x.CreatedBy,
                                                                 CreatedDate = x.CreatedDate,
                                                                 ModifiedBy = x.ModifiedBy,
                                                                 ModifiedDate = x.ModifiedDate
                    }).ToList();

            return new ListDeviceResponseDTO { Items = listItemDeviceResponseDTOs, Total = listItemDeviceResponseDTOs.Count()};
        }
    }
}