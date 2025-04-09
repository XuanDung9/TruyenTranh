using HamtruyenLibrary.Models;
using HamtruyenLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class CreateColor : System.Web.UI.Page
    {
        ColorRepo repo = new ColorRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Color color = new Color
            {
                Name_Color = txtMau.Text,
                Hex_Code_Color = txtMaMau.Text,

            };
            repo.Save(color);
        }

    }
}