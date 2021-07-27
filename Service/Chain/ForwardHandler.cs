namespace TelebotRemake.Service.Chain
{

    public class ForwardHandler : ResponseHandler
    {     
        public ForwardHandler(TelebotCore telebotCore) : base(telebotCore) { }

        public override void ReplyToUser(TelebotCore telebotCore)
        {
            if (telebotCore.Forward_From!=null)
            {
                if(telebotCore.UserId == 102459)
                {
                    //轉傳的是機器人的訊息
                    if(telebotCore.Forward_From.id == 45622)
                    {
                        
                        _robotFunc.RobotAddWhite(telebotCore.UserId,telebotCore.Text);
                    }
                }
                else
                {
                    //回傳垃圾話
                }
            }
            else
            {
                _handler.ReplyToUser(telebotCore);
            }
        }
    }

}