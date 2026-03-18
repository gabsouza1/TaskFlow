using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Utils;

namespace TaskFlow.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<Result<Guid>> DeactivateUserAsync(Guid userId);
    }
}
