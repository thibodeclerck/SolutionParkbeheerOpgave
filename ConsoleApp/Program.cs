using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Exceptions;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System.Diagnostics.Contracts;

string connectionString = "Data Source=LAPTOP-FTPF1N3K\\SQLEXPRESS;Initial Catalog=ParkBeheer;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
ParkBeheerContext ctx = new ParkBeheerContext(connectionString);
//ctx.Database.EnsureDeleted();
//ctx.Database.EnsureCreated();

HuizenRepositoryEF hr = new HuizenRepositoryEF(connectionString);
HuurderRepositoryEF huurderRepo = new HuurderRepositoryEF(connectionString);
ContractenRepositoryEF cr = new ContractenRepositoryEF(connectionString);

BeheerContracten contractBeheerder = new BeheerContracten(cr);
BeheerHuizen huizenBeheerder = new BeheerHuizen(hr);
BeheerHuurders huurderBeheerder = new BeheerHuurders(huurderRepo);

int beheerderKeuze = 0;
int huizenKeuze = 0;
int huurderKeuze = 0;
int huizenParkKeuze = 0;
int contractKeuze = 0;

Park park1 = new Park("park 1", "park 1", "parkegem");
Park park2 = new Park("park 2", "park 2", "parkstad");
Park park3 = new Park("park 3", "park 3", "parkdennen");

while (beheerderKeuze != 4)
{
    Console.WriteLine("1 voor huizen, 2 voor huurder, 3 voor contracten, 4 voor stop");
    try
    {
        beheerderKeuze = int.Parse(Console.ReadLine());
    }catch(Exception ex)
    {
        Console.WriteLine("Ongeldige input");
    }
    //huizenBeheerder
    if (beheerderKeuze == 1)
    {
        try
        {
        Console.WriteLine("1 voor voegHuisToe, 2 voor updateHuis, 3 voor archiveerHuis, 4 voor terug");
        huizenKeuze = int.Parse(Console.ReadLine());
            
        } catch (Exception ex)
        {
            Console.WriteLine("Ongeldige input");
        }
        //VoegHuisToe
        if (huizenKeuze == 1)
        {
            try
            {
                Console.Write("straat: ");
                string straat = Console.ReadLine();
                Console.Write("Nummer: ");

                int huisNummer = int.Parse(Console.ReadLine());
                Console.WriteLine("1 voor park 1, 2 voor park 2, 3 voor park 3: ");
                huizenParkKeuze = int.Parse(Console.ReadLine());
                Park park = null;
                if (huizenParkKeuze == 1)
                {
                    park = park1;
                } else if (huizenParkKeuze == 2)
                {
                    park = park2;
                } else if (huizenParkKeuze == 3)
                {
                    park = park3;
                }
                huizenBeheerder.VoegNieuwHuisToe(straat, huisNummer, park);
                Console.WriteLine("Huis toegevoegd");
            } catch (BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (huizenKeuze == 2)
        {
            try
            {
                Console.Write("huisId: ");
                int huisId = int.Parse(Console.ReadLine());
                Huis huisToUpdate = huizenBeheerder.GeefHuis(huisId);
                Console.Write("straat: ");
                string straat = Console.ReadLine();
                Console.Write("Nummer: ");
                int huisNummer = int.Parse(Console.ReadLine());
                huisToUpdate.ZetStraat(straat);
                huisToUpdate.ZetNr(huisNummer);
                huizenBeheerder.UpdateHuis(huisToUpdate);
            } catch (BeheerderException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        if (huizenKeuze == 3)
        {
            try
            {
                Console.Write("huisId: ");
                int huisId = int.Parse(Console.ReadLine());
                Huis huisArchiveer = huizenBeheerder.GeefHuis(huisId);
                huizenBeheerder.ArchiveerHuis(huisArchiveer);
                Console.WriteLine("huis gearchiveerd");
            } catch (BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (huizenKeuze == 4)
        {
            Console.Write("");
        }
    }
    if (beheerderKeuze == 2)
    {
        try
        {
        Console.WriteLine("1 voor voegHuurderToe, 2 voor updateHuurder, 3 voor geefHuurders, 4 voor terug");
        huurderKeuze = int.Parse(Console.ReadLine());
            
        } catch (Exception ex)
        {
            Console.WriteLine("Ongeldige input");
        }

        if (huurderKeuze == 1)
        {
            try
            {
                Console.Write("Naam: ");
                string naam = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Telefoon: ");
                string tel = Console.ReadLine();
                Console.Write("Adres: ");
                string adres = Console.ReadLine();
                huurderBeheerder.VoegNieuweHuurderToe(naam, new Contactgegevens(email, tel, adres));
                Console.WriteLine($"{naam} toegevoegd");
            }
            catch (BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (huurderKeuze == 2)
        {
            try
            {
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Huurder huurderUpdate = huurderBeheerder.GeefHuurder(id);
                Contactgegevens contactUpdate = huurderUpdate.Contactgegevens;
                Console.Write("Naam: ");
                string naam = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(naam))
                {
                    huurderUpdate.ZetNaam(naam);
                }
                Console.Write("Email: ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email))
                {
                    contactUpdate.Email = email;
                }
                Console.Write("Telefoon: ");
                string tel = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tel))
                {
                    contactUpdate.ZetTel(tel);
                }
                Console.Write("Adres: ");
                string adres = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(adres))
                {
                    contactUpdate.Adres= adres;
                }
                huurderUpdate.ZetContactgegevens(contactUpdate);
                huurderBeheerder.UpdateHuurder(huurderUpdate);
                Console.WriteLine($"{huurderUpdate.Naam} Geupdate");
            } catch (BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (huurderKeuze == 3)
        {
            try
            {
                Console.Write("Naam: ");
                string naam = Console.ReadLine();
                List<Huurder> huurders = huurderBeheerder.GeefHuurders(naam);
                if (huurders.Count == 0)
                {
                    Console.WriteLine("Geen huurders met deze naam");
                }
                foreach (Huurder h in huurders)
                {
                    Console.WriteLine($"Id: {h.Id} | Naam: {h.Naam}");
                }
            } catch (BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (huurderKeuze == 4)
        {
            Console.Write("");
        }
    }
    if (beheerderKeuze == 3)
    {

        try
        {
        Console.WriteLine("1 voor maakContract, 2 voor updateContract, 3 voor verwijderContract, 4 geefContracten, 5 voor terug");
        contractKeuze = int.Parse(Console.ReadLine());

        } catch (Exception ex)
        {
            Console.WriteLine("Ongeldige input");
        }

        if (contractKeuze == 1)
        {
            try
            {
                Console.Write("Id: ");
                string id = Console.ReadLine();
                Console.Write("Enter a month: ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("Enter a day: ");
                int day = int.Parse(Console.ReadLine());
                Console.Write("Enter a year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Aantal dagen: ");
                int dagen = int.Parse(Console.ReadLine());
                Console.Write("Huurder id: ");
                int huurderId = int.Parse(Console.ReadLine());
                Console.Write("Huis id: ");
                int huisId = int.Parse(Console.ReadLine());
                Huis huis = huizenBeheerder.GeefHuis(huisId);
                Huurder huurder = huurderBeheerder.GeefHuurder(huurderId);
                DateTime datum = new DateTime(year, month, day);
                contractBeheerder.MaakContract(id, new Huurperiode(datum, dagen), huurder, huis);
                Console.WriteLine("Contract aangemaakt");
            }
            catch (BeheerderException ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (contractKeuze == 2)
        {
            try
            {
                Console.Write("Conract id: ");
                string contractId = Console.ReadLine();
                Huurcontract toUpdate = contractBeheerder.GeefContract(contractId);
                Console.Write("Update huurperiode? (1 voor ja, 2 voor nee): ");
                int month = 0;
                int day = 0;
                int year = 0;
                int dagen = 0;
                int updateDatum = int.Parse(Console.ReadLine());
                if (updateDatum == 1)
                {
                    Console.Write("Enter a month: ");
                    
                    month = int.Parse(Console.ReadLine());
                    Console.Write("Enter a day: ");
                    
                    day = int.Parse(Console.ReadLine());
                    Console.Write("Enter a year: ");
                    
                    year = int.Parse(Console.ReadLine());
                Console.Write("Aantal dagen: ");               
                dagen = int.Parse(Console.ReadLine());
                }
                Console.Write("Huurder id: ");
                int huurderId = 0;
                huurderId = int.Parse(Console.ReadLine());
                Console.Write("Huis id: ");
                int huisId = 0;
                huisId = int.Parse(Console.ReadLine());
                if (huisId != 0)
                {
                    Huis huis = huizenBeheerder.GeefHuis(huisId);
                    toUpdate.ZetHuis(huis);
                }
                if (huurderId != 0)
                {
                    Huurder huurder = huurderBeheerder.GeefHuurder(huurderId);
                    toUpdate.ZetHuurder(huurder);
                }
                if (month != 0 && year != 0 && day != 0 && dagen != 0)
                {
                    DateTime datum = new DateTime(year, month, day);
                    toUpdate.ZetHuurperiode(new Huurperiode(datum, dagen));
                }
                
                contractBeheerder.UpdateContract(toUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (contractKeuze == 3)
        {
            try
            {
                Console.Write("Contract Id: ");
                string contractId = Console.ReadLine();
                Huurcontract contractVerwijder = contractBeheerder.GeefContract(contractId);
                contractBeheerder.AnnuleerContract(contractVerwijder);
            }
            catch(BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        if (contractKeuze == 4)
        {
            List<Huurcontract> contracten = new List<Huurcontract>();
            try
            {
                Console.WriteLine("Start datum");
                Console.WriteLine("-----------------");
                Console.Write("Maand: ");
                int monthStart = int.Parse(Console.ReadLine());
                Console.Write("Dag: ");
                int dayStart = int.Parse(Console.ReadLine());
                Console.Write("Jaar: ");
                int yearStart = int.Parse(Console.ReadLine());
                DateTime start = new DateTime(yearStart, monthStart, dayStart);

                Console.Write("Geef eind datum in? (1. ja, 2. nee): ");
                int eindDatumKeuze = int.Parse(Console.ReadLine());
                DateTime eind;
                if (eindDatumKeuze == 1)
                {
                    Console.WriteLine("Eind datum");
                    Console.WriteLine("-----------------");
                    Console.Write("Maand: ");
                    int monthEind = int.Parse(Console.ReadLine());
                    Console.Write("Dag: ");
                    int dayEind = int.Parse(Console.ReadLine());
                    Console.Write("Jaar: ");
                    int yearEind = int.Parse(Console.ReadLine());
                    eind = new DateTime(yearEind, monthEind, dayEind);
                    contracten = contractBeheerder.GeefContracten(start, eind);
                } else contracten = contractBeheerder.GeefContracten(start, null);
                foreach (Huurcontract contract in contracten)
                {
                    string tekstC = $"Contract: {contract.Id}";
                    string derest = $"Huisnummer: {contract.Huis.Nr} | Huurder {contract.Huurder.Naam} | Start: {contract.Huurperiode.StartDatum.ToShortDateString()} | Eind: {contract.Huurperiode.EindDatum.ToShortDateString()}";
                    Console.SetCursorPosition((Console.WindowWidth - tekstC.Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine(tekstC);
                    Console.SetCursorPosition((Console.WindowWidth - derest.Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine(derest);
                    
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            catch(BeheerderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



//Park p = new Park("1", "park 1", "Parkegem");
//Park p2 = new Park("2", "park 2", "Parkegem");
//Huis huis = new Huis("straat", 2, p);
//huis = hr.VoegHuisToe(huis);
//Console.WriteLine(hr.HeeftHuis(5));
//Console.WriteLine(hr.GeefHuis(4).Park.Naam);
//Console.WriteLine(hr.HeeftHuis(huis.Straat, huis.Nr, huis.Park));
//huis = hr.GeefHuis(4);
//huis.ZetStraat("straat");
//hr.UpdateHuis(huis);
//Console.WriteLine(hr.GeefHuis(4).Straat);


//Huurder huurder = new Huurder("Bart", new Contactgegevens("email", "tel", "adres"));
//huurderRepo.VoegHuurderToe(huurder);
//Huurder hu = huurderRepo.GeefHuurder(1);
//hu.ZetNaam("wally");
//huurderRepo.UpdateHuurder(hu);
//Console.WriteLine(huurderRepo.HeeftHuurder(1));



//Huurcontract hc = new Huurcontract("1", new Huurperiode(DateTime.Now, 4), huurder, huis);
//cr.VoegContractToe(hc);
//hc = cr.GeefContract("1");
//cr.AnnuleerContract(hc);
