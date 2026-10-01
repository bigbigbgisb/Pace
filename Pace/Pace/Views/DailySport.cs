using Avalonia;
using Avalonia.Media;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pace.ViewModels
{
    public class Margin(double left, double top, double right, double bottom)
    {
        public double Left { get; set; } = left;
        public double Top { get; set; } = top;
        public double Right { get; set; } = right;
        public double Bottom { get; set; } = bottom;
    }
    public class DailySport(ISportItem[] sportItems)
    {
        public Thickness Margin { get; set; }
        public ISportItem[] SportItems { get; set; } = sportItems;

        public void SetMargin(Thickness margin)
        {
            Margin = margin;
        }
        public IdDailySport ToIdDailySport()
        {
            List<string> dailySports = [];
            foreach (var sportItem in SportItems)
            {
                dailySports.Add(sportItem.Id);
            }
            return new IdDailySport(new Margin(Margin.Left,Margin.Top,Margin.Right,Margin.Bottom),[..dailySports]);
            
        }

    }
    public class IdDailySport(Margin margin, string[] sportItemsIds)
    {

        public Margin Margin { get; init; } = margin;
        public string[] SportItemsIds { get; init; } = sportItemsIds;
        public DailySport ToDailySport()
        {
            List<ISportItem> sportItems = [];
            foreach(var id in SportItemsIds)
            {
                if (SportLibrary.AllSports.Find(s => s.Id == id) is ISportItem sportItem)
                    sportItems.Add(sportItem);
                else throw new ArgumentException();
            }
            return new DailySport([.. sportItems]) { Margin = new Thickness(Margin.Left, Margin.Top, Margin.Right, Margin.Bottom) };
        }


    }
}
