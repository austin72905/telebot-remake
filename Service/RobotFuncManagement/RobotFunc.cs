using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotRemake.Interface;

namespace TelebotRemake.Service
{
    public class RobotFunc: RobotFuncCore
    {   
       
        //預設的實作細節 
        public RobotFunc(ResponseHandler responseHandler):base(responseHandler)
        {
            //可以在這邊自訂要實作細節的類
            //繼承 ApiMethod, IRecord 的類都可以使用
            //Set_cmder(new RobotCmderMethod(this));
        }

    }
}