using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IAuthenticateService
    {
        Task<AuthenticatedResponse> Authenticateḍ(AuthenticatedRequest loginRequest);
    }
}
