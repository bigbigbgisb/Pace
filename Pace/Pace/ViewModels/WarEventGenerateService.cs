using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;


namespace Pace.ViewModels
{
    public class WarEventGenerateService
    {



        public Dictionary<int, Func<WarEventBase>> WarEventMappingTable { get; } = new()
        {
            [0] = () => new WarEventLibrary.SeaAttackEvent(),
            [1] = () => new WarEventLibrary.LandSoldierAttackEvent(),
            [2] = () => new WarEventLibrary.LandTankAttackEvent(),
            [3] = () => new WarEventLibrary.LandCannonAttackEvent(),

            //剩下的以后再说
        };
        public List<WarEventBase> GenerateChildrenEvents(DateTime startTime, DateTime endTime)
        {

            var offlineTime = endTime - startTime;
            if (offlineTime.TotalDays < 0)
            {
                throw new InvalidOperationException("Offline time belows zero");
            }
            int additionEventCount = Math.Min(10, (int)offlineTime.TotalDays);
            List<WarEventBase> warEvents = [];
            Random random = Random.Shared;
            void AddRandomElement(int i)
            {
                int index = random.Next(WarEventMappingTable.Count);
                WarEventBase warEventBase = WarEventMappingTable[index]();
                if (i == 0 || WarEventMappingTable.Count == 1)
                {
                    warEvents.Add(warEventBase);
                    return;
                }
                else if (!(warEvents[i - 1].GetType() == warEventBase.GetType()))
                {
                    warEvents.Add(warEventBase);
                    return;
                }
                else
                {
                    AddRandomElement(i);
                }


            }
            for (int i = 0; i < additionEventCount; i++)
            {
                AddRandomElement(i);
            }

            return warEvents;



        }
    }
}
