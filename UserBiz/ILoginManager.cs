using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserBiz.Model;

namespace UserBiz
{
    public interface ILoginManager
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
