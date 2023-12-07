using ParkDataLayer.Model;

string connectionString = "Data Source=LAPTOP-FTPF1N3K\\SQLEXPRESS;Initial Catalog=ParkBeheer;Integrated Security=True; TrustServerCertificate=true;";
ParkBeheerContext ctx = new ParkBeheerContext(connectionString);
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();

