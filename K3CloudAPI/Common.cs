using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3CloudAPI
{
    public static class Common
    {
        static Common() { }

        /// <summary>
        /// ExecuteTable
        /// </summary>
        /// <param name="pConnectionString">链接字符串</param>
        /// <param name="pCommandText">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string pConnectionString, string pCommandText)
        {
            return SQL.SQLHelper.ExecuteTable(pConnectionString, pCommandText);
        }
        /// <summary>
        /// ExecuteTable
        /// </summary>
        /// <param name="pCommandText">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string pCommandText)
        {
            return SQL.SQLHelper.ExecuteTable(pCommandText);
        }
        /// <summary>
        /// ExecuteTable
        /// </summary>
        /// <param name="pCommandText">SQL语句</param>
        /// <param name="pParameters">参数</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string pCommandText, SqlParameter[] pParameters)
        {
            return SQL.SQLHelper.ExecuteTable(pCommandText, pParameters);
        }
        //public static DataTable ExecuteTable(string pCommandText, CommandType pCommandType, SqlParameter[] pParameters)
        //{
        //    return SQL.SQLHelper.ExecuteTable(pCommandType, pCommandText, pParameters);
        //}

        public static string UpdateInStockQty()
        {
            return "开发中...";
        }
    }
}
