
using LibraryManagement.Shared.Models;

namespace Borrowing.ScheduledTask.Extensions;
public static class BaseExtensions
{
    public static  DateTime Traiter_date(DateTime date,List<JoursFery> joursFeries)
    {
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
            return  Traiter_date(date,joursFeries);
        }
        // pas de changement
        return date;
    }
}