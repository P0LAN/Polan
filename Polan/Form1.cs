using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System;
using MaterialSkin;
using MaterialSkin.Controls;


namespace Polan
{
    public partial class Polan : MaterialForm
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;

        Choices list = new Choices();
        public Polan()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] { "hello", "how are you", "what time is it", "what is today", "what is the time", "open google", "open github", "open your website", "go to downloads page for polan", "wake", "sleep", "restart", "update" });

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


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.Grey900, Primary.Grey500, Accent.LightBlue200, TextShade.WHITE);

            s.SelectVoiceByHints(VoiceGender.Male);
            s.Speak("polan starting up");

            InitializeComponent();
        }
        /// test public void down
       
        public void restart()
        {
            Process.Start(@"C:\Users\ttt\polan.exe");
            Environment.Exit(0);    
        }
       
        public void say(String h)
        {
            s.Speak(h);
            materialMultiLineTextBox2.AppendText(h + '\n');
        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if (r == "wake")
            {
                wake = true;
                label2.Text = "awake";
            }

            if (r == "sleep")
            {
                wake = false;
                label2.Text = "asleep";
            }
     

            if (materialCheckbox2.Checked == true) 
            {
                wake = true;
                label2.Text = "awake";
            }
            else if (materialCheckbox2.Checked == false) 
            {
                wake = false;
                label2.Text = "asleep";
            }

            if (wake == true)
            {

                //what you say
                if (r == "hello")
                {//what the voice assis says
                    say("Hi");
                }
                if (r == "what is the time" || r == "what time is it")
                {//what the voice assis says
                    say(DateTime.Now.ToString("h:mm tt"));
                }
                if (r == "what is today")
                {//what the voice assis says
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }
                if (r == "open google")
                {
                    Process.Start("http://google.com");
                }

            }
            materialMultiLineTextBox1.AppendText(r + '\n');


            
        
}
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }
      
    }
}