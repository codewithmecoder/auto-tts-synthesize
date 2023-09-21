namespace Text.To.Speech.Console;

public static class StringHelper
{
    public static IEnumerable<string> Split(string str, int chunkSize)
    {
        if (str.Length <= chunkSize)
        {
            return new [] { str };
        }

        var size = (int)Math.Ceiling(str.Length / (float)chunkSize);

        return Enumerable.Range(0, size)
            .Select(i =>
            {
                var length = str.Length - i * chunkSize;

                length = length > chunkSize ? chunkSize : length;

                return str.Substring(i * chunkSize, length);
            });
    }
}