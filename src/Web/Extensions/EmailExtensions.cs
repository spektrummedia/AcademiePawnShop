using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Academie.PawnShop.Application.Mailing;

namespace Academie.PawnShop.Web.Extensions
{
    public static class EmailFactoryExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailFactory emailFactory, string email, string link)
        {
            return emailFactory
                .Prepare(email, "Confirm your email",$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.")
                .SendAsync();
        }

        public static Task SendResetPasswordAsync(this IEmailFactory emailFactory, string email, string callbackUrl)
        {
            return emailFactory
                .Prepare(email, "Reset Password", $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.")
                .SendAsync();
        }
    }
}
