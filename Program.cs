// See https://aka.ms/new-console-template for more information

using Google.Cloud.TextToSpeech.V1;
using Text.To.Speech.Console;


var curDir = Directory.GetCurrentDirectory().Replace(@"\bin\Debug\net7.0", "");
var textFilePath = Path.Join(curDir, "text.txt");
var text = FileHelper.ReadTxtFromFile(textFilePath);


var texts = StringHelper.Split(text, 1027).ToList();

var currentTxtStart = 0;
await TtsHelper.StartAsync(new SynthesisInput
{
    Text = """
           Hey guys!! Welcome to Terrifying Tales.
           In this video we are going to represent you a story about "My Vampire Neighbor"
           """,

}, Path.Join(curDir, $"wwroot\\audios\\{currentTxtStart}.mp3"));

Console.WriteLine($"Done Generate {Path.Join(curDir, $"wwroot\\audios\\{currentTxtStart}.mp3")}");
currentTxtStart++;



foreach (var txt in texts)
{
    await TtsHelper.StartAsync(new SynthesisInput
    {
        Text = txt,
    }, Path.Join(curDir, $"wwroot\\audios\\{currentTxtStart}.mp3"));

    Console.WriteLine($"Done Generate {Path.Join(curDir, $"wwroot\\audios\\{currentTxtStart}.mp3")}");

    currentTxtStart++;
}

Console.WriteLine($"Total generate is {currentTxtStart}");

Console.ReadLine();