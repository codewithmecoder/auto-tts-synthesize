using Google.Cloud.TextToSpeech.V1;
using Text.To.Speech.Console;


var curDir = Directory.GetCurrentDirectory().Replace(@"\bin\Debug\net7.0", "");


var introTextFilePath = Path.Join(curDir, "intro-text.txt");
var introTxt = FileHelper.ReadTxtFromFile(introTextFilePath);

var introTexts = StringHelper.Split(introTxt, 1027).ToList();

var currentTxtStart = 0;
var currentIntoTxtStart = 0;

foreach (var intro in introTexts)
{
    await TtsHelper.StartAsync(new SynthesisInput
    {
        Text = intro,

    }, Path.Join(curDir, $@"wwwroot\intro\{currentTxtStart}.mp3"));
    currentIntoTxtStart++;
    Console.WriteLine($"Done Generate {Path.Join(curDir, $@"wwwroot\intro\{currentIntoTxtStart}.mp3")}");
}

Console.WriteLine("Done generating Intro Audios");

var textFilePath = Path.Join(curDir, "text.txt");
var text = FileHelper.ReadTxtFromFile(textFilePath);

var texts = StringHelper.Split(text, 1027).ToList();

foreach (var txt in texts)
{
    await TtsHelper.StartAsync(new SynthesisInput
    {
        Text = txt,
    }, Path.Join(curDir, $@"wwwroot\audios\{currentTxtStart}.mp3"));

    Console.WriteLine($"Done Generate {Path.Join(curDir, $@"wwwroot\audios\{currentTxtStart}.mp3")}");

    currentTxtStart++;
}

Console.WriteLine($"Total generate is {currentTxtStart}");

Console.ReadLine();