using System;
using System.Data;

namespace Dev.K3Api.IDAL
{
    internal interface IComFunc
    {
        string POInStock(DataTable pDataTable);
        string GetLocalIP();
        string GetMac();
    }
}
