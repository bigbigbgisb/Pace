using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Pace.Views
{
    public class SportGenerateService
    {
        public async Task<DailySport> GenerateDailySports(short basalMetabolicRate, float height, float weight)
        {
            var sportsList = new List<ISportItem>();
            //标准参数
            var standardCoefficient = (1, 1.2, 0.8, 1.5);
            //基数0.3，考虑到肥胖人群的运动困难，与体重反相关
            double multiplyCoefficient = 0.3 + (height * 0.8 - weight * 0.9 + basalMetabolicRate * 0.1) / 400;
            var personalCoefficient = (standardCoefficient.Item1 * multiplyCoefficient, standardCoefficient.Item2 * multiplyCoefficient, standardCoefficient.Item3 * multiplyCoefficient, standardCoefficient.Item4 * multiplyCoefficient);

            //简单的贪心策略进行填充
            var currentCoefficient = (0.0, 0.0, 0.0, 0.0);
            bool quitCondition = false;
            bool AllReachedTarget((double, double, double, double) source, (double, double, double, double) target)
            {
                if (source.Item1 > target.Item1  && source.Item2 > target.Item2  && source.Item3 > target.Item3 && source.Item4 > target.Item4 ) return true;
                else return false;
            }
            bool AllLowerTarget((double, double, double, double) source, (double, double, double, double) target)
            {
                if (source.Item1 < target.Item1 + 0.1 && source.Item2 < target.Item2 + 0.1 && source.Item3 < target.Item3 + 0.1 && source.Item4 < target.Item4 + 0.1) return true;
                else return false;
            }
            int loopLimit = 200000;
            int index = 0;
            await Task.Run(() =>
            {
                while (!(quitCondition || (index > loopLimit)))

                {
                    var shuffledSports = SportLibrary.AllSports.OrderBy(x => Random.Shared.Next()).ToList();
                    foreach (ISportItem sportItem in shuffledSports)
                    {
                        if (AllReachedTarget(currentCoefficient, personalCoefficient)) { quitCondition = true; break; }
                        var currentAdditionCoefficient = (currentCoefficient.Item1 + sportItem.MuscleCoefficient, currentCoefficient.Item2 + sportItem.CardioCoefficient, currentCoefficient.Item3 + sportItem.AnaerobicCoefficient, currentCoefficient.Item4 + sportItem.StretchCoefficient);
                        if (AllLowerTarget(currentAdditionCoefficient, personalCoefficient))
                        {
                            currentCoefficient.Item1 += sportItem.MuscleCoefficient;
                            currentCoefficient.Item2 += sportItem.CardioCoefficient;
                            currentCoefficient.Item3 += sportItem.AnaerobicCoefficient;
                            currentCoefficient.Item4 += sportItem.StretchCoefficient;
                            sportsList.Add(sportItem);
                            break;
                        }

                    }
                    index++;
                }
            });
            return new DailySport([..sportsList]);
        }
    }
}
