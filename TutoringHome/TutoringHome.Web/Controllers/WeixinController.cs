using Senparc.Weixin.MP;
using System.Web.Mvc;

namespace TutoringHome.Web.Controllers
{
    public class WeixinController : Controller
    {
        public readonly string Token = "TutoringHome";//与微信公众账号后台的Token设置保持一致，区分大小写。X1kBK505tNBX5TtylsXbJOhEHo5HPwzwoqJvDcemS6x
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(WeixinController));
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            logger.ErrorFormat("sign:{0},timestamp:{1},nonce:{2}", signature, timestamp, nonce);
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                logger.Error("11111111");
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                logger.Error("2222222");
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }
    }
}