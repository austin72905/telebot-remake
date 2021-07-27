using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotRemake.Interface;
using TelebotRemake.Models;

namespace TelebotRemake.Service
{
    public class RobotReplyMsgMethod : ApiMethod, IReply_To_Message
    {
        public RobotReplyMsgMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }

       
        public void ReplyMessage(Reply_To_Message reply, string text, Sticker sticker)
        {
            _robotFuncCore.RobotApi(int.Parse(text), text);
        }
        
    }
}