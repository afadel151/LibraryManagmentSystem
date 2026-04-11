
using System.Collections.ObjectModel;
using Borrowing.Api.Repositories;
using Common.Models;

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
}