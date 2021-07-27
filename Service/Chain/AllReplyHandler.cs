using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{   
    public class AllReplyHandler : ResponseHandler
    {
        //建構子
        public AllReplyHandler(TelebotCore telebotCore) : base(telebotCore) {}       

        /// <summary>
        /// 回復用戶訊息
        /// </summary>
        /// <param name="telebotCore"></param>
        public override void ReplyToUser(TelebotCore telebotCore)
        {
            if (telebotCore.Reply_To_Message!=null)
            {
                if(telebotCore.UserId==1024567|| telebotCore.UserId == 1024568)
                {
                    //廣播 or reply
                    _robotFunc.ReplyMessage(telebotCore.Reply_To_Message,telebotCore.Text,telebotCore.Sticker);
                }
                else
                {
                    //回垃圾話
                }
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }
}