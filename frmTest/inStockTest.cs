using System;
using System.Data;
using System.Windows.Forms;

namespace Dev.frmTest
{
    using K3CloudAPI;

    public partial class inStockTest : Form
    {
        private string _SQL;
        private string _URL;
        private string _ZTID;
        private string _K3User;
        private string _K3UserPWD;
        private DataTable _dt;


        public inStockTest()
        {
            InitializeComponent();
        }

        private void SetDataSource()
        {
            _SQL = "SELECT FBARCODE 条码,FPURBILLNO 采购订单号,FMATERIALID 物料编码,FUNITID 单位,FQTY 数量,FSTOCKORGID 收料组织,FSTOCKDEPTID 收料部门,FSTOCKID 仓库,'' 仓位,FSTOCKERID 仓管员,FSUPPLIERID 供应商,CASE FINSTOCKSTATUS WHEN 0 THEN '否' ELSE '是' END 入库状态,FPURID,FPURENTRYID,FSEQ,ID FROM XBT_SPJC WHERE FINSTOCKSTATUS = 0";
            _dt = Common.ExecuteTable("Data Source=.;Initial Catalog=nygh;User ID=pda;Password=abc123,;", _SQL);
            dgv1.DataSource = _dt;
            dgv1.Columns[12].Visible = false;
            dgv1.Columns[13].Visible = false;
            dgv1.Columns[14].Visible = false;
            dgv1.Columns[15].Visible = false;

        }

        private void FillComboBox()
        {
            _SQL = "SELECT DISTINCT A.FNUMBER FVALUE,AL.FNAME ";
            _SQL += " FROM T_BD_STOCK A ";
            _SQL += " INNER JOIN T_BD_STOCK_L AL ON A.FSTOCKID = AL.FSTOCKID AND AL.FLOCALEID = 2052 ";
            _SQL += " WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FSTOCKPROPERTY = 1 AND A.FISOPENLOCATION = 0 ";
            _SQL += " ORDER BY A.FNUMBER";
            DataTable dtStock = Common.ExecuteTable("Data Source=.;Initial Catalog=nygh;User ID=pda;Password=abc123,;", _SQL);
            bnTop_cbxInStock.ComboBox.DataSource = dtStock;
            bnTop_cbxInStock.ComboBox.ValueMember = "FVALUE";
            bnTop_cbxInStock.ComboBox.DisplayMember = "FNAME";

            _SQL = "SELECT DISTINCT A.FNUMBER FVALUE,AL.FNAME ";
            _SQL += " FROM T_BD_STAFF A ";
            _SQL += " INNER JOIN T_BD_STAFF_L AL ON A.FSTAFFID = AL.FSTAFFID AND AL.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FUSEORGID = ORG.FORGID AND ORG.FORGFUNCTIONS LIKE '%103%' ";
            _SQL += " WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' ";
            _SQL += " ORDER BY A.FNUMBER";
            DataTable dtStocker = Common.ExecuteTable("Data Source=.;Initial Catalog=nygh;User ID=pda;Password=abc123,;", _SQL);
            bnTop_cbxInStocker.ComboBox.DataSource = dtStocker;
            bnTop_cbxInStocker.ComboBox.ValueMember = "FVALUE";
            bnTop_cbxInStocker.ComboBox.DisplayMember = "FNAME";
        }

        private void bnTop_btnInStock_Click(object sender, EventArgs e)
        {
            if (_dt == null || _dt.Rows.Count == 0)
                return;

            try
            {
                DataRow dr = _dt.NewRow();
                dr = _dt.Rows[dgv1.CurrentRow.Index];
                if (dr["入库状态"].ToString() == "是")
                {
                    MessageBox.Show("该产品已经入库");
                    return;
                }

                MessageBox.Show(POInStock(dr));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bnTop_btnSearch_Click(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private string POInStock(DataRow pDr)
        {
            return "";
        }
    }
}
