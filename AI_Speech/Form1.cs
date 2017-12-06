using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace AI_Speech
{
    public partial class Form1 : Form
    {
        bool search = false;
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
            Choices list = new Choices();
            list.Add(new string[] { "hi","what are you doing","sos 4 it", "hello","open google","open notepad","bye","minimize","what i can do now", "sumer","fullscreen","normal","kill this", "search for","facebook","gmail","youtube","sos fix", "how are you", "what is your name","so","fine","song","github","are you ok","good"});
            Grammar gm = new Grammar(new GrammarBuilder(list));
            try
            {
                reco.RequestRecognizerUpdate();
                reco.LoadGrammar(gm);
                reco.SpeechRecognized += Reco_SpeechRecognized;
                reco.SetInputToDefaultAudioDevice();
                reco.RecognizeAsync(RecognizeMode.Multiple);
                s.SpeakAsync("welcome back sir");
            }
            catch { MessageBox.Show("There is Sume Thing Wrong in Your Device Speech..."); }
        }
        private void Reco_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string a = e.Result.Text;

            if (search)
            {
                Process.Start("https://www.google.com/search?q=" + a);
                search = false;
            }
            if (a == "search for")
            {
                search = true;
                s.Speak("tell me what to search for");
            }
            if (search == false)
            {
                switch (a)
                {
                    case ("hi"):
                        s.SpeakAsync("hi");
                        break;
                    case ("what i can do now"):
                        s.SpeakAsync("you can conrol me just tall me what i can do for you");
                        break;
                    case ("good"):
                        s.SpeakAsync("yab");
                        break;
                    case ("what are you doing"):
                        s.SpeakAsync("i listen to your command sir");
                        break;
                    case ("fine"):
                        s.SpeakAsync("oh great");
                        break;
                    case ("are you ok"):
                        s.SpeakAsync("yes i think");
                        break;
                    case ("so"):
                        s.SpeakAsync("so what");
                        break;
                    case ("what is your name"):
                        s.SpeakAsync("iam speech bot");
                        break;
                    case ("how are you"):
                        s.SpeakAsync("fine thanks");
                        break;
                    case ("hello"):
                        s.SpeakAsync("hello how are you");
                        break;
                    case ("open google"):
                        s.SpeakAsync("opening google");
                        Process.Start("https://www.goole.com");
                        break;
                    case ("open notepad"):
                        s.SpeakAsync("opening notepad");
                        Process.Start("notepad.exe");
                        break;
                    case ("minimize"):
                        WindowState = FormWindowState.Minimized;
                        break;
                    case ("fullscreen"):
                        WindowState = FormWindowState.Maximized;
                        break;
                    case ("normal"):
                        WindowState = FormWindowState.Normal;
                        break;
                    case ("kill this"):
                        SendKeys.Send("%{F4}");
                        break;
                    case ("sos fix"):
                        inputForm ob = new inputForm();
                        ob.Show();
                        break;
                    case ("bye"):
                        s.Speak("ok bye may have a good day");
                        this.Close();
                        break;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
