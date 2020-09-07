using System;
using System.Data;

namespace K3CloudAPI
{
    using Model.Globa;
    using Model.Basic;
    using DALFactory;

    public class Client
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pURL">金蝶ERP地址</param>
        /// <param name="pZTID">帐套ID</param>
        /// <param name="pUser">ERP登陆用户名</param>
        /// <param name="pPWD">密码</param>
        /// <param name="pConnectString">数据库链接字符串（仅支持SQL Server）</param>
        public Client(string pURL, string pZTID, string pUser, string pPWD, string pConnectString)
        {
            GlobalParameter.K3Inf = new Model.K3Cloud.K3Setting()
            {
                C_ERPADDRESS = pURL,
                C_ZTID = pZTID,
                C_USERNAME = pUser,
                C_PASSWORD = pPWD
            };
            GlobalParameter.SQLInf = new SQLConfig()
            {
                ConnectionString = pConnectString
            };
            GlobalParameter.LocalInf = new LocalInfo()
            {
                IP = DALCreator.ComFunc.GetLocalIP(),
                MAC = DALCreator.ComFunc.GetMac()
            };
        }

        /// <summary>
        /// 采购入库单
        /// </summary>
        /// <param name="pDataTable">数据DataTable</param>
        /// <returns></returns>
        public string POInStock(DataTable pDataTable)
        {
            return DALCreator.ComFunc.POInStock(pDataTable);
        }
    }
}
