using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InvitationDepistageTests
{
    [TestClass]
    public class InvitationDepistageTests
    {
        [TestMethod]
        public void CalculerDateInvitation_ValidScenario_ReturnsExpectedDate()
        {
            // Arrange
            DateTime dateDeNaissance = new DateTime(1980, 3, 15);
            DateTime dateDuJour = new DateTime(2023, 1, 1);
            int nombreDeMois = 2; // Pour le dépistage de l'utérus
            DateTime expectedDateInvitation = new DateTime(2023, 5, 15);

            // Act
            DateTime actualDateInvitation = CalculerDateInvitation(dateDeNaissance, dateDuJour, nombreDeMois);

            // Assert
            Assert.AreEqual(expectedDateInvitation, actualDateInvitation, "La date d'invitation calculée n'est pas correcte.");
        }
        [TestMethod]
        public void CalculerDateInvitation_DepistageSein_ReturnsExpectedDate()
        {
            // Arrange
            DateTime dateDeNaissance = new DateTime(1980, 3, 15);
            DateTime dateDuJour = new DateTime(2023, 1, 1);
            int nombreDeMois = 3; // Pour le dépistage du sein
            DateTime expectedDateInvitation = new DateTime(2023, 6, 15);

            // Act
            DateTime actualDateInvitation = CalculerDateInvitation(dateDeNaissance, dateDuJour, nombreDeMois);

            // Assert
            Assert.AreEqual(expectedDateInvitation, actualDateInvitation, "La date d'invitation calculée pour le dépistage du sein n'est pas correcte.");
        }

        [TestMethod]
        public void CalculerDateInvitation_DepistageColon_ReturnsExpectedDate()
        {
            // Arrange
            DateTime dateDeNaissance = new DateTime(1980, 3, 15);
            DateTime dateDuJour = new DateTime(2023, 1, 1);
            int nombreDeMois = 4; // Pour le dépistage du colon
            DateTime expectedDateInvitation = new DateTime(2023, 7, 15);

            // Act
            DateTime actualDateInvitation = CalculerDateInvitation(dateDeNaissance, dateDuJour, nombreDeMois);

            // Assert
            Assert.AreEqual(expectedDateInvitation, actualDateInvitation, "La date d'invitation calculée pour le dépistage du colon n'est pas correcte.");
        }

        private DateTime CalculerDateInvitation(DateTime dateDeNaissance, DateTime dateDuJour, int nombreDeMois)
        {
            // Calcul initial de la date d'invitation
            DateTime dateInvitation = new DateTime(
                dateDuJour.Year,
                dateDeNaissance.Month,
                dateDeNaissance.Day
            ).AddMonths(nombreDeMois);

            return dateInvitation;
        }

    }
}