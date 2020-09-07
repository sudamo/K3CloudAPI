using System;
using System.Data;

namespace K3CloudAPI.IDAL
{
    internal interface IComFunc
    {
        string POInStock(DataTable pDataTable);
        string GetLocalIP();
        string GetMac();
    }
}
