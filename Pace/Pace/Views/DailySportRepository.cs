using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pace.Views
{
    public class DailySportRepository
    {
        public List<DailySport> DailySports { get; set; } = [];
        public void SetMargins()
        {
            for (int i = 1; i <= DailySports.Count; i++)
            {
                DailySports[i - 1].SetMargin(new Avalonia.Thickness(128 * Math.Sin(Math.PI / 2 / 3 * i), 0, 0, 32));
            }
        }
    }
}
