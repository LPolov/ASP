using System.Collections.Generic;
using System.Security.Claims;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Data.Repositories;
using OnlineShop.Areas.Account.Mappers;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Services.Impl
{
    /*
     * Default implementation of IUserService.
     */
    public class DefaultUserService : IUserService
    {
        private UserRepository _repository;
        private IUserMapper _userMapper;
        
        public DefaultUserService(UserRepository repository, IUserMapper userMapper)
        {
            _repository = repository;
            _userMapper = userMapper;
        }
        
        /*
         * Returns true if passed user is registered and password matches to password in db.
         */
        public bool IsAuthorizedUser(LoginUserVM user)
        {
            return _repository.IsAuthorizedUser(user);
        }

        /*
         * Returns true if passed user is admin.
         */
        public bool IsAdmin(LoginUserVM user)
        {
            return _repository.IsAdmin(user);
        }

        /*
         * Returns ClaimsPrincipal for given user by his/her type.
         */
        public ClaimsPrincipal GetPrincipal(LoginUserVM user, string userType)
        {
            ClaimsIdentity claimIdentity = new ClaimsIdentity(new List<Claim>() {new Claim("userType", userType), new Claim("email", user.Email)}, "Cookies");
            return  new ClaimsPrincipal(claimIdentity);
        }

        /*
         * Register passed user and returns her/his ClaimsPrincipal.
         */
        public ClaimsPrincipal RegisterUser(ResetPasswordVM user)
        {
            if (!_repository.IsEmailAlreadyRegistered(user) && user.Password == user.PasswordConfirmation)
            {
                ApplicationUser registeredUser = _repository.Register(_userMapper.GetProductDao(user));
                return GetPrincipal(user, "customer");
            }

            return null;
        }

        /*
         * Resets password for passed user.
         */
        public ApplicationUser ResetPassword(ResetPasswordVM user)
        {
            if (_repository.IsEmailAlreadyRegistered(user) && user.Password == user.PasswordConfirmation)
            {
                ApplicationUser dto = _repository.GetUserByEmail(user.Email);
                dto.Password = user.Password;
                _repository.ResetPassword(dto);
                return dto;
            }
            return null;
        }
    }
}