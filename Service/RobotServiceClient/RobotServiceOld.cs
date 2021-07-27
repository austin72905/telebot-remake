using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotRemake.Models;
using TelebotRemake.Service.Chain;

namespace TelebotRemake.Service
{
    public class RobotServiceOld : TelebotCore
    {
        public override string Token => "your-token";

        protected override List<ResponseHandler> replyChainList => InitChainList();

        //假設舊機器人想用不同的資料庫
        public override List<string> PayName => new List<string> {"支付3", "支付4", "支付5" };
        //建構子
        public RobotServiceOld(TelegramMessage telegramMessage) : base(telegramMessage){ }
        public override void RobotResponse()
        {
                   
            replyChainList[0].ReplyToUser(this);
            
        }

        /// <summary>
        /// 自訂責任鍊，假設這個機器人我不想做機器人加白名單功能，註解即可
        /// </summary>
        /// <returns></returns>
        protected override List<ResponseHandler> InitChainList()
        {
            //將功能拆成模塊，也可以自訂模塊，只要繼承 ResponseHandler 都可
            var replyChainList = new List<ResponseHandler>()
            {
                //順序不能錯

                //轉傳
                //機器人新增白名單功能
                //new ForwardHandler(this),
                //廣播or 回覆特定人
                new AllReplyHandler(this),
                //查訂單
                new RecordHandler(this),
                //查網關
                new PayUrlHandler(this),
                //查第三方支付方式
                new PaySetHandler(this),
                //使用 cmder 指令
                new CmderHandler(this),
                //回應廢話
                new HiHandler(this),
                //回應廢話
                new TrashTalkHandler(this)
            };

            //設定下一個接手責任的是誰(這邊是按造list 順序)
            for (int i = 0; i < replyChainList.Count; i++)
            {
                if (i != replyChainList.Count - 1)
                {
                    replyChainList[i].SetHandler(replyChainList[i + 1]);
                }
                //修改要實作的類
                replyChainList[i].SetRobotFunc(new RobotFuncOld(replyChainList[i]));

            }

            return replyChainList;
        }
       
    }
}