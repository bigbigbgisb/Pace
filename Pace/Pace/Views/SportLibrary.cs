using System;
using System.Collections.Generic;
using System.Text;
using Pace.ViewModels;

namespace Pace.Views
{
    public static class SportLibrary
    {

        public class DumbbellBicepsCurl : ISportItem
        {
            public string Id { get; init; } = "DumbbellBicepsCurl";
            public string PreviewContent { get; init; } = "哑铃弯举";
            public string MainContent { get; init; } = "双手持哑铃，肘部固定，弯举至胸前。";
            public float MuscleCoefficient { get; init; } = 0.85f;
            public float CardioCoefficient { get; init; } = 0.25f;
            public float AnaerobicCoefficient { get; init; } = 0.70f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 61;
            public string LegendRootPath { get; init; } = "SportItemImages\\DumbbellBicepsCurl";
        }

        public class Plank : ISportItem
        {
            public string Id { get; init; } = "Plank";
            public string PreviewContent { get; init; } = "平板支撑";
            public string MainContent { get; init; } = "肘部与前臂撑地，身体保持一条直线。";
            public float MuscleCoefficient { get; init; } = 0.70f;
            public float CardioCoefficient { get; init; } = 0.30f;
            public float AnaerobicCoefficient { get; init; } = 0.60f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 53;
            public string LegendRootPath { get; init; } = "SportItemImages\\Plank";
        }

        public class Squat : ISportItem
        {
            public string Id { get; init; } = "Squat";
            public string PreviewContent { get; init; } = "深蹲";
            public string MainContent { get; init; } = "双脚与肩同宽，下蹲至大腿接近水平后站起。";
            public float MuscleCoefficient { get; init; } = 0.80f;
            public float CardioCoefficient { get; init; } = 0.50f;
            public float AnaerobicCoefficient { get; init; } = 0.70f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 88;
            public string LegendRootPath { get; init; } = "";
        }

        public class PushUp : ISportItem
        {
            public string Id { get; init; } = "PushUp";
            public string PreviewContent { get; init; } = "俯卧撑";
            public string MainContent { get; init; } = "双手撑地，身体保持直线，屈肘下压后推起。";
            public float MuscleCoefficient { get; init; } = 0.85f;
            public float CardioCoefficient { get; init; } = 0.35f;
            public float AnaerobicCoefficient { get; init; } = 0.70f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 88;
            public string LegendRootPath { get; init; } = "";
        }

        public class PullUp : ISportItem
        {
            public string Id { get; init; } = "PullUp";
            public string PreviewContent { get; init; } = "引体向上";
            public string MainContent { get; init; } = "正握单杠，背部发力将身体拉起至下巴过杠。";
            public float MuscleCoefficient { get; init; } = 0.95f;
            public float CardioCoefficient { get; init; } = 0.30f;
            public float AnaerobicCoefficient { get; init; } = 0.85f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 140;
            public string LegendRootPath { get; init; } = "";
        }

        public class SitUp : ISportItem
        {
            public string Id { get; init; } = "SitUp";
            public string PreviewContent { get; init; } = "仰卧起坐";
            public string MainContent { get; init; } = "仰卧屈膝，腹部发力坐起后缓慢下放。";
            public float MuscleCoefficient { get; init; } = 0.60f;
            public float CardioCoefficient { get; init; } = 0.30f;
            public float AnaerobicCoefficient { get; init; } = 0.50f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 67;
            public string LegendRootPath { get; init; } = "";
        }

        public class JumpingJack : ISportItem
        {
            public string Id { get; init; } = "JumpingJack";
            public string PreviewContent { get; init; } = "开合跳";
            public string MainContent { get; init; } = "双脚开合跳跃，同时双臂上下摆动。";
            public float MuscleCoefficient { get; init; } = 0.40f;
            public float CardioCoefficient { get; init; } = 0.90f;
            public float AnaerobicCoefficient { get; init; } = 0.50f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 140;
            public string LegendRootPath { get; init; } = "";
        }

        public class HighKnees : ISportItem
        {
            public string Id { get; init; } = "HighKnees";
            public string PreviewContent { get; init; } = "高抬腿";
            public string MainContent { get; init; } = "原地快速交替抬腿，膝盖尽量抬至髋部高度。";
            public float MuscleCoefficient { get; init; } = 0.50f;
            public float CardioCoefficient { get; init; } = 0.95f;
            public float AnaerobicCoefficient { get; init; } = 0.60f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 158;
            public string LegendRootPath { get; init; } = "";
        }

        public class Burpee : ISportItem
        {
            public string Id { get; init; } = "Burpee";
            public string PreviewContent { get; init; } = "波比跳";
            public string MainContent { get; init; } = "下蹲、俯卧撑、收腿、起跳连贯完成。";
            public float MuscleCoefficient { get; init; } = 0.80f;
            public float CardioCoefficient { get; init; } = 0.95f;
            public float AnaerobicCoefficient { get; init; } = 0.90f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 175;
            public string LegendRootPath { get; init; } = "";
        }

        public class Deadlift : ISportItem
        {
            public string Id { get; init; } = "Deadlift";
            public string PreviewContent { get; init; } = "硬拉";
            public string MainContent { get; init; } = "屈髋屈膝握杠，背部挺直，伸髋站起。";
            public float MuscleCoefficient { get; init; } = 0.95f;
            public float CardioCoefficient { get; init; } = 0.30f;
            public float AnaerobicCoefficient { get; init; } = 0.90f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 105;
            public string LegendRootPath { get; init; } = "";
        }

        public class BenchPress : ISportItem
        {
            public string Id { get; init; } = "BenchPress";
            public string PreviewContent { get; init; } = "卧推";
            public string MainContent { get; init; } = "仰卧推凳，双手握杠，将杠铃推起至手臂伸直。";
            public float MuscleCoefficient { get; init; } = 0.90f;
            public float CardioCoefficient { get; init; } = 0.25f;
            public float AnaerobicCoefficient { get; init; } = 0.80f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 88;
            public string LegendRootPath { get; init; } = "";
        }

        public class Running : ISportItem
        {
            public string Id { get; init; } = "Running";
            public string PreviewContent { get; init; } = "跑步";
            public string MainContent { get; init; } = "中等配速持续跑步。";
            public float MuscleCoefficient { get; init; } = 0.40f;
            public float CardioCoefficient { get; init; } = 0.95f;
            public float AnaerobicCoefficient { get; init; } = 0.40f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 145;
            public string LegendRootPath { get; init; } = "";
        }

        public class Cycling : ISportItem
        {
            public string Id { get; init; } = "Cycling";
            public string PreviewContent { get; init; } = "骑行";
            public string MainContent { get; init; } = "中等强度持续骑行。";
            public float MuscleCoefficient { get; init; } = 0.50f;
            public float CardioCoefficient { get; init; } = 0.85f;
            public float AnaerobicCoefficient { get; init; } = 0.40f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 119;
            public string LegendRootPath { get; init; } = "";
        }

        public class Swimming : ISportItem
        {
            public string Id { get; init; } = "Swimming";
            public string PreviewContent { get; init; } = "游泳";
            public string MainContent { get; init; } = "自由泳或蛙泳等中等强度游泳。";
            public float MuscleCoefficient { get; init; } = 0.70f;
            public float CardioCoefficient { get; init; } = 0.90f;
            public float AnaerobicCoefficient { get; init; } = 0.50f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 123;
            public string LegendRootPath { get; init; } = "";
        }

        public class Yoga : ISportItem
        {
            public string Id { get; init; } = "Yoga";
            public string PreviewContent { get; init; } = "瑜伽";
            public string MainContent { get; init; } = "体式保持与呼吸配合。";
            public float MuscleCoefficient { get; init; } = 0.30f;
            public float CardioCoefficient { get; init; } = 0.25f;
            public float AnaerobicCoefficient { get; init; } = 0.10f;
            public float StretchCoefficient { get; init; } = 0.80f;
            public short BurnedCalories { get; init; } = 44;
            public string LegendRootPath { get; init; } = "";
        }

        public class Stretching : ISportItem
        {
            public string Id { get; init; } = "Stretching";
            public string PreviewContent { get; init; } = "拉伸";
            public string MainContent { get; init; } = "静态拉伸主要肌群，每个动作保持。";
            public float MuscleCoefficient { get; init; } = 0.10f;
            public float CardioCoefficient { get; init; } = 0.10f;
            public float AnaerobicCoefficient { get; init; } = 0.05f;
            public float StretchCoefficient { get; init; } = 0.90f;
            public short BurnedCalories { get; init; } = 40;
            public string LegendRootPath { get; init; } = "";
        }

        public class JumpRope : ISportItem
        {
            public string Id { get; init; } = "JumpRope";
            public string PreviewContent { get; init; } = "跳绳";
            public string MainContent { get; init; } = "原地连续跳绳。";
            public float MuscleCoefficient { get; init; } = 0.50f;
            public float CardioCoefficient { get; init; } = 0.95f;
            public float AnaerobicCoefficient { get; init; } = 0.60f;
            public float StretchCoefficient { get; init; } = 0.10f;
            public short BurnedCalories { get; init; } = 175;
            public string LegendRootPath { get; init; } = "";
        }

        public class MountainClimber : ISportItem
        {
            public string Id { get; init; } = "MountainClimber";
            public string PreviewContent { get; init; } = "登山跑";
            public string MainContent { get; init; } = "俯撑姿势下快速交替提膝。";
            public float MuscleCoefficient { get; init; } = 0.60f;
            public float CardioCoefficient { get; init; } = 0.90f;
            public float AnaerobicCoefficient { get; init; } = 0.70f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 140;
            public string LegendRootPath { get; init; } = "";
        }

        public class GluteBridge : ISportItem
        {
            public string Id { get; init; } = "GluteBridge";
            public string PreviewContent { get; init; } = "臀桥";
            public string MainContent { get; init; } = "仰卧屈膝，臀部发力抬起至身体成直线。";
            public float MuscleCoefficient { get; init; } = 0.50f;
            public float CardioCoefficient { get; init; } = 0.20f;
            public float AnaerobicCoefficient { get; init; } = 0.40f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 53;
            public string LegendRootPath { get; init; } = "";
        }

        public class SidePlank : ISportItem
        {
            public string Id { get; init; } = "SidePlank";
            public string PreviewContent { get; init; } = "侧平板支撑";
            public string MainContent { get; init; } = "单侧前臂撑地，身体保持一条直线。";
            public float MuscleCoefficient { get; init; } = 0.65f;
            public float CardioCoefficient { get; init; } = 0.25f;
            public float AnaerobicCoefficient { get; init; } = 0.50f;
            public float StretchCoefficient { get; init; } = 0.25f;
            public short BurnedCalories { get; init; } = 53;
            public string LegendRootPath { get; init; } = "";
        }

        public class Lunge : ISportItem
        {
            public string Id { get; init; } = "Lunge";
            public string PreviewContent { get; init; } = "弓步蹲";
            public string MainContent { get; init; } = "向前迈步下蹲，后膝接近地面后站起。";
            public float MuscleCoefficient { get; init; } = 0.80f;
            public float CardioCoefficient { get; init; } = 0.45f;
            public float AnaerobicCoefficient { get; init; } = 0.65f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 88;
            public string LegendRootPath { get; init; } = "";
        }

        public class Crunch : ISportItem
        {
            public string Id { get; init; } = "Crunch";
            public string PreviewContent { get; init; } = "卷腹";
            public string MainContent { get; init; } = "仰卧屈膝，腹部发力将肩胛骨抬离地面。";
            public float MuscleCoefficient { get; init; } = 0.60f;
            public float CardioCoefficient { get; init; } = 0.25f;
            public float AnaerobicCoefficient { get; init; } = 0.50f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 67;
            public string LegendRootPath { get; init; } = "";
        }

        public class RussianTwist : ISportItem
        {
            public string Id { get; init; } = "RussianTwist";
            public string PreviewContent { get; init; } = "俄罗斯转体";
            public string MainContent { get; init; } = "坐姿屈膝后仰，双手左右转体触地。";
            public float MuscleCoefficient { get; init; } = 0.60f;
            public float CardioCoefficient { get; init; } = 0.30f;
            public float AnaerobicCoefficient { get; init; } = 0.55f;
            public float StretchCoefficient { get; init; } = 0.20f;
            public short BurnedCalories { get; init; } = 70;
            public string LegendRootPath { get; init; } = "";
        }

        public class KettlebellSwing : ISportItem
        {
            public string Id { get; init; } = "KettlebellSwing";
            public string PreviewContent { get; init; } = "壶铃摇摆";
            public string MainContent { get; init; } = "屈髋发力将壶铃摆至胸前高度。";
            public float MuscleCoefficient { get; init; } = 0.85f;
            public float CardioCoefficient { get; init; } = 0.70f;
            public float AnaerobicCoefficient { get; init; } = 0.85f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 172;
            public string LegendRootPath { get; init; } = "";
        }

        public class RowingMachine : ISportItem
        {
            public string Id { get; init; } = "RowingMachine";
            public string PreviewContent { get; init; } = "划船机";
            public string MainContent { get; init; } = "腿、核心、手臂依次发力拉桨。";
            public float MuscleCoefficient { get; init; } = 0.75f;
            public float CardioCoefficient { get; init; } = 0.85f;
            public float AnaerobicCoefficient { get; init; } = 0.60f;
            public float StretchCoefficient { get; init; } = 0.15f;
            public short BurnedCalories { get; init; } = 123;
            public string LegendRootPath { get; init; } = "";
        }

        public static List<ISportItem> AllSports { get; } =
        [
            new DumbbellBicepsCurl(),
            new Plank(),
            new Squat(),
            new PushUp(),
            new PullUp(),
            new SitUp(),
            new JumpingJack(),
            new HighKnees(),
            new Burpee(),
            new Deadlift(),
            new BenchPress(),
            new Running(),
            new Cycling(),
            new Swimming(),
            new Yoga(),
            new Stretching(),
            new JumpRope(),
            new MountainClimber(),
            new GluteBridge(),
            new SidePlank(),
            new Lunge(),
            new Crunch(),
            new RussianTwist(),
            new KettlebellSwing(),
            new RowingMachine(),
        ];

    }
}