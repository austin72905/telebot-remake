using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TelebotRemake.Models;
using TelebotRemake.Service.Chain;

namespace TelebotRemake.Service
{
    public abstract class TelebotCore
    {
        //每個機器人獨一無二的token
        public abstract string Token { get; }

        protected virtual List<ResponseHandler> replyChainList => InitChainList();

        //三方名稱
        private List<string> _payName;
        public virtual List<string> PayName
        {
            get
            {
                if (_payName == null)
                {
                    _payName = new List<string>() { "支付1", "支付2", "支付3" };
                }
                return _payName;
            }
            set
            {

            }
        }

        
        public TelebotCore(TelegramMessage telegramMessage)
        {
            UserId = telegramMessage.message.from.id;
            Text = telegramMessage.message.text;
            FirstName = telegramMessage.message.from.first_name;
            Sticker = telegramMessage.message.sticker;
            Reply_To_Message = telegramMessage.message.reply_to_message;
            Forward_From = telegramMessage.message.forward_from;

            UserLevel = CheckLvl(UserId);
        }

        //以下為核心方法

        public abstract void RobotResponse();

        /// <summary>
        /// 校驗用戶ID
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual bool VerifyUserId(int Userid,string text)
        {
            return true;
        }

        /// <summary>
        /// 確認用戶等級
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        public virtual string CheckLvl(int Userid)
        {
            return "2";
        }

        public virtual void NotifyAvailableSpace(string freesapce)
        {

        }

        public void RobotApi(int chat_id, string text)
        {
            Task.Run(async () =>
            {
                var httpclient = new HttpClient();
                string baseUrl = "https://api.telegram.org/bot";
                var postdata = new Dictionary<string, string>()
                {
                    { "chat_id",chat_id.ToString()},
                    { "text",text},
                    { "parsr_mode","HTML"}
                };
                string url = $"{baseUrl}{Token}/sendMessage";

                var content = new FormUrlEncodedContent(postdata);
                var response = await httpclient.PostAsync(url, content);
            });
        }


        /// <summary>
        /// 初始化責任鍊
        /// </summary>
        /// <returns></returns>
        protected virtual List<ResponseHandler> InitChainList()
        {
            var replyChainList = new List<ResponseHandler>()
            {
                //順序不能錯

                //轉傳
                //機器人新增白名單功能
                new ForwardHandler(this),
                //廣播or 回覆特定人
                new AllReplyHandler(this),
                //查訂單
                new RecordHandler(this),
                //查網關
                new PayUrlHandler(this),
                //查第三方支付方式
                new PaySetHandler(this),
                //使用 cmder 指令
                new CmderHandler(this),
                //回應廢話
                new HiHandler(this),
                //回應廢話
                new TrashTalkHandler(this)
            };

            //設定下一個接手責任的是誰(這邊是按造list 順序)
            for (int i = 0; i < replyChainList.Count ; i++)
            {
                if (i != replyChainList.Count - 1)
                {
                    replyChainList[i].SetHandler(replyChainList[i + 1]);
                }
                
            }

            return replyChainList;

        }

       
        public int UserId { get; }
        public string Text { get; }
        public string FirstName { get; }
        public Sticker Sticker { get; }
        public Reply_To_Message Reply_To_Message { get; }
        public Forward_From Forward_From { get; }
        public string UserLevel { get; }
        public int RespContent { get; }
    }
}