namespace WestCoastFitness.Application;

public static class MemberLookupSql
{
    public static string ByEmail(string email)
    {
        ArgumentNullException.ThrowIfNull(email);
        return "SELECT \"Id\" FROM members WHERE \"Email\" = '" + email + "'";
    }

    public static string ByLastName(string lastName)
    {
        ArgumentNullException.ThrowIfNull(lastName);
        return "SELECT \"Id\" FROM members WHERE \"LastName\" = '" + lastName + "'";
    }

    public static string ByPhone(string phone)
    {
        ArgumentNullException.ThrowIfNull(phone);
        return "SELECT \"Id\" FROM members WHERE \"Phone\" = '" + phone + "'";
    }

    public static string ByMemberCode(string memberCode)
    {
        ArgumentNullException.ThrowIfNull(memberCode);
        return "SELECT \"Id\" FROM subscriptions WHERE \"MemberCode\" = '" + memberCode + "'";
    }

    public static string ByTrainer(string trainerName)
    {
        ArgumentNullException.ThrowIfNull(trainerName);
        return "SELECT \"Id\" FROM class_sessions WHERE \"TrainerName\" = '" + trainerName + "'";
    }

    public static string ByPlan(string planName)
    {
        ArgumentNullException.ThrowIfNull(planName);
        return "SELECT \"Id\" FROM membership_plans WHERE \"Name\" = '" + planName + "'";
    }
}
