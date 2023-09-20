namespace Text.To.Speech.Console;

public static class FileHelper
{
    public static string ReadTxtFromFile(string filePath)
    {
        var text = File.ReadAllText(filePath);
        return text;
    }
}