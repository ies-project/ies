using ICT.DAL.DB;


public class BuildingBLL
{

    public void insertBuilding(int id, string name, string address, string type)
    {
        ICTDbContext db = new ICTDbContext();

        Building newBuilding = new Building();

        newBuilding.Id = id;

        newBuilding.Name = name;

        newBuilding.Address = address;

        db.Buildings.Add(newBuilding);

        db.SaveChanges();
    }

    public void deleteBuilding(int idBuilding)
    {
        ICTDbContext db = new ICTDbContext();

        db.Buildings.Remove(db.Buildings.Find(idBuilding));

        db.Buildings.RemoveRange(db.Buildings.Where(x => x.Id == idBuilding));

        db.SaveChanges();

    }

    public void updateDevice(int id, string name, string address, string type)
    {
        ICTDbContext db = new ICTDbContext();

        Building newBuilding = db.Buildings.Find(id);

        newBuilding.Id = id;

        newBuilding.Name = name;

        newBuilding.Address = address;

        db.Buildings.Add(newBuilding);

        db.SaveChanges();
    }

    public ICollection<Building> listBuilding()
    {
        ICTDbContext db = new ICTDbContext();

        ICollection<Building> buildingList = db.Buildings.ToList();

        db.SaveChanges();

        return buildingList;
    }
}