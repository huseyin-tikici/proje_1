﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class salon_sayisi_text : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 90) != null)
                {
                    txtSalonSayisiText.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 90).deger;
                }
            }

        }
    }
}