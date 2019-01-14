﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_NameNotFound.Model
{
    static class Releasedate
    {
        static public double Days_Releasedate()
        {
            DateTime releasedate = new DateTime(2019, 03, 26);
            TimeSpan diff = new TimeSpan();
            diff = DateTime.Now - releasedate;
            return (diff.TotalDays);
        }

    }
}