using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.MM.Core.DTO;
using ICT.MM.DAL.DB;
using Microsoft.EntityFrameworkCore;

namespace ICT.MM.BLL
{
    public class DeviceTypesBLL
    {
        /// <summary>
        /// Adiciona um devicetype a base de dados utilizando o dto passado como parametro
        /// </summary>
        /// <param name="dto"></param>
        public static void InsertDeviceType(InsertDeviceTypeRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                if (iCTDbContext.DeviceTypes.Find(dto.Id) == null)
                {
                    DeviceType sc = new DeviceType();
                    sc.Name = dto.Name;
                    sc.Description = dto.Description;
                    sc.Id = dto.Id;

                    iCTDbContext.DeviceTypes.Add(sc);

                    iCTDbContext.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Elimina um devicetype da base de dados utilizando o dto passado como parametro
        /// </summary>
        /// <param name="dto"></param>
        public static void DeleteDeviceType(DeleteDeviceTypeRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {

                if (iCTDbContext.DeviceTypes.Find(dto.Id) != null)
                {

                    iCTDbContext.DeviceTypes.Remove(iCTDbContext.DeviceTypes.Find(dto.Id));

                    var devices = iCTDbContext.Devices.Where(m => m.Id_DeviceType == dto.Id).ToList();

                    if (devices != null)
                    {
                        foreach(Device device in devices)
                        {
                            if(iCTDbContext.ScenarioDevices.Where(x => x.Id_Device == device.Id) != null)
                            {
                                iCTDbContext.ScenarioDevices.RemoveRange(iCTDbContext.ScenarioDevices.Where(x => x.Id_Device == device.Id));
                            }
                        }
                        iCTDbContext.Devices.RemoveRange(iCTDbContext.Devices.Where(m => m.Id_DeviceType == dto.Id));

                    }

                    iCTDbContext.DeviceTypes.RemoveRange(iCTDbContext.DeviceTypes.Where(x => x.Id == dto.Id));

                    iCTDbContext.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Atualiza um devicetype da base de dados utilizando o dto passado como parametro
        /// </summary>
        /// <param name="dto"></param>
        public static void UpdateDeviceType(UpdateDeviceTypeRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                DeviceType sc = iCTDbContext.DeviceTypes.Find(dto.Id);

                sc.Name = dto.Name;

                sc.Description = dto.Description;

                iCTDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os devicetypes existentes na base de dados
        /// </summary>
        /// <returns></returns>
        public static ListDeviceTypesResponseDTO ListDeviceTypes()
        {

            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {

                List<ListItemDeviceTypesResponseDTO> listItemDeviceTypeResponseDTOs = iCTDbContext.DeviceTypes
                        .Select(x => new ListItemDeviceTypesResponseDTO { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();

                return new ListDeviceTypesResponseDTO { Items = listItemDeviceTypeResponseDTOs, Total = listItemDeviceTypeResponseDTOs.Count() };
            }
        }

    }
}