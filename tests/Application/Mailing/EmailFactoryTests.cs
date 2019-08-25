using FluentEmail.Core.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using Academie.PawnShop.Application.Mailing;
using Academie.PawnShop.Application.Settings;
using Xunit;

namespace Academie.PawnShop.Tests.Application.Mailing
{
    public class EmailFactoryTests
    {
        private const string FromAddress = "from@test.com";
        private const string FromName = "from me !";

        [Fact]
        public void Prepare_ShouldReturnemailInCorrectState_When()
        {
            //arrange
            var emailFact = ArrangeEmailFactory();

            //act
            var email = emailFact.Prepare("test@test.com", "Subject", "Message patate !");

            //assert
            email.Data.FromAddress.EmailAddress.ShouldBe(FromAddress);
            email.Data.FromAddress.Name.ShouldBe(FromName);
        }

        [Theory]
        [InlineData(",")]
        [InlineData(";")]
        public void Prepare_ShouldReturnCollectionOfRecipient_WhenProvidingMoreThan1To(string separator)
        {
            //arrange
            var emailFact = ArrangeEmailFactory();

            //act
            var email = emailFact.Prepare($"to1@test.com{separator}to2@test.com{separator}to3@test.com",
                "Subject", "Message patate !");

            //assert
            email.Data.FromAddress.EmailAddress.ShouldBe(FromAddress);

            Assert.Collection(email.Data.ToAddresses, a => a.EmailAddress.ShouldBe("to1@test.com"),
                a => a.EmailAddress.ShouldBe("to2@test.com"),
                a => a.EmailAddress.ShouldBe("to3@test.com"));
        }

        private static EmailFactory ArrangeEmailFactory()
        {
            var renderer = new Mock<ITemplateRenderer>();
            var sender = new Mock<ISender>();
            var options = new Mock<IOptions<MailingSettings>>();
            options.SetupGet(m => m.Value).Returns(new MailingSettings
            {
                FromName = FromName,
                FromAddress = FromAddress
            });

            var emailFact = new EmailFactory(renderer.Object, sender.Object, options.Object);
            return emailFact;
        }
    }
}