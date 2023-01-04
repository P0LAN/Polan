using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.Logging;
using System.Xml;
using System.Net;

namespace Polan
{
    public partial class Polan : MaterialForm
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = false;

        String temp;
        String condition;
        Choices list = new Choices();
        public Polan()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] { "hello", "how are you", "what time is it", "what is today", "what is the time", "open google", "open github", "open your website", "go to downloads page for polan", "wake", "sleep", "restart", "update", "open edge", "close edge", "what is the weather" , "what is the wather like" , "what is the tempreature", 
                "is it hot outside", "hey polan" , "minimize" , "maxamize" , "unminimize" , "play" , "pause" , "spotify" , "next" , "last"});

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

        public String GetWeather(String input)
        {
            String query = String.Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='portland, or')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            XmlDocument wData = new XmlDocument();
            try
            {
                wData.Load(input);
            }
            catch
            {
                MessageBox.Show("no internet :(");
                return "No internet";
            }

            XmlNamespaceManager manager = new XmlNamespaceManager(wData.NameTable);
            manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            XmlNode channel = wData.SelectSingleNode("query").SelectSingleNode("results").SelectSingleNode("channel");
            XmlNodeList nodes = wData.SelectNodes("query/results/channel");
            try
            {
                temp = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;
                condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;
            
                if (input == "temp")
                {
                    return temp;
                }
                if (input == "cond")
                {
                    return condition;
                }
            }
            catch
            {
                return "Error Reciving data";
            }
            return "error";
        }
        public static void killProg(String s)
        {
            System.Diagnostics.Process[] procs = null;

            try
            {
                procs = Process.GetProcessesByName(s);
                Process prog = procs[0];

                if (!prog.HasExited)
                {
                    prog.Kill();
                }
            }
            finally
            {
                if(procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }
            procs = null;
            
        }
        
       
        public void restart()
        {
            Process.Start(@"C:\Users\ttt\polan.exe");
            Environment.Exit(0);    
        }
       
        public void say(String h)
        {
            s.Speak(h);
            wake = false;
            materialMultiLineTextBox2.AppendText(h + '\n');
        }

        String[] greetings = new string[4] { "hi", "hello", "yes","welcome" };
        
        public String greetings_action()
        {
            Random r = new Random();
            return greetings[r.Next(4)];
        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;



            if(r == "hey polan")
            { 
                say(greetings_action());
                wake = true;
            }

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
     
            ////under construction ;)
          ///  if (materialCheckbox2.Checked == true) 
           /// {
            ///    wake = true;
           //     label2.Text = "awake";
           // }
           // else if (materialCheckbox2.Checked == false) 
           //{
            //    wake = false;
           //     label2.Text = "asleep";
          //  }

            if (wake == true)
            {//under construction
             //  if (r == "tell me a joke")
             // {
             //  say(w.DownloadString("http://api.yomama.info/").Replace("\"", "").Replace("{", "").Replace("}","").Replace(":","").Replace("joke",""));
             // }
                if (r == "spotify")
                {
                    Process.Start(new ProcessStartInfo("https://open.spotify.com") { UseShellExecute = true });
                }
                if (r == "next")
                {
                    SendKeys.Send("^{RIGHT} ");
                }
                if (r == "last")
                {
                    SendKeys.Send("^{LEFT} ");
                }
                if (r == "play" || r == "pause")
                {
                    SendKeys.Send(" ");
                }
                    if (r == "unminimize")
                {
                    this.WindowState = FormWindowState.Normal;
                }
                if (r == "minimize")
                {
                    this.WindowState= FormWindowState.Minimized;    
                }
                if (r == "maxamize")
                {
                    this.WindowState = FormWindowState.Maximized;
          
                }
                if (r == "what is the weather")
                {//what the voice assis says
                    say("the sky is, "+ GetWeather("cond") + ".");
                }
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
                    Process.Start(new ProcessStartInfo("https://www.google.com") { UseShellExecute = true });
                }
                if (r == "open edge")
                {
                    Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                }
                if (r == "close edge")
                {
                    killProg("msedge");
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