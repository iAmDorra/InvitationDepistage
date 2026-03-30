using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CsCheck;

namespace InvitationDepistageTests
{
    [TestClass]
    public class InvitationDepistageTests
    {
        /// <summary>
        /// Property-based test: The invitation date day and month should always match 
        /// the birth day and month (except for leap year edge case: 29/02).
        /// 
        /// CsCheck generates hundreds of random test cases automatically, testing combinations
        /// that you wouldn't think of manually. If one fails, it shrinks to the minimal failing case.
        /// </summary>
        [TestMethod]
        public void Property_InvitationDateDayAndMonthMatchBirthday()
        {
            Gen.Select(Gen.Int[1, 28], Gen.Int[1, 12], Gen.Int[1, 12], Gen.Int[2020, 2025], Gen.Int[1, 12])
                .Sample((int birthDay, int birthMonth, int screeningMonths, int todayYear, int todayMonth) => {
                    // Ensure valid dates
                    var maxDayInMonth = DateTime.DaysInMonth(todayYear, todayMonth);
                    var todayDay = (maxDayInMonth < 28) ? maxDayInMonth : 15;

                    var birthDate = new DateTime(1980, birthMonth, birthDay);
                    var today = new DateTime(todayYear, todayMonth, todayDay);

                    // Act
                    var invitationDate = CalculateInvitationDate(birthDate, today, screeningMonths);

                    // Assert - Day and month must match birth day and month
                    Assert.AreEqual(birthDay, invitationDate.Day,
                        $"Day mismatch: expected {birthDay}, got {invitationDate.Day}");
                    Assert.AreEqual(birthMonth, invitationDate.Month,
                        $"Month mismatch: expected {birthMonth}, got {invitationDate.Month}");
                });
        }

        #region Helper Methods

        /// <summary>
        /// Calculates the invitation date based on birth date, today's date, and screening months.
        /// This is a placeholder - replace with your actual implementation.
        /// </summary>
        private DateTime CalculateInvitationDate(DateTime birthDate, DateTime today, int screeningMonths)
        {
            // TODO: Implement the actual business logic
            // 1. Create base date: day of birth + month of birth + screening months + current year
            // 2. Adjust if not a valid date
            // 3. If before today, add one year
            // 4. If weekend, adjust to Monday
            // 5. If public holiday, adjust to next working day

            throw new NotImplementedException("Implement the invitation date calculation logic");
        }

        /// <summary>
        /// Determines if a date is a public holiday (placeholder implementation).
        /// </summary>
        private bool IsPublicHoliday(DateTime date)
        {
            // TODO: Implement with actual public holidays for your region
            return false;
        }

        #endregion
    }
}