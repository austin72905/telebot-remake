namespace TelebotRemake.Service
{
    public abstract class ResponseHandler
    {
        
        protected ResponseHandler _handler;
        private TelebotCore _telebotCore;
      
        protected  RobotFuncCore _robotFunc;

        //建構子
        public ResponseHandler(TelebotCore telebotCore)
        {
            _telebotCore = telebotCore;
            _robotFunc = new RobotFunc(this);

        }
        
        /// <summary>
        /// 設定下一個接手責任的是誰
        /// </summary>
        /// <param name="handler"></param>
        public void SetHandler(ResponseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// 改變實作細節的類
        /// </summary>
        /// <param name="robotFuncCore"></param>
        public void SetRobotFunc(RobotFuncCore robotFuncCore)
        {
            _robotFunc = robotFuncCore;          
        }

        /// <summary>
        /// 回傳給用戶的訊息
        /// </summary>
        /// <param name="telebotCore"></param>
        public abstract void ReplyToUser(TelebotCore telebotCore);

        /// <summary>
        /// 實際上調用的是telebotCore 的 RobotApi
        /// </summary>
        public virtual void RobotApi(int userid, string text)
        {
            _telebotCore.RobotApi(userid, text);

        }
    }
}