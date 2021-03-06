﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takas.Common.Entities.Concrete;

namespace Takas.Business.Abstract
{
    public interface ISocialUserService
    {
        bool SocialUserOperation(int socialType, string socialID, string email, string username, string firstname, string lastname,string methodName);

        List<SocialUser> EagerLoadingUser();

    }
}
