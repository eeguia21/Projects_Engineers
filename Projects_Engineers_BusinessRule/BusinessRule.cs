﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;

namespace Projects_Engineers_BusinessRule
{
    public class BusinessRule
    {

        Projects_Engineers db = new Projects_Engineers();

        public void readUsers()
        {

            PE_User nuq = new PE_User();

            PE_User num = new PE_User();

            //Query syntax

            var usrsq = from usr in db.PE_User select usr;

            foreach (var uq in usrsq)
            {
                nuq.Name = uq.Name;
                nuq.Email = uq.Email;
                nuq.Mobile = uq.Mobile;
            }

            //Method syntax

            var usrsm = db.PE_User;

            foreach (var um in usrsm)
            {
                num.Name = um.Name;
                num.Email = um.Email;
                num.Mobile = um.Mobile;
            }

        }
    }
}
