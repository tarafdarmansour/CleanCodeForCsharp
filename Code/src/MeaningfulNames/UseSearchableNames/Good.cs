namespace UseSearchableNames;

public class Good
{
    public double FooFuction(int[] taskEstimate)
    {
        const int NUMBER_OF_TASKS = 34;
        var realDaysPerIdealDay = 4;
        const int WORK_DAYS_PER_WEEK = 5;
        double sum = 0;
        for (var j = 0; j < NUMBER_OF_TASKS; j++)
        {
            var realTaskDays = taskEstimate[j] * realDaysPerIdealDay;
            var realTaskWeeks = realTaskDays / WORK_DAYS_PER_WEEK;
            sum += realTaskWeeks;
        }

        return sum;
    }
}