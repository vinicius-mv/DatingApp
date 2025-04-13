namespace API.Extensions;

public static class DateTimeExtension
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);

        var age = today.Year - dob.Year;

        // Check if the birthday has occurred this year; if not, subtract 1 from age
        if (dob > today.AddYears(-age)) age--;

        return age;
    }
}
