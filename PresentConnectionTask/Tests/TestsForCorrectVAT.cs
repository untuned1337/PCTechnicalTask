using NSubstitute;
using NUnit.Framework;
using PresentConnectionTechnicalTask;
using PresentConnectionTechnicalTask.CountryClasses;
using PresentConnectionTechnicalTask.Interfaces;
using PresentConnectionTechnicalTask.Implementations;
using PresentConnectionTechnicalTask.OrderManagementClasses;
using PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class TestsForCorrectVAT
    {        
        IParticipantValidator participantValidator;
        VATManager vatManager;        
        ServiceProvider provider;
        Client client;

        [SetUp]
        public void SetUp()
        {
            participantValidator = Substitute.For<IParticipantValidator>();
            vatManager = new VATManager(participantValidator);
            
            client = CreateClientStub();
            provider = new ServiceProvider();
        }

        private static Client CreateClientStub()
        {
            return new Client("TestClient", CountryManager.GetCountryByCountryCode("LT"), true, PersonType.IndividualPerson);
        }

        [Test]
        public void WhenProviderIsNotVATPayer_VATEqualsTo0()
        {
            participantValidator.ParticipantIsVATPayer(provider).Returns(false);

            double appropriateVAT = vatManager.GetAppropriateVAT(provider, client);

            Assert.AreEqual(0, appropriateVAT);
        }

        [Test]
        public void WhenProviderIsVATPayerAndClientIsOutsideEU_VATEqualsTo0()
        {
            participantValidator.ParticipantLivesInEU(client).Returns(false);

            double appropriateVAT = vatManager.GetAppropriateVAT(provider, client);

            Assert.AreEqual(0, appropriateVAT);
        }
        
        [Test]
        public void WhenProviderIsVATPayerAndClientIsInsideEUAndIsNotVATPayerButLivesInADifferentCountry_VATEqualsToClientsCountryVAT()
        {
            participantValidator.ParticipantIsVATPayer(provider).Returns(true);
            participantValidator.ParticipantLivesInEU(client).Returns(true);
            participantValidator.ParticipantIsVATPayer(client).Returns(false);
            participantValidator.ParticipantsAreFromTheSameCountry(client, provider).Returns(false);

            double appropriateVAT = vatManager.GetAppropriateVAT(provider, client);

            Assert.AreEqual(client.Country.VATRate, appropriateVAT);
        }
       
        [Test]
        public void WhenProviderIsVATPayerAndClientIsInsideEUAndIsVATPayerButLivesInADifferentCountry_VATEqualsTo0()
        {
            participantValidator.ParticipantIsVATPayer(provider).Returns(true);
            participantValidator.ParticipantLivesInEU(client).Returns(true);
            participantValidator.ParticipantIsVATPayer(client).Returns(true);
            participantValidator.ParticipantsAreFromTheSameCountry(client, provider).Returns(false);

            double appropriateVAT = vatManager.GetAppropriateVAT(provider, client);

            Assert.AreEqual(0, appropriateVAT);
        }
   
        [Test]
        public void WhenProviderIsVATPayerAndClientLivesInSameCountry_VATEqualsToClientsCountryVAT()
        {
            participantValidator.ParticipantIsVATPayer(provider).Returns(true);
            participantValidator.ParticipantsAreFromTheSameCountry(client, provider).Returns(true);

            double appropriateVAT = vatManager.GetAppropriateVAT(provider, client);

            Assert.AreEqual(client.Country.VATRate, appropriateVAT);
        }
        
    }
}
