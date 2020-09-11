using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json.Linq;

namespace Dev.K3Api.SQL
{
    using Model.Globa;
    using IDAL;

    internal class ComFunc : IComFunc
    {
        #region STATIC
        private static string _SQL;
        private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ComFunc()
        {
            _SQL = string.Empty;
            _obj = new object();
        }
        #endregion

        public string POInStock(DataTable pDataTable)
        {
            string strkBillNo = string.Empty;
            K3CloudApiClient client;
            if (GlobalParameter.K3Inf == null || GlobalParameter.SQLInf == null)
                return "请先配置金蝶和数据库参数。";
            try
            {
                //入库数量判断，入库数量<=采购订单分录剩余未入数量

                if (pDataTable == null || pDataTable.Rows.Count == 0) return "没有入库数据";

                client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
                var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.C_USERNAME, GlobalParameter.K3Inf.C_PASSWORD, 2052);
                if (bLogin)
                {
                    JObject jsonRoot = new JObject();
                    jsonRoot.Add("Creator", "PDA");
                    jsonRoot.Add("NeedUpDateFields", new JArray(""));
                    jsonRoot.Add("NeedReturnFields", new JArray(""));

                    jsonRoot.Add("IsDeleteEntry", "true");
                    jsonRoot.Add("SubSystemId", "");
                    jsonRoot.Add("IsVerifyBaseDataField", "false");
                    jsonRoot.Add("IsEntryBatchFill", "true");
                    jsonRoot.Add("ValidateFlag", "true");
                    jsonRoot.Add("NumberSearch", "true");
                    jsonRoot.Add("InterationFlags", "");
                    jsonRoot.Add("IsAutoSubmitAndAudit", "false");

                    // Model: 单据详细数据参数
                    JObject model = new JObject();
                    jsonRoot.Add("Model", model);

                    // 
                    model.Add("FID", 0);
                    // 单据类型
                    JObject basedata = new JObject();
                    basedata.Add("FNumber", "RKD01_SYS");
                    model.Add("FBillTypeID", basedata);
                    // 日期
                    model.Add("FDate", DateTime.Today);
                    //组织
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料组织"].ToString());
                    model.Add("FStockOrgId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料部门"].ToString());
                    model.Add("FStockDeptId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["仓管员"].ToString());
                    model.Add("FStockerId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料组织"].ToString());
                    model.Add("FDemandOrgId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料组织"].ToString());
                    model.Add("FPurchaseOrgId", basedata);
                    // 供应商
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["供应商"].ToString());
                    model.Add("FSupplierId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["供应商"].ToString());
                    model.Add("FSupplyId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["供应商"].ToString());
                    model.Add("FSettleId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["供应商"].ToString());
                    model.Add("FChargeId", basedata);

                    model.Add("FOwnerTypeIdHead", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料组织"].ToString());
                    model.Add("FOwnerIdHead", basedata);

                    model.Add("F_asd_Suppliershort", "HYG");
                    model.Add("FSupplierBillNo", "1");


                    //FPOOrderFinance
                    JObject InStockFin = new JObject();
                    model.Add("FInStockFin", InStockFin);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[0]["收料组织"].ToString());
                    InStockFin.Add("FSettleOrgId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "PRE001");
                    InStockFin.Add("FSettleCurrId", basedata);

                    InStockFin.Add("FIsIncludedTax", true);
                    InStockFin.Add("FPriceTimePoint", 1);

                    basedata = new JObject();
                    basedata.Add("FNumber", "PRE001");
                    InStockFin.Add("FLocalCurrId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "HLTX01_SYS");
                    InStockFin.Add("FExchangeTypeId", basedata);

                    InStockFin.Add("FExchangeRate", 1.0);
                    InStockFin.Add("FISPRICEEXCLUDETAX", true);

                    // 开始构建单据体参数：集合参数JArray
                    JArray entryRows = new JArray();
                    // 把单据体行集合，添加到model中，以单据体Key为标识
                    string entityKey = "FInStockEntry";
                    model.Add(entityKey, entryRows);

                    // 通过循环创建单据体行：示例代码仅创建一行
                    for (int i = 0; i < pDataTable.Rows.Count; i++)
                    {
                        // 添加新行，把新行加入到单据体行集合
                        JObject entryRow = new JObject();
                        entryRows.Add(entryRow);

                        // 单据体主键：必须填写，系统据此判断是新增还是修改行
                        entryRow.Add("FEntryID", 0);

                        entryRow.Add("FRowType", "Standard");
                        //物料(FMaterialId)：基础资料，填写编码
                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["物料编码"].ToString());
                        entryRow.Add("FMaterialId", basedata);

                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                        entryRow.Add("FUnitID", basedata);
                        entryRow.Add("FRealQty", 1);
                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                        entryRow.Add("FPriceUnitID", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", "123");
                        entryRow.Add("FLot", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["仓库"].ToString());
                        entryRow.Add("FStockId", basedata);

                        //仓位
                        JObject sp = new JObject();
                        sp.Add("FNumber", pDataTable.Rows[i]["仓位"].ToString());
                        basedata = new JObject();
                        basedata.Add("FSTOCKLOCID__FF100007", sp);
                        entryRow.Add("FStockLocId", basedata);

                        basedata = new JObject();
                        basedata.Add("FNumber", "KCZT01_SYS");
                        entryRow.Add("FStockStatusId", basedata);

                        entryRow.Add("FGiveAway", false);
                        entryRow.Add("FNote", "PDA InStock");

                        basedata = new JObject();
                        basedata.Add("FNumber", "bag");
                        entryRow.Add("FExtAuxUnitId", basedata);

                        entryRow.Add("FExtAuxUnitQty", 0.05);
                        entryRow.Add("FCheckInComing", false);
                        entryRow.Add("FIsReceiveUpdateStock", false);
                        entryRow.Add("FPriceBaseQty", 1);

                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                        entryRow.Add("FRemainInStockUnitId", basedata);

                        entryRow.Add("FBILLINGCLOSE", "false");
                        entryRow.Add("FRemainInStockQty", 11);//--------
                        entryRow.Add("FAPNotJoinQty", 1);
                        entryRow.Add("FRemainInStockBaseQty", 1);//--------
                        entryRow.Add("FAuxUnitQty", 0.05);

                        //创建与源单之间的关联关系，以支持上查与反写源单
                        entryRow.Add("FSrcBillTypeId", "PUR_PurchaseOrder");
                        entryRow.Add("FSRCBILLNO", pDataTable.Rows[i]["采购订单号"].ToString());

                        JArray linkRows = new JArray();
                        string linkEntityKey = string.Format("{0}_Link", entityKey);
                        entryRow.Add(linkEntityKey, linkRows);

                        JObject linkRow = new JObject();
                        linkRows.Add(linkRow);

                        //FFlowId : 业务流程图，可选
                        string fldFlowIdKey = string.Format("{0}_FFlowId", linkEntityKey);
                        linkRow.Add(fldFlowIdKey, "");
                        //FFlowLineId ：业务流程图路线，可选
                        string fldFlowLineIdKey = string.Format("{0}_FFlowLineId", linkEntityKey);
                        linkRow.Add(fldFlowLineIdKey, "");

                        string fldRuleIdKey = string.Format("{0}_FRuleId", linkEntityKey);
                        linkRow.Add(fldRuleIdKey, "PUR_PurchaseOrder-STK_InStock");
                        string fldSTableNameKey = string.Format("{0}_FSTableName", linkEntityKey);
                        linkRow.Add(fldSTableNameKey, "t_PUR_POOrderEntry");

                        string fldSBillIdKey = string.Format("{0}_FSBillId", linkEntityKey);
                        linkRow.Add(fldSBillIdKey, int.Parse(pDataTable.Rows[i]["FPURID"].ToString()));
                        string fldSIdKey = string.Format("{0}_FSId", linkEntityKey);
                        linkRow.Add(fldSIdKey, int.Parse(pDataTable.Rows[i]["FPURENTRYID"].ToString()));

                        string fldSFStockInQtyKey = string.Format("{0}_FStockInQty", linkEntityKey);
                        linkRow.Add(fldSFStockInQtyKey, 1);
                        string fldFSTOCKBASESTOCKINQTYKey = string.Format("{0}_FSTOCKBASESTOCKINQTY", linkEntityKey);
                        linkRow.Add(fldFSTOCKBASESTOCKINQTYKey, 1);
                    }

                    // 调用Web API接口服务，保存单据
                    strkBillNo = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "STK_InStock", jsonRoot.ToString() });
                    JObject jo = JObject.Parse(strkBillNo);

                    if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                    {
                        //strInstockBillNo = string.Empty;
                        //for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                        //    strInstockBillNo += "[" + pDr["fschtm"].ToString() + "]" + jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
                        return jo.ToString();
                    }
                    else
                    {
                        strkBillNo = "ID:" + jo["Result"]["Id"].Value<string>() + ";Number:" + jo["Result"]["Number"].Value<string>();//保存成功返回入库单FID和单据编号FBILLNO

                        //client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Submit", new object[] { "STK_InStock", "{\"CreateOrgId\":\"0\",\"Numbers\":[\"" + jo["Result"]["Number"].Value<string>() + "\"]}" });//根据入库单号提交单据
                        //client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Audit", new object[] { "STK_InStock", "{\"CreateOrgId\":\"0\",\"Numbers\":[\"" + jo["Result"]["Number"].Value<string>() + "\"]}" });//根据入库单号审核单据

                        //反写入库状态
                        //_SQL = string.Format("UPDATE XBT_SPJC SET FINSTOCKSTATUS = 1 WHERE ID = {0}", pDr["ID"].ToString());
                        //SQLHelper.ExecuteNonQuery(_SQL);

                        //反写采购订单入库数量、剩余未入数量
                    }
                }
                else return "ERP对接失败";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return strkBillNo;//返回格式:ID:xxxx;Number:xxxx
        }





        //------------------------
        #region PC Func
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public string GetLocalIP()
        {
            //string strIP = string.Empty;
            //try
            //{
            //    string hostInfo = Dns.GetHostName();
            //    IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //    for (int i = 0; i < addressList.Length; i++)
            //    {
            //        strIP += addressList[i].ToString();
            //    }
            //}
            //catch { return string.Empty; }
            //return strIP;
            //pIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();

            string strIP = string.Empty;
            try
            {
                string hostInfo = Dns.GetHostName();
                IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (addressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        strIP = addressList[i].ToString();
                        break;
                    }
                }
            }
            catch { return string.Empty; }
            return strIP;
        }

        /// <summary>
        /// 获取本机MAC地址
        /// </summary>
        /// <returns></returns>
        public string GetMac()
        {
            string Mac = string.Empty;
            try
            {
                NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in nis)
                {
                    if (ni.NetworkInterfaceType.ToString().Equals("Ethernet")) //是以太网卡
                    {
                        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + ni.Id + "\\Connection", false);

                        if (registryKey != null)
                        {
                            string fPnpInstanceID = registryKey.GetValue("PnpInstanceID", "").ToString();
                            //int fMediaSubType = Convert.ToInt32(registryKey.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI") //是物理网卡
                            {
                                Mac = ni.GetPhysicalAddress().ToString();
                                break;
                            }
                            //else if (fMediaSubType == 1) //虚拟网卡
                            //    continue;
                            //else if (fMediaSubType == 2) //无线网卡(上面判断Ethernet时已经排除了)
                            //    continue;
                        }
                    }
                }
            }
            catch { return string.Empty; }
            return Mac;
        }
        #endregion
    }
}
