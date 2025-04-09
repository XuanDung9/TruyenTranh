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
    public partial class CreateVersion : System.Web.UI.Page
    {
        VersionRepo repo = new VersionRepo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Versions version = new Versions
            {
                Name_Version = txtName.Text,
            };
            repo.Save(version);
            Response.Redirect("http://localhost:60010/CreateProduct.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60010/CreateProduct.aspx");
        }
    }
}