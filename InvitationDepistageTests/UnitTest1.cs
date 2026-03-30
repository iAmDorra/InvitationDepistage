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
                .Sample((int birthDay, int birthMonth, int screeningMonths, int todayYear, int todayMonth) => {
                    var birthDate = new DateTime(1980, birthMonth, birthDay);
                    var today = new DateTime(todayYear, todayMonth, 01);

                    var invitationDate = CalculateInvitationDate(birthDate, today, screeningMonths);

                    int expectedInvitationMonth = birthMonth + screeningMonths;
                    Assert.AreEqual(expectedInvitationMonth, invitationDate.Month,
                        $"Month mismatch: expected {expectedInvitationMonth}, got {invitationDate.Month}");
                });
        }

        #region Helper Methods

        /// <summary>
        /// Calculates the invitation date based on birth date, today's date, and screening months.
        /// </summary>
        private DateTime CalculateInvitationDate(DateTime birthDate, DateTime today, int screeningMonths)
        {
            var targetMonth = birthDate.Month + screeningMonths;
            var year = today.Year;

            var day = birthDate.Day;
            var result = new DateTime(year, targetMonth, day);

            if (result < today)
                result = result.AddYears(1);

            while (result.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                result = result.AddDays(1);

            return result;
        }

        #endregion
    }
}