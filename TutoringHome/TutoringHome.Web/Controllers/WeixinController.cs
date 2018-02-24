using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutoringHome.Web.Controllers
{
    public class WeixinController : Controller
    {
        public readonly string Token = "TutoringHome";//与微信公众账号后台的Token设置保持一致，区分大小写。
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }
    }
}