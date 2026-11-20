using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HaliSahaPortali.Data
{
    // Kayıt olan her yeni kullanıcıya otomatik "Kullanici" rolü verir.
    public class KullaniciYoneticisi : UserManager<IdentityUser>
    {
        public KullaniciYoneticisi(
            IUserStore<IdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<IdentityUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators,
                   passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            var sonuc = await base.CreateAsync(user, password);
            if (sonuc.Succeeded)
            {
                await AddToRoleAsync(user, "Kullanici");
            }
            return sonuc;
        }
    }
}