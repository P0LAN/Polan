using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.Logging;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Drawing.Text;

namespace Polan
{
    /// <summary>
    /// Most commits : polan foundation
    /// Website : https://p0lan.github.io/main
    /// github repo link : https://github.com/p0lan/polan/
    /// polan will not stay with winforms nor c# (might still use c#) as
    /// its planned to finish its c++ replica so we can continue there
    /// also please notice that we aknowledge that polan setup files 
    /// are not uploaded to github because of lack of motivation for coding this :(
    /// but i do have some that i will upload after this commit
    /// last commit hashcode for tracking commits is : #27g485
    /// </summary>
    public partial class Polan : MaterialForm
    {

        String V = "1.5" ;
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = false;
        Boolean search = false;
  
        String name = "User";
        String namePath = @"C:\Program Files (x86)\Polan\P0LAN\saved.txt";

        WebClient w = new WebClient();
        Choices list = new Choices();
        public Polan()
               
        {

           

            list.Add(File.ReadAllLines(@"C:\Program Files (x86)\Polan\P0LAN\commands.txt"));
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
           

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
            release_number();
        }

        private void release_number()
        {
            Release.Text = "Version"+V;
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
            Process.Start(@"C:\Program Files (x86)\Polan\P0LAN\polan.exe");
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

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e )
        {

            String r = e.Result.Text;



            if (r == "hey polan")
            {
                say(greetings_action());
                wake = true;
            }

            if (search)
            {
                Process.Start(new ProcessStartInfo("https://duckduckgo.com/?q=" + r + "&t=h_&ia=web") { UseShellExecute = true });
                search = false;
            }

       ///     if (r == "sleep")         closed the command because polan sleeps after getting
       ///                              the command and executing it but i might add this in the future
        ///    {
          ///      wake = false;
            ///    label2.Text = "asleep";
          ///  }
      

            ////                       under construction ;)
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


            if (wake == true && search == false)
            {
            

                switch (r)
                {
                   

                    case "what is my name":
                        say("your name is " + name);
                        break;
                    case "stop":
                        say("ok" + name);
                        s.SpeakAsyncCancelAll();
                        break;
                    case "wake":
                        say("waking up");
                         wake = true;
                        break;
                    case "restart":
                        say("restarting now" + name);
                        restart();
                        break;
                    case "how are you":
                say("im fine"+ name);
                break;
                    case "give me a random quote":
                        say("ok"+name+w.DownloadString("https://api.quotable.io/random?tags=technology,famous-quotes"));
                        break;
                    case "give me a random number":
                        say(w.DownloadString("http://www.randomnumberapi.com/api/v1.0/random?min=100&max=1000&count=1"));
                        break;
                   case"tell me a joke":

                        say("ok"+name+w.DownloadString("http://api.yomomma.info/").Replace("\"", "").Replace("{", "").Replace("}", "").Replace(":", "").Replace("joke", ""));
                      break;
                    case "what is the weather":
                    case "what is the weather like":
                        say("showing weather right now");
                        Process.Start(new ProcessStartInfo("https://www.tomorrow.io/weather/") { UseShellExecute = true });

                        break;
                    case "search for":
                        search = true;
                        break;
                    case "open soundcloud":
                        Process.Start(new ProcessStartInfo("https://soundcloud.com") { UseShellExecute = true });
                        break;
                    case "open spotify":
                        Process.Start(new ProcessStartInfo("https://open.spotify.com") { UseShellExecute = true });
                        break;
                    case "next":
                        SendKeys.Send("^{RIGHT} ");
                        break;
                    case "last":
                        SendKeys.Send("^{LEFT} ");
                        break;
                    case "play":
                    case "pause":
                        SendKeys.Send(" ");
                        break;
                    case "unminimize":
                        this.WindowState = FormWindowState.Normal;
                        break;
                    case "minimize":
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case "maxamize":
                        this.WindowState = FormWindowState.Maximized;
                        break;
                    case "hello":
                        say("Hi");
                        break;
                    case "what is the time":
                    case "what time is it":
                        say(DateTime.Now.ToString("h:mm tt"));
                        break;
                    case "what is today":
                        say(DateTime.Now.ToString("M/d/yyyy"));
                        break;
                    case "open google":
                        Process.Start(new ProcessStartInfo("https://www.google.com") { UseShellExecute = true });
                        break;
                    case "open edge":
                        Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                        break;
                    case "close edge":
                        killProg("msedge");
                        break;
                    default:
                        break;

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

        private void Main_Click(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

       
           
        
    }
}



