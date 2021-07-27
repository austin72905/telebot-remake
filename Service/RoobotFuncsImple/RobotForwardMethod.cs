using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotRemake.Interface;

namespace TelebotRemake.Service
{
    public class RobotForwardMethod : ApiMethod, IForward
    {
        public RobotForwardMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void RobotAddWhite(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, text);
        }
       
    }
}