using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{
    
    public class HiHandler : ResponseHandler
    {
        public HiHandler(TelebotCore telebotCore) : base(telebotCore) { }

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            string input = telebotCore.Text;
            if (input.Contains("hi") || input.Contains("您好") || input.Contains("你好"))
            {
                telebotCore.RobotApi(telebotCore.UserId,"你好!我是三方小助手，請問有什麼能幫助您的地方呢?");
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }
}