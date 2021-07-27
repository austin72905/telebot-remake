using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelebotRemake.Models;

namespace TelebotRemake.Interface
{
    public interface IReply_To_Message
    {
        void ReplyMessage(Reply_To_Message reply, string text, Sticker sticker);
    }
}
