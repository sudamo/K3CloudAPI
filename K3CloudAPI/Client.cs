using System;
using System.Data;

namespace Dev.K3CloudAPI
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
        public Client(string pURL, string pZTID, string pUser, string pPWD, string pConnectString = "")
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
        /// 构造函数
        /// </summary>
        /// <param name="pURL">金蝶ERP地址</param>
        /// <param name="pZTID">帐套ID</param>
        /// <param name="pUser">ERP登陆用户名</param>
        /// <param name="pPWD">密码</param>
        /// <param name="pDBIP">数据库IP地址</param>
        /// <param name="pDBCatalog">数据库</param>
        /// <param name="pDBUser">数据库登陆用户名</param>
        /// <param name="pDBPWD">数据库登陆用户密码</param>
        /// <param name="pDBPort">数据库端口(可选)</param>
        public Client(string pURL, string pZTID, string pUser, string pPWD, string pDBIP, string pDBCatalog, string pDBUser, string pDBPWD, string pDBPort = "")
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
                IP = pDBIP,
                Port = pDBPort,
                Catalog = pDBCatalog,
                UserName = pDBUser,
                Password = pDBPWD
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
