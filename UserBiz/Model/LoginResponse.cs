using CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserBiz.Model
{
    public class LoginResponse : ValidationResponse
    {
        public TokenInfo TokenDetail { get; set; }
        public LoginResponse()
        {

        }
    }
}
