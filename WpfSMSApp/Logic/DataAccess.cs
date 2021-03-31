﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSMSApp.Model;

namespace WpfSMSApp.Logic
{
    public class DataAccess
    {
        public static List<User> GetUsesr()
        {
            List<User> users;

            using(var ctx = new SMSEntities())
            {
                users = ctx.User.ToList();//SELECT*FROM user
            }
            return users;
        }
        /// <summary>
        /// 입력과 수정을 동시에 하는 것이다.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0또는 1이상</returns>
        internal static int SetUser(User user)
        {
            using (var ctx = new SMSEntities())
            {
                ctx.User.AddOrUpdate(user);
                return ctx.SaveChanges();//Commit
            }
        }
    }
}
