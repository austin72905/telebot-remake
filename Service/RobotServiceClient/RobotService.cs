using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotRemake.Models;
using TelebotRemake.Service.Chain;

namespace TelebotRemake.Service
{
    public class RobotService : TelebotCore
    {
        public override string Token => "your-token";

        protected override List<ResponseHandler> replyChainList => InitChainList();


        //建構子
        public RobotService(TelegramMessage telegramMessage) : base(telegramMessage){}
        

        /// <summary>
        /// 主要回應方式
        /// </summary>
        public override void RobotResponse()
        {
            //小於5G警示
            NotifyAvailableSpace("");
            
            //校驗id
            if(!VerifyUserId(0,""))
            {

            }

            //責任鍊模式
            //判斷輸入，來決定由哪個類回應 
            //從地一個元素開始往下判斷由哪個類處理
            replyChainList[0].ReplyToUser(this);
        }

        /// <summary>
        /// 可以覆寫，自訂責任鍊
        /// </summary>
        /// <returns></returns>
        protected override List<ResponseHandler> InitChainList()
        {
            return base.InitChainList();
        }
    }
}