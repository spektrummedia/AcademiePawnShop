using FluentEmail.Core;

namespace Academie.PawnShop.Application.Mailing
{
    public interface IEmailFactory
    {
        IFluentEmail Prepare<TModel>(TModel model) where TModel : EmailModelBase;

        IFluentEmail Prepare(
            string to,
            string subject,
            string message,
            bool isHtml = true);
    }
}