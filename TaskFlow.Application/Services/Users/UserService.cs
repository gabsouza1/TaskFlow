using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Users;
using TaskFlow.Application.Interfaces.Users;
using TaskFlow.Application.Utils;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> DeactivateUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return Result<Guid>.Fail("User not found.");

            user.Deactivate();
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return Result<Guid>.Ok(user.Id);
        }
    }

}
