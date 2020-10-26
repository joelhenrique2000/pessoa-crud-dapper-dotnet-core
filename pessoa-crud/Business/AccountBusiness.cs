using Microsoft.AspNetCore.Identity;
using pessoa_crud.Models;
using pessoa_crud.ViewModel;
using System.Threading.Tasks;

namespace pessoa_crud.Business
{
    public class AccountBusiness
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountBusiness(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<SignInResult> Login(AccountLoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Senha, false, false);
            return result;
        }

        public async Task<IdentityResult> Register(ApplicationUser usuario, string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);
        }

        public async Task SignIn(ApplicationUser usuario)
        {
            await _signInManager.SignInAsync(usuario, false);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
