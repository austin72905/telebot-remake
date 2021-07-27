using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotRemake.Service.Chain
{
    public class PayUrlHandler : ResponseHandler
    {
        public PayUrlHandler(TelebotCore telebotCore) : base(telebotCore) { }

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            string input = telebotCore.Text;
            if (input.Contains(".")&&!input.StartsWith("/"))
            {
                _robotFunc.QueryPayUrl(telebotCore.UserId,telebotCore.Text);
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }
}