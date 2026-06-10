namespace InvitationDepistage
{
    public class InvitationCalculator
    {
        /// <summary>
        /// Calculates the invitation date based on birth date, today's date, and screening months.
        /// </summary>
        public DateTime CalculateInvitationDate(DateTime birthDate, DateTime today, int screeningMonths)
        {
            var targetMonth = birthDate.Month + screeningMonths;
            var year = today.Year;
            if (targetMonth > 12)
            {
                targetMonth -= 12;
                year++;
            }

            var day = birthDate.Day;
            var result = new DateTime(year, targetMonth, day);

            if (result < today)
                result = result.AddYears(1);

            while (result.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                result = result.AddDays(1);

            return result;
        }

    }
}
