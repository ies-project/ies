using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.MM.DAL.DB;

namespace ICT.MM.BLL {
    public class CenarioBLL {
        ICT.MM.DAL.DB.ICTDbContext iCTDbContext;

        public void insertScenario(int id, string name, string description)
        {
            iCTDbContext = new ICT.MM.DAL.DB.ICTDbContext();

            Scenario sc = new Scenario();
            sc.Name = name;
            sc.Description = description;
            sc.Id = id;

            iCTDbContext.Scenarios.Add(sc);

            iCTDbContext.SaveChanges();
        }
        
        public void deleteScenario(int id)
        {
            iCTDbContext = new ICT.MM.DAL.DB.ICTDbContext();

            iCTDbContext.ScenarioDevices.RemoveRange(iCTDbContext.ScenarioDevices.Where(x => x.Id_Scenario == id));

            iCTDbContext.Scenarios.Remove(iCTDbContext.Scenarios.Find(id));

            iCTDbContext.SaveChanges();
        }

        public void updateScenario(int id, int? name, int? descripton)
        {

        }

    }
}
