namespace Lab5Project.Services.Hash;

public static class HashFunction
{
    public static int ComputeHash(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        return input.Aggregate(17, (current, c) => (current * 31) + c);
    }
}