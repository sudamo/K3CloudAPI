using System;
using System.Data;
using System.Data.SqlClient;

namespace Dev.K3CloudAPI
{
    using SQL;

    public static class Common
    {
        static Common() { }

        #region DbOperation
        /// <summary>
        /// 链接测试
        /// </summary>
        /// <param name="pConnectionString"></param>
        /// <returns></returns>
        public static string ConnectionChecked(string pConnectionString)
        {
            return SQLHelper.ConnectionChecked(pConnectionString);
        }

        //NonQuery

        public static void ExecuteNonQuery(string pConnectionString, string pCommandText)
        {
            SQLHelper.ExecuteNonQuery(pConnectionString, pCommandText);
        }
        public static void ExecuteNonQuery(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            Model.Globa.GlobalParameter.SQLInf = new Model.Basic.SQLConfig()
            {
                ConnectionString = pConnectionString
            };

            SQLHelper.ExecuteNonQuery(pCommandType, pCommandText, pParameters);
        }

        //Scalar

        public static object ExecuteScalar(string pConnectionString, string pCommandText)
        {
            return SQLHelper.ExecuteScalar(pConnectionString, pCommandText);
        }
        public static object ExecuteScalar(string pConnectionString, string pCommandText, SqlParameter[] pParameters)
        {
            Model.Globa.GlobalParameter.SQLInf = new Model.Basic.SQLConfig()
            {
                ConnectionString = pConnectionString
            };

            return SQLHelper.ExecuteScalar(pCommandText, pParameters);
        }

        //Table
        public static DataTable ExecuteTable(string pConnectionString, string pCommandText)
        {
            return SQLHelper.ExecuteTable(pConnectionString, pCommandText);
        }
        public static DataTable ExecuteTable(string pConnectionString, string pCommandText, SqlParameter[] pParameters)
        {
            Model.Globa.GlobalParameter.SQLInf = new Model.Basic.SQLConfig()
            {
                ConnectionString = pConnectionString
            };

            return SQLHelper.ExecuteTable(pCommandText, pParameters);
        }
        public static DataTable ExecuteTable(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            Model.Globa.GlobalParameter.SQLInf = new Model.Basic.SQLConfig()
            {
                ConnectionString = pConnectionString
            };
            return SQLHelper.ExecuteTable(pCommandType, pCommandText, pParameters);
        }
        #endregion

        //--------------------------------------
        public static string UpdateInStockQty()
        {
            return "开发中...";
        }

        public static string UpdateInStockStatus()
        {
            return "开发中...";
        }
    }
}
