using Google.Cloud.TextToSpeech.V1;

namespace Text.To.Speech.Console;

public static class TtsHelper
{
    public static async Task StartAsync(SynthesisInput input, string fileAudioPath, VoiceSelectionParams? voiceSelection = null)
    {
        var a = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

        var client = await TextToSpeechClient.CreateAsync();

        // You can specify a particular voice, or ask the server to pick based
        // on specified criteria.

        // The audio configuration determines the output format and speaking rate.
        var audioConfig = new AudioConfig
        {
            AudioEncoding = AudioEncoding.Mp3
        };

        //var voices = await client.ListVoicesAsync(new ListVoicesRequest()
        //{
        //    LanguageCode = "en-US",
        //});

        voiceSelection ??= new VoiceSelectionParams
        {
            LanguageCode = "en-US",
            SsmlGender = SsmlVoiceGender.Male,
            Name = "en-US-Studio-M",
        };

        var response = await client.SynthesizeSpeechAsync(input, voiceSelection, audioConfig);
        await using Stream output = File.Create(fileAudioPath);
        // response.AudioContent is a ByteString. This can easily be converted into
        // a byte array or written to a stream.
        response.AudioContent.WriteTo(output);
    }
}