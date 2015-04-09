namespace PayrollApp.Domain.Model
{
    /// <summary>
    /// Harmonogram wypłat Pracownika
    /// </summary>
    public enum EmployeePaymentScheduleType
    {
        /// <summary>
        /// Co tydzień w piątki
        /// </summary>
        WeeklySchedule = 1,
        /// <summary>
        /// Co dwa tygodnie w piątki
        /// </summary>
        BiweeklySchedule = 2,
        /// <summary>
        /// Na koniec miesiąca
        /// </summary>
        MonthlySchedule = 3
    }
}
