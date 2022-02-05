using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models.Validatory
{

    public class BiznesValidator : Validator
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static string SprawdzVat(decimal? vat)
        {
            try
            {
                if (vat < 0 || vat > 23)
                {
                    return "Vat powiniem bydź z zakresy 0-23";
                }

            }
            catch (Exception)
            {

                return "Niepoprawny Vat";
            }
            return null;
        }

        public static string SprawdzDateSprzedazy(DateTime? dataSprzedazy, DateTime? terminPlatnosci)
        {
            try
            {
                DateTime updateDataSprzedazy = dataSprzedazy ?? DateTime.Now;
                DateTime updateTerminPlatnosci = terminPlatnosci ?? DateTime.Now;
                int comparsion = DateTime.Compare(updateDataSprzedazy, updateTerminPlatnosci);
                if (comparsion > 0)
                {
                    return "Data sprzedaży jest większa niż termin płatności";
                }
            }
            catch (Exception)
            {
                return "Nie poprawna data";
            }
            return null;
        }

        public static string SprawdzRabat(string rabat)
        {
            try
            {
                int intrabat = int.Parse(rabat);

                if (intrabat < 0 || intrabat > 50)
                {
                    return "Rabat powiniem bydź z zakresy 0-50";
                }

            }
            catch (Exception)
            {

                return "Niepoprawny rabat";
            }
            return null;
        }

    }

}
