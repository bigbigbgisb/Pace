
using System;
using System.Collections.Generic;
using System.Text;

namespace Pace.ViewModels
{
    public class WarEventLibrary
    {
        public record MainEvent : WarEventBase
        {
            private readonly WarEventGenerateService _warEventGenerateService = new();
            public override List<WarEventBase> ChildrenEvents { get; set; } = [];
            public override string? Message { get; set; }
            public override DateTime? StartTime { get; set; }
            public override DateTime? EndTime { get; set; }
            public override string[] Logs { get; } = [];
            public void GenerateChildrenEvents(DateTime startTime, DateTime endTime)
            {
                ChildrenEvents = [.. ChildrenEvents, .. _warEventGenerateService.GenerateChildrenEvents(startTime, endTime)];
                if (ChildrenEvents.Count > 15)
                {
                    for (int i = 0; i < ChildrenEvents.Count - 15; i++)
                    {
                        //Write(a[i]) to some fucking txt;
                        ChildrenEvents.RemoveAt(0);
                    }
                }
            }
            public MainEvent() : base()
            {

            }
            public void HandleAppendEvents()
            {
                if (StartTime is not null && EndTime is not null)
                    GenerateChildrenEvents(StartTime.Value, EndTime.Value);
                CalculateChildrenEventsTriggerTime();

            }

        }
        public record SeaAttackEvent : WarEventBase
        {
            private record SeaAttackSign : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "临海正在有一些...奇怪的船以40节的速度过来了??",//航母
                    "在海里游泳游泳的时候为何感觉，水像按摩池一样了呢?",//潜艇
                    "吼，今天打了这么多鱼啊，几百镑?不知道，走咯~那边的快艇是啥?沙滩游客吧估计...",//快艇突击
                    "..那是我们买的煤吗?是的!!翱特号!!欸，他为啥这么快冲向岸边呢.."//恐怖袭击
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record SeaAttackWarn : WarEventBase
            {
                public override string[] Logs { get; } = [
                    "这些船进入毗连区了!",//航母
                    "欸，怎么感觉自己突然游泳这么轻松了，浮起来了",//哈哈哈哈哈妈的，血有盐，加大了浮力哈哈哈哈
                    "额，这群人有身份证吗，为什么，他们是偷渡?",//快艇突击
                    "好吧，看来这个船要搁浅了...哎哟不错哦"//恐怖袭击
                    //搁浅?这让我想起了...
                    /*久未放晴的天空
                        依舊留著妳的笑容
                        哭過 卻無法掩埋歉疚
                        風箏在陰天擱淺
                        想念還在等待救援
                        我拉著線 複習妳給的溫柔
                        曝曬在一旁的寂寞
                        笑我給不起承諾
                        怎麼會怎麼會
                        妳竟原諒了我
                        我只能永遠讀著對白
                        讀著我給妳的傷害
                        我原諒不了我
                        就請妳當作我已不在
                        我睜開雙眼 看著空白
                        忘記妳對我的期待
                        讀完了依賴 我很快就離開
                        久未放晴的天空
                        依舊留著妳的笑容
                        哭過 卻無法掩埋歉疚
                        風箏在陰天擱淺
                        想念還在等待救援
                        我拉著線 複習妳給的溫柔
                        曝曬在一旁的寂寞
                        笑我給不起承諾
                        怎麼會怎麼會
                        妳竟原諒了我
                        我只能永遠讀著對白
                        讀著我給妳的傷害
                        我原諒不了我
                        就請妳當作我已不在
                        我睜開雙眼 看著空白
                        忘記妳對我的期待
                        讀完了依賴 我很快就
                        我只能永遠讀著對白
                        讀著我給妳的傷害
                        我原諒不了我
                        就請妳當作我已不在
                        我睜開雙眼 看著空白
                        忘記妳對我的期待
                        讀完了依賴 我很快就離開*/
                    ];
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record SeaAttackDanger : WarEventBase
            {
                public override string[] Logs { get; } = [
                    "他们已经进入了内海...",//航母
                    "咋感觉下半身空空的?",//哈哈哈哈哈妈的，血有盐，加大了浮力哈哈哈哈
                    "欸欸欸，你们想拿木头柄子换钱可以啊，前面的钢管是啥，我是木工——",//快艇突击
                    "爆炸的艺术"//恐怖袭击
                    ];

                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            public override List<WarEventBase> ChildrenEvents { get; set; } = [
                new SeaAttackSign(),
                new SeaAttackWarn(),
                new SeaAttackDanger(),
                ];
            public override string[] Logs { get; } = ["雷达一直在叫..."];
            public override string? Message { get; set; }
            public override DateTime? StartTime { get; set; }
            public override DateTime? EndTime { get; set; }
            public SeaAttackEvent() : base()
            {

            }
        }
        public record LandSoldierAttackEvent : WarEventBase
        {
            private record LandSoldierAttackSign : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "市长热线 : %#$(*%@ 滴—— 我们现'崩'——在在*#%国旁边种地啊，但是听到了很多放炮的的声音?你们快来—— '崩'——先挂了——",
                    "咦，这群人，弄啥嘞，走的这么整齐，大学生军训没必要来我们这内陆小村吧，是军校吗，还有枪子?",
                    "喂，妈。你们赶紧坐高铁跑吧，听我的，我已经润了，给你们买了G0x01->0x00次列车，一堆打仗的人进村了",
                    "哇塞塞塞塞，这就是枪吗，我从小玩模型，这是第一次见到啊...真想跑过去摸一摸，但是给我崩了就不好了，算了吧",

                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandSoldierAttackWarn : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "哎哟哟哟，哎哟哟，踩坏我的庄稼了!你们干啥呢!话说...你们是..怎么进来的??"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandSoldierAttackDanger : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "这些人是劳务派遣还是啥!!!为什么在首都一直——"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            public override List<WarEventBase> ChildrenEvents { get; set; } = [
                new LandSoldierAttackSign(),
                new LandSoldierAttackWarn(),
                new LandSoldierAttackDanger(),
            ];
            public override string[] Logs { get; } = ["今天的农收怎么少了呢?"];
            public override string? Message { get; set; }
            public override DateTime? StartTime { get; set; }
            public override DateTime? EndTime { get; set; }
            public LandSoldierAttackEvent() : base()
            {

            }

        }

        public record LandTankAttackEvent : WarEventBase
        {
            private record LandTankAttackSign : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "卫兵 : 今天怎么这么吵?早上五点就被吵醒了，唉，跑个五公里吧"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandTankAttackWarn : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "卫兵 : 这里是大西北啊...哪来的这么多坦克，嗯?"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandTankAttackDanger : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "我们完了..."
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            public override List<WarEventBase> ChildrenEvents { get; set; } = [
                new LandTankAttackSign(),
                new LandTankAttackWarn(),
                new LandTankAttackDanger(),
            ];
            public override string[] Logs { get; } = ["嗯，真是晴朗的一天，土真是干涩"];
            public override string? Message { get; set; }
            public override DateTime? StartTime { get; set; }
            public override DateTime? EndTime { get; set; }
            public LandTankAttackEvent() : base()
            {

            }
        }

        public record LandCannonAttackEvent : WarEventBase
        {
            private record LandCannonAttackSign : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "男孩 : 妈妈抬头，天上有好多流星!"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandCannonAttackWarn : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "男孩 : 欸，怎么有火光呢?"
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            private record LandCannonAttackDanger : WarEventBase
            {
                public override List<WarEventBase> ChildrenEvents { get; set; } = [];
                public override string[] Logs { get; } = [
                    "男孩 : '【轰!】'呜呜呜...全部'【轰!】'炸'【轰!】'了..."
                    ];
                public override string? Message { get; set; }
                public override DateTime? StartTime { get; set; }
                public override DateTime? EndTime { get; set; }
            }
            public override List<WarEventBase> ChildrenEvents { get; set; } = [
                new LandCannonAttackSign(),
                new LandCannonAttackWarn(),
                new LandCannonAttackDanger(),
            ];
            public override string[] Logs { get; } = ["哈，今天的天气真是晴朗，很适合放飞风筝"];
            public override string? Message { get; set; }
            public override DateTime? StartTime { get; set; }
            public override DateTime? EndTime { get; set; }
            public LandCannonAttackEvent() : base()
            {

            }
        }

    }

}
