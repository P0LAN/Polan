using System.Speech.Synthesis;
using System.Speech.Recognition;



namespace Polan
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] { "hello", "how are you" });

            Grammar gr  = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }




            s.SelectVoiceByHints(VoiceGender.Male);
            s.Speak("polan starting up");

            InitializeComponent();
        }

        public void say(String h)
        {
            s.Speak(h);
        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            //what you say
            if (r == "hello")
            {//what the voice assis says
                say("Hi");
            }
            if (r == "how are you")
            {//what the voice assis says
                say("Great, and you?");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}