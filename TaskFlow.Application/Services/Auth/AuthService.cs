using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.DTO.Users;
using TaskFlow.Application.Interfaces.Auth;
using TaskFlow.Application.Interfaces.Utils;
using TaskFlow.Application.Utils;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Models;

namespace TaskFlow.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return Result<AuthResponse>.Fail("Name is required.");

            if (string.IsNullOrWhiteSpace(request.Email))
                return Result<AuthResponse>.Fail("Email is required.");

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
                return Result<AuthResponse>.Fail("Password must be at least 6 characters.");

            var emailExists = await _userRepository.EmailExistsAsync(request.Email);
            if (emailExists)
                return Result<AuthResponse>.Fail("Email already exists.");

            var passwordHash = _passwordHasher.Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash);

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var token = _tokenService.GenerateToken(user);

            var response = new AuthResponse
            {
                Token = token,
                User = new UserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                }
            };

            return Result<AuthResponse>.Ok(response);
        }

        public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is null)
                return Result<AuthResponse>.Fail("Invalid credentials.");

            var passwordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!passwordValid)
                return Result<AuthResponse>.Fail("Invalid credentials.");

            var token = _tokenService.GenerateToken(user);

            var response = new AuthResponse
            {
                Token = token,
                User = MapToResponse(user)
            };

            return Result<AuthResponse>.Ok(response);
        }

        private static UserResponse MapToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
