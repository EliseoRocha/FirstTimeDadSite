using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTimeDadSite.Models
{
    public class MemberDb
    {
        public static Member AddMember(Member m, SiteContext context)
        {
            //Create insert query
            context.Members.Add(m);
            //Executes insert query
            context.SaveChanges();

            return m;
        }
    }
}
