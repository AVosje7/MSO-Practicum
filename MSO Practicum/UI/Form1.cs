using System;
using System.Windows.Forms;

namespace MSO_Practicum
{
    public partial class Form1 : Form
    {
        private Facade facade;
        private TextBox commandBox;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void SetInputText(string text)
        {
            InputBox.Text = text;
        }

        public void SetOutputText(string text)
        {
            OutputBox.Text = text;
        }

        private void ButtonRUN_Click(object sender, System.EventArgs e)
        {
            SetOutputText(facade.Run(InputBox.Text));
        }

        private void ButtonMETRICS_Click(object sender, System.EventArgs e)
        {
            SetOutputText(facade.Metrics(InputBox.Text));
        }

        private void GridPanel_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void LoadProgramToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void LoadExerciseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void BasicToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void AdvancedToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void ExpertToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
    }
}