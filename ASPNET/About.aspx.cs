using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using Entities;

namespace ASPNET
{
    public partial class About : Page
    {
        BusinessLayer.BusinessLayer businessHelper = new BusinessLayer.BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ProductID"] != null)
                {
                    string productId = Request.QueryString["ProductID"];
                    if (!String.IsNullOrEmpty(productId))
                    {
                       

                        var product = businessHelper.GetProduct(int.Parse(productId));

                        txtName.Text = product.Name;
                        txtDesc.Text = product.Description;
                        txtSKU.Text = product.SKU;
                        txtVendor.Text = product.Vendor;
                        hdnProductId.Value = product.ProductId.ToString();
                    }
                }
            }

            
            grdProducts.DataSource = businessHelper.GetProducts();
            grdProducts.DataBind();

        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var businessHeler = new BusinessLayer.BusinessLayer();

            var product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDesc.Text;
            product.SKU = txtSKU.Text;
            product.Vendor = txtVendor.Text;
            int productID;
            if (int.TryParse(hdnProductId.Value, out productID)) product.ProductId = productID;

            businessHeler.ManageProduct(product);

            grdProducts.DataSource = businessHeler.GetProducts();
            grdProducts.DataBind();

            txtName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtSKU.Text = string.Empty;
            txtVendor.Text = string.Empty;
            hdnProductId.Value = string.Empty;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDesc.Text;
            product.SKU = txtSKU.Text;
            product.Vendor = txtVendor.Text;
            product.IsDeleted = true;
            int productID;
            if (int.TryParse(hdnProductId.Value, out productID)) product.ProductId = productID;

            businessHelper.ManageProduct(product);

            grdProducts.DataSource = businessHelper.GetProducts();
            grdProducts.DataBind();

            txtName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtSKU.Text = string.Empty;
            txtVendor.Text = string.Empty;
            hdnProductId.Value = string.Empty;
        }

    }
}