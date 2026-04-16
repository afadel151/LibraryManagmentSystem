
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using Borrowing.Api.Repositories;
using Common.Models;
using Microsoft.IdentityModel.Tokens;

namespace Borrowing.Api.Extensions;

public static class BaseExtensions
{
    public static DateTime Traiter_date(DateTime date, List<JoursFery> joursFeries)
    {
        ArgumentNullException.ThrowIfNull(joursFeries);
        bool changement = false;
        // si vendredi ou samedi
        DayOfWeek day = date.DayOfWeek;
        if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday)
        {
            date = date.AddDays(1);
            changement = true;
        }
        else
        {
            /// si jours ferie
            bool isHoliday = joursFeries.Any(j => j.DateJourFerie.Date == date.Date);
            if (isHoliday)
            {
                date = date.AddDays(1);
                changement = true;
            }
        }
        if (changement)
        {
            return Traiter_date(date, joursFeries);
        }
        // pas de changement
        return date;
    }
    public static string DecryptString(string cipherText, string _appKey, string _initialVector)
    {
        var decoded = Base64UrlEncoder.Decode(cipherText);
        var buffer = Convert.FromBase64String(decoded);

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(_appKey);
        aesAlg.IV = Encoding.UTF8.GetBytes(_initialVector);

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new(buffer);
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}