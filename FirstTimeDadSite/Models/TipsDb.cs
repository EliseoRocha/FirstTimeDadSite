using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTimeDadSite.Models
{
    public class TipsDb
    {
        public static Tips Add(Tips t, SiteContext db)
        {
            db.Tips.Add(t);
            db.SaveChanges();
            return t;
        }
    }
}
