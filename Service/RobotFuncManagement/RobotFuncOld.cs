using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service
{
    public class RobotFuncOld: RobotFuncCore
    {
        
        public RobotFuncOld(ResponseHandler responseHandler) : base(responseHandler)
        {

        }

        //想要實作的方法可以在這邊覆寫
        public override void CheckCmder(string cmder, int userid, string text, string who, string freespace = "")
        {
            _responseHandler.RobotApi(userid, "此機器人目前沒有此功能");
        }

        public override void QueryRecord(int userid, string record)
        {
            _responseHandler.RobotApi(userid, "此機器人目前沒有此功能");
        }
    }
}