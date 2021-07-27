using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{    
    public class PaySetHandler : ResponseHandler
    {
        public PaySetHandler(TelebotCore telebotCore) : base(telebotCore) { }     

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            if (telebotCore.PayName.Contains(telebotCore.Text))
            {
                _robotFunc.QueryPaySet(telebotCore.UserId,telebotCore.Text);
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }
}