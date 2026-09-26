using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pace.Views
{
    public class DailySport(ISportItem[] sportItems)
    {
        public Thickness Margin { get; set; }
        public ISportItem[] SportItems { get; set; } = sportItems;

        public void SetMargin(Thickness margin)
        {
            Margin = margin;
        }
    }
}
