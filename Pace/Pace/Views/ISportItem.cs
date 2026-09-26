using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pace.Views
{
    public interface ISportItem
    {
        public abstract string PreviewContent { get; }
        public abstract string MainContent { get; }
        public abstract float MuscleCoefficient { get; }
        public abstract float CardioCoefficient { get; }    
        public abstract float AnaerobicCoefficient { get; } 
        public abstract float StretchCoefficient { get; }   
        public abstract short BurnedCalories { get; }
        public abstract string LegendRootPath { get; }


    }
}
