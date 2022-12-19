using System.Speech.Synthesis;


namespace Polan
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Form1()
        {
            s.SelectVoiceByHints(VoiceGender.Male);
            s.Speak("polan starting up");

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}