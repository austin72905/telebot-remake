using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{
    public class RecordHandler : ResponseHandler
    {
        public RecordHandler(TelebotCore telebotCore) : base(telebotCore) { }

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            string input =telebotCore.Text;
            if (input.StartsWith("RK") || input.StartsWith("TX") || input.StartsWith("801"))
            {
                _robotFunc.QueryRecord(telebotCore.UserId,telebotCore.Text);
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }
}