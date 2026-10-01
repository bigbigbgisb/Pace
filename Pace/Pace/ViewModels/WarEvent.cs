
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Xml.Serialization;

namespace Pace.ViewModels
{

    public abstract record WarEventBase
    {



        public abstract string[] Logs { get; }
        public abstract List<WarEventBase> ChildrenEvents { get; set; }
        public abstract string? Message { get; set; }
        public abstract DateTime? StartTime { get; set; }
        public abstract DateTime? EndTime { get; set; }

        /*this method for debug，just for debug you know,dont mind it
        public virtual void OutputSomeFuckingThings()
        {
            if (StartTime is not null && EndTime is not null)
            {
                Console.WriteLine($"新事件! {StartTime.Value:F} {Message}");
                foreach (var fuck in ChildrenEvents)
                {
                    Console.WriteLine($"{fuck.StartTime.Value:F} to {fuck.EndTime.Value:F} {fuck.Message}");
                }
            }

        }*/
        public virtual void CalculateChildrenEventsTriggerTime()
        {
            if (ChildrenEvents is not null && ChildrenEvents.Count > 0)
            {

                var averageTimePeriod = (EndTime - StartTime) / ChildrenEvents.Count;
                if (averageTimePeriod is null) return;
                for (int i = 0; i < ChildrenEvents.Count; i++)
                {
                    ChildrenEvents[i].StartTime = StartTime + (i * averageTimePeriod);
                    ChildrenEvents[i].EndTime = StartTime + ((i + 1) * averageTimePeriod);
                    if (ChildrenEvents[i].ChildrenEvents.Count > 0)
                    {
                        ChildrenEvents[i].CalculateChildrenEventsTriggerTime();
                        //ChildrenEvents[i].OutputSomeFuckingThings();
                    }


                }
            }

        }
        public WarEventBase()
        {
            if (ChildrenEvents is not null && ChildrenEvents.Count > 0)
            {
                for (int i = 0; i < ChildrenEvents.Count - 1; i++)
                {
                    if (ChildrenEvents[i].Logs.Length != ChildrenEvents[i + 1].Logs.Length) throw new ArgumentException("Children logs' length is not the same");
                }
                Random random = Random.Shared;

                int index = random.Next(0, ChildrenEvents[0].Logs.Length);
                foreach (var warEvent in ChildrenEvents)
                {
                    warEvent.Message = warEvent.Logs[index];
                }
                Message = Logs.Length > 0 ? Logs[0] : throw new ArgumentException("Cannot find root message");
            }
            else
            {
                //Wait for adding data
            }
        }

    }


}