using Avalonia;
using Avalonia.Media;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pace.ViewModels
{

    public class DailySport(ISportItem[] sportItems)
    {
        public ISportItem[] SportItems { get; set; } = sportItems;

        public IdDailySport ToIdDailySport()
        {
            List<string> dailySports = [];
            foreach (var sportItem in SportItems)
            {
                dailySports.Add(sportItem.Id);
            }
            return new IdDailySport([.. dailySports]);

        }

    }
    public class IdDailySport(string[] sportItemsIds)
    {

        public string[] SportItemsIds { get; init; } = sportItemsIds;
        public DailySport ToDailySport()
        {
            List<ISportItem> sportItems = [];
            foreach (var id in SportItemsIds)
            {
                if (SportLibrary.AllSports.Find(s => s.Id == id) is ISportItem sportItem)
                    sportItems.Add(sportItem);
                else throw new ArgumentException();
            }
            return new DailySport([.. sportItems]) ;
        }


    }
}
