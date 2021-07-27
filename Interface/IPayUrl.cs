using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelebotRemake.Interface
{
    public interface IPayUrl
    {
        void QueryPayUrl(int userid,string payUrl);
    }
}
