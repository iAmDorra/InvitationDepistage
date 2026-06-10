using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CsCheck;

namespace InvitationDepistageTests
{
    [TestClass]
    public class InvitationDepistageTests
    {
        [TestMethod]
        public void Calculate_base_invitation_date_add_birth_month_to_screening_month()
        {
            Gen.Select(Gen.Int[1, 28], Gen.Int[1, 7], Gen.Int[1, 5], Gen.Int[2020, 2025], Gen.Int[1, 12])
                .Sample((int birthDay, int birthMonth, int screeningMonths, int todayYear, int todayMonth) =>
                {
                    var birthDate = new DateTime(1980, birthMonth, birthDay);
                    var today = new DateTime(todayYear, todayMonth, 01);
                    var calculator = new InvitationDepistage.InvitationCalculator();

                    var invitationDate = calculator.CalculateInvitationDate(birthDate, today, screeningMonths);

                    int expectedInvitationMonth = birthMonth + screeningMonths;

                    Assert.AreEqual(expectedInvitationMonth, invitationDate.Month,
                        $"Month mismatch: expected {expectedInvitationMonth}, got {invitationDate.Month}");
                });
        }

        [TestMethod]
        public void Calculate_base_invitation_date_add_year()
        {
            Gen.Select(Gen.Int[1, 28], Gen.Int[1, 5], Gen.Int[1, 3], Gen.Int[2020, 2025], Gen.Int[9, 12])
                .Sample((int birthDay, int birthMonth, int screeningMonths, int todayYear, int todayMonth) =>
                {
                    var birthDate = new DateTime(1980, birthMonth, birthDay);
                    var today = new DateTime(todayYear, todayMonth, 01);
                    var calculator = new InvitationDepistage.InvitationCalculator();

                    var invitationDate = calculator.CalculateInvitationDate(birthDate, today, screeningMonths);

                    int expectedYear = today.Year + 1;
                    Assert.AreEqual(expectedYear, invitationDate.Year,
                        $"Year mismatch: expected {expectedYear}, got {invitationDate.Year}");
                });
        }

        #region Helper Methods


        #endregion
    }
}