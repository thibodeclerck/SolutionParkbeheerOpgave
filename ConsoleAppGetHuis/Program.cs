using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;

string connectionString = "Data Source=PC_Thibo\\SQLEXPRESS;Initial Catalog=ParkBeheer;Integrated Security=True;Trust Server Certificate=True";
ParkBeheerContext ctx = new ParkBeheerContext(connectionString);


HuizenRepositoryEF hr = new HuizenRepositoryEF(connectionString);
BeheerHuizen huizenBeheerder = new BeheerHuizen(hr);

Huis huis = hr.GeefHuis(1);
Console.WriteLine(huis);