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
using System.Speech;

namespace TextToSpeechDemo
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speech;
        public Form1()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                speech.SelectVoice(comboBox1.Text);
                speech.SpeakAsync(richTextBox1.Text);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Speaking)
            {
                speech.Pause();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Paused)
            {
                speech.Resume();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var voice in speech.GetInstalledVoices())
            {
                comboBox1.Items.Add(voice.VoiceInfo.Name);
            }
                  

        }
    }
}
