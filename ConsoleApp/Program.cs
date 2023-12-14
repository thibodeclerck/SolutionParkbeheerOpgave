using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;

string connectionString = "Data Source=LAPTOP-FTPF1N3K\\SQLEXPRESS;Initial Catalog=ParkBeheer;Integrated Security=True; TrustServerCertificate=true;";
ParkBeheerContext ctx = new ParkBeheerContext(connectionString);
//ctx.Database.EnsureDeleted();
//ctx.Database.EnsureCreated();

HuizenRepositoryEF hr = new HuizenRepositoryEF(connectionString);
HuurderRepositoryEF huurderRepo = new HuurderRepositoryEF(connectionString);
ContractenRepositoryEF cr = new ContractenRepositoryEF(connectionString);

Park p = new Park("1", "park 1", "Parkegem");
Park p2 = new Park("2", "park 2", "Parkegem");
Huis huis = new Huis("straat", 2, p);
//huis = hr.VoegHuisToe(huis);
//Console.WriteLine(hr.HeeftHuis(5));
//Console.WriteLine(hr.GeefHuis(4).Park.Naam);
//Console.WriteLine(hr.HeeftHuis(huis.Straat, huis.Nr, huis.Park));
//Huis huis = hr.GeefHuis(4);
//huis.ZetStraat("straat");
//hr.UpdateHuis(huis);
//Console.WriteLine(hr.GeefHuis(4).Straat);


Huurder huurder = new Huurder("Bart", new Contactgegevens("email", "tel", "adres"));
//huurderRepo.VoegHuurderToe(huurder);
Huurder hu = huurderRepo.GeefHuurder(1);
//hu.ZetNaam("wally");
//huurderRepo.UpdateHuurder(hu);
//Console.WriteLine(huurderRepo.HeeftHuurder(1));



Huurcontract hc = new Huurcontract("1", new Huurperiode(DateTime.Now, 4), huurder, huis);
cr.VoegContractToe(hc);
//Huurcontract hc = cr.GeefContract("1");
//cr.AnnuleerContract(hc);
