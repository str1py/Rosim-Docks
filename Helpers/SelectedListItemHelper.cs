using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using RosreestDocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RosreestDocks.Helpers
{
    public static class SelectedListItemHelper
    {
        public static List<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> collection, int? selecteditem = null)
       where T : ISelectable
        {
            var catList = new List<SelectListItem>();
            foreach (var cat in collection)
                catList.Add(new SelectListItem { Text = cat.Name, Value = cat.Id.ToString(), Selected = false });

            if (selecteditem != null)
            {
                var selected = catList.Where(x => x.Value == selecteditem.ToString()).First();
                selected.Selected = true;
            }

            return catList;
        }


        public static string FirstCharToUpper(this string input) =>
              input switch
              {
                  null => "",
                  "" => "",
                  _ => input.First().ToString().ToUpper() + input.Substring(1)
              };
    }
}
