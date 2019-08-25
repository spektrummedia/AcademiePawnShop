using System;
using Academie.PawnShop.Application.Mailing;
using Xunit;
using Shouldly;

namespace Academie.PawnShop.Tests.Application.Mailing
{
    public class EmailModelBaseTests
    {
        [Fact]
        public void Ctor_ShouldSetPropertiesCorrectly_WhenAllArgValid()
        {
            //arrange

            //act
            var emailModelBase = new TestEmailModelBase("Subject", "patate@test.com");
            //assert
            emailModelBase.Subject.ShouldBe("Subject");
            emailModelBase.To.ShouldBe("patate@test.com");
        }

        [Fact]
        public void Ctor_ShouldThrow_WhenToIsNull()
        {
            //arrange

            //act

            //assert
            Assert.ThrowsAny<Exception>(() => new TestEmailModelBase("Subject", null));
        }

        private class TestEmailModelBase : EmailModelBase
        {
            public TestEmailModelBase(string subject, string to) : base(subject, to)
            {
            }
        }
    }
}