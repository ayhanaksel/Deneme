using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TubitetBackEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            // Do some Authentication...
            if (e.ExtraParams["user"] != "Ayhan" || e.ExtraParams["pass"] != "extnet")
            {
                e.Success = false;
                e.ErrorMessage = "Kullanıcı adı veya şifre yanlış";
            }
            else
            {
                X.Msg.Alert("Giriş Başarılı", "Lütfen Bekleyin Sayfaya Yönlendiriliyorsunuz..");
            }
        }
    }
}