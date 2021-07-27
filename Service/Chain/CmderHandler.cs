using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{    
    public class CmderHandler : ResponseHandler
    {
        public CmderHandler(TelebotCore telebotCore) : base(telebotCore) { }
        
        public override void ReplyToUser(TelebotCore telebotCore)
        {
            if (telebotCore.Text.StartsWith("/") && telebotCore.UserLevel!="3")
            {
                string[] cmd = telebotCore.Text.Split(' ');
                _robotFunc.CheckCmder(cmd[0],telebotCore.UserId,telebotCore.Text,telebotCore.FirstName);
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }

        //也可以覆寫，可以在這邊調整ID，反正可以調用到telebot core 的 robot api
        public override void RobotApi(int userid, string text)
        {
            base.RobotApi(userid, text);
        }
    }
}