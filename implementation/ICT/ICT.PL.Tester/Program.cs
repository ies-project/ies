// See https://aka.ms/new-console-template for more information
using ICT.DAL.DB;

Console.WriteLine("Hello, World!");

ICT.DAL.DB.ICTDbContext iCTDbContext = new ICT.DAL.DB.ICTDbContext();

DeviceType dt = new DeviceType();
dt.Name = "Name";
dt.Description = "Description";
dt.Id = 1;

iCTDbContext.DeviceTypes.Add(dt);

iCTDbContext.SaveChanges();