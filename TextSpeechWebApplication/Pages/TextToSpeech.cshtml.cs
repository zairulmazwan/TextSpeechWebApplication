using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using TextSpeechWebApplication.Models;

namespace TextSpeechWebApplication.Pages
{
    public class TextToSpeechModel : PageModel
    {
        [BindProperty]
        public TextSpeech Text { get; set; }
        public void OnGet()
        {
            Console.WriteLine("Test");
        }

        public void btnSpeak_Click(object sender, EventArgs e)
        {
            SpeechAudioFormatInfo info = new SpeechAudioFormatInfo(6, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
            Console.WriteLine(Text.Text);
            using (var ss = new SpeechSynthesizer())
            {
                ss.Volume = 100;
                ss.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                ss.Speak(Text.Text);

            }
        }
    }
}
