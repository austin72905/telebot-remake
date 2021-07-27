using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{   
    public class TrashTalkHandler : ResponseHandler
    {
        public TrashTalkHandler(TelebotCore telebotCore) : base(telebotCore) { }

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            RobotApi(telebotCore.UserId,"垃圾話");
        }
    }
}