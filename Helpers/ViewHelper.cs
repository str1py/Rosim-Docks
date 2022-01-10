using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RosreestDocks.Helpers
{
    public class ViewHelper
    {
        public string GetAgencyName(AgencyModel agency)
        {
            if (String.IsNullOrEmpty(agency.ShortName))
                return agency.Name;
            else return agency.ShortName;
        }

        public string GetInitials(User user)
        {
            char fname = user.FirstName.FirstOrDefault();
            char mname = user.MiddleName.FirstOrDefault();

            return (user.LastName + " " + fname + ". " + mname + ".");

        }

        public List<string> GetColor(DateTime date)
        {
            var a = date - DateTime.Now;
            string color = "";
            if (a.Days <= 3)
                color = "#ff2400";
            else if (a.Days <= 6 && a.Days > 3)
                color = "#fde910";
            else color = "#228b22";

            string days = "";

            if (a.Days == 0)
                days = "менее 1 дня";
            else if (a.Days == 1)
                days = "1 день";
            else if (a.Days > 1 && a.Days < 5)
                days = $"{a.Days} дня";
            else
                days = $"{Math.Abs(a.Days)} дней";

            var ost = "";
            if (a.Days < 0)
                ost = $"просрочка {days}";
            else ost = $"осталось {days}";


            List<string> list = new();
            list.Add(color);
            list.Add(ost);

            return list;
        }
    }
}
