﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.ilanYonetimi.ozellikler
{
    public partial class cadir_ozellik : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cadirOzelRepeater.DataSource = ozellikb.selectFieldList(30);
                cadirOzelRepeater.DataBind();

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" || Request.QueryString["ilan"] != "")
                {
                    IEnumerable<secilebilirIlanOzellik> sio = sioBll.searchCheckBox(Convert.ToInt32(Request.QueryString["ilan"]));
                    foreach (Control item in cadirOzelRepeater.Controls)
                    {
                        foreach (Control item2 in item.Controls)
                        {
                            if (item2 is CheckBox)
                            {
                                for (int i = 0; i < sio.Count(); i++)
                                {
                                    if (((CheckBox)item2).Attributes["value"] == sio.ElementAt(i).ozellikDegerId.ToString())
                                    {
                                        ((CheckBox)item2).Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}