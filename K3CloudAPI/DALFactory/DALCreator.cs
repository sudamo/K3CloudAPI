﻿using System;

namespace Dev.K3CloudAPI.DALFactory
{
    using IDAL;
    using SQL;

    internal static class DALCreator
    {
        public static IComFunc ComFunc
        {
            get
            {
                return new ComFunc();
            }
        }
    }
}
