using ParkBusinessLayer.Exceptions;
using System.Linq;

namespace ParkBusinessLayer.Model
{
    public class Contactgegevens
    {
        public Contactgegevens(string email, string tel, string adres)
        {
            ZetEmail(email);
            ZetTel(tel);
            ZetAdres(adres);
        }
        public string Email { get; set; }
        public string Tel { get; private set; }
        public string Adres { get; set; }

        public void ZetEmail(string email)
        {
            if (email.Contains("@"))
            {
                Email = email;
            }
            else
            {
                throw new BeheerderException("Ongeldig email adres");
            }
        }
        public void ZetTel(string tel)
        {
            if (tel.All(char.IsDigit))
            {
                Tel = tel;
            }
            else
            {
                throw new BeheerderException("Telefoon can enkel nummer bevatten");
            }
        }

        public void ZetAdres(string adres)
        {
            if (!string.IsNullOrWhiteSpace(adres))
            {
                Adres = adres;
            }
            else
            {
                throw new BeheerderException("adres mag niet leeg zijn");
            }
        }
    }
}