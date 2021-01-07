using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechLib.SpVoiceClass voiceclass = new SpeechLib.SpVoiceClass();

            foreach(ISpeechObjectToken outputs in voiceclass.GetAudioOutputs())
            {
                var t = outputs.GetDescription(49);
                if (t.Contains("Porta")) voiceclass.AudioOutput = (SpObjectToken)outputs;
            }

            foreach (ISpeechObjectToken Token in voiceclass.GetVoices(string.Empty, string.Empty))
            {
                if (Token.GetDescription(49).Contains("David")) voiceclass.SetVoice((ISpObjectToken)Token);

            }

            voiceclass.Speak("test!");
        }
    }
}
