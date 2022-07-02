using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT.MM.Core.DTO;
using ICT.MM.DAL.DB;

namespace ICT.MM.BLL {
    public class ScenariosBLL {

        public static void InsertScenario(int id, string name, string description)
        {
            using (ICT.MM.DAL.DB.ICTDbContext iCTDbContext = new ICT.MM.DAL.DB.ICTDbContext())
            {
                Scenario sc = new Scenario();
                sc.Name = name;
                sc.Description = description;
                sc.Id = id;

                iCTDbContext.Scenarios.Add(sc);

                iCTDbContext.SaveChanges();
            }
        }
        
        public static void DeleteScenario(DeleteScenarioDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                iCTDbContext.ScenarioDevices.RemoveRange(iCTDbContext.ScenarioDevices.Where(x => x.Id_Scenario == id));

                iCTDbContext.Scenarios.Remove(iCTDbContext.Scenarios.Find(dto.Id));

                iCTDbContext.SaveChanges();
            }
        }

        public static void UpdateScenario(UpdateScenarioRequestDTO dto)
        {
            using (ICTDbContext iCTDbContext = new ICTDbContext())
            {
                Scenario sc = iCTDbContext.Scenarios.Find(dto.Id);

                sc.Name = dto.Name;

                sc.Description = dto.Descripton;

                iCTDbContext.SaveChanges();
            }
        }

        public static ListScenarioResponseDTO ListScenarios() {

            using (ICTDbContext iCTDbContext = new ICTDbContext()){ 

            List<ListItemScenarioResponseDTO> listItemScenarioResponseDTOs = iCTDbContext.Scenarios
                    .Select(x => new ListItemScenarioResponseDTO { Id = x.Id, Name = x.Name}).ToList();

                return new ListScenarioResponseDTO {Items = listItemScenarioResponseDTOs, Total = listItemScenarioResponseDTOs.Count()};
            }
        }

    }
}
