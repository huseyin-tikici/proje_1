﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class arsiv : System.Web.UI.UserControl
    {
        ilanBll ilanb = new ilanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            arsivRepeater.DataSource = ilanb.list(2, 5, false, false, true);
            arsivRepeater.DataBind();

            if (Request.QueryString["classified"] != null)
            {
                if (Request.QueryString["proc"] == "1")
                {
                    ilanb.update(1, Request.QueryString["classified"]); 
                }
                if (Request.QueryString["proc"] == "2")
                {
                    ilanb.update(2, Request.QueryString["classified"]); 
                }
                if (Request.QueryString["proc"] == "3")
                {
                   ilanb.update(3, Request.QueryString["advertisement"]); //düzenlenecek
                }
            }
            arsivRepeater.DataSource = ilanb.list(2, 5, false, false, true);
            arsivRepeater.DataBind();
        }

    }
}