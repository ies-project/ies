using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.MM.DAL.DB;

namespace ICT.MM.BLL {
    public class ScenarioDevicesBLL {
        ICTDbContext iCTDbContext;

        public void insertScenarioDevices(int id_Scenario, int id_Device, DateTime manufacturedDate, DateTime lastManteinanceDate, 
            DateTime manteinanceDueDate, string originalState, string currentState)
        {
            iCTDbContext = new ICTDbContext();

            ScenarioDevice scd = new ScenarioDevice();
            scd.Id_Scenario = id_Scenario;
            scd.Id_Device = id_Device;
            scd.ManufacturedDate = manufacturedDate;
            scd.LastManteinanceDate = lastManteinanceDate;  
            scd.ManteinanceDueDate = manteinanceDueDate;
            scd.OriginalState = originalState;
            scd.CurrentState = currentState;

            iCTDbContext.ScenarioDevices.Add(scd);

            iCTDbContext.SaveChanges();
        }

        public void updateScenario(int id_Scenario, int id_Device, DateTime manufacturedDate, DateTime lastManteinanceDate,
            DateTime manteinanceDueDate, string originalState, string currentState)
        {
            iCTDbContext = new ICTDbContext();

            ScenarioDevice scd = iCTDbContext.ScenarioDevices.Find(id_Scenario, id_Device);
            scd.Id_Scenario = id_Scenario;
            scd.Id_Device = id_Device;
            scd.ManufacturedDate = manufacturedDate;
            scd.LastManteinanceDate = lastManteinanceDate;
            scd.ManteinanceDueDate = manteinanceDueDate;
            scd.OriginalState = originalState;
            scd.CurrentState = currentState;

            iCTDbContext.SaveChanges();
        }

        public ICollection<ScenarioDevice> listScenarioDevice()
        {
            iCTDbContext = new ICTDbContext();

            ICollection<ScenarioDevice> listScenario = iCTDbContext.ScenarioDevices.ToList();

            return listScenario;
        }

        public ICollection<ScenarioDevice> listScenDevByScenario(int id_Scenario)
        {
            iCTDbContext = new ICTDbContext();

            ICollection<ScenarioDevice> listScenario = (ICollection<ScenarioDevice>)iCTDbContext.ScenarioDevices.ToList()
                .Where(x => x.Id_Scenario == id_Scenario);

            return listScenario;
        }

        public ICollection<ScenarioDevice> listScenDevByDevice(int id_Device)
        {
            iCTDbContext = new ICTDbContext();

            ICollection<ScenarioDevice> listScenario = (ICollection<ScenarioDevice>)iCTDbContext.ScenarioDevices.ToList()
                .Where(x => x.Id_Device == id_Device);

            return listScenario;
        }

    }
}