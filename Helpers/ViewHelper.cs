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
            string bgcolor = "";
            string txtcolor = "";
            if (a.Days <= 3)
            {
                bgcolor = "rgba(169, 43, 43, 0.2)"; //red
                txtcolor = "#a9422b"; //red
            }
            else if (a.Days <= 6 && a.Days > 3)
            {
                bgcolor = "rgba(150, 169, 43, 0.2)"; //yellow
                txtcolor = "#a98e2b"; //yellow
            }
            else
            {
                bgcolor = "rgba(43, 169, 114, 0.2)"; //green
                txtcolor = "#2ba972"; //green
            }

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
            list.Add(bgcolor);
            list.Add(txtcolor);
            list.Add(ost);

            return list;
        }

    }
}
