using System;
using System.Windows.Forms;
using MSO_Practicum.Exceptions;

namespace MSO_Practicum
{
    public partial class Form1 : Form
    {
        private Facade facade;
        
        public Form1()
        {
            InitializeComponent();
            facade = new Facade();
            InputBox.TextChanged += InputBox_TextChanged;
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
            try
            {
                SetOutputText(facade.Run(InputBox.Text));
            }
            catch (ObstacleException ex)
            {
                SetOutputText(ex.Message);
            }
            catch (EdgeException ex)
            {
                SetOutputText(ex.Message);
            }
            gridPanel.Invalidate();
        }

        private void ButtonMETRICS_Click(object sender, System.EventArgs e)
        {
            SetOutputText(facade.Metrics(InputBox.Text));
        }

        private void GridPanel_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
        {
                facade.DrawGrid(e.Graphics, gridPanel.ClientRectangle);
        }

        private void LoadProgramToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void LoadExerciseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void BasicToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SetInputText(facade.LoadBasicFile());
        }

        private void AdvancedToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SetInputText(facade.LoadAdvancedFile());
        }

        private void ExpertToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SetInputText(facade.LoadExpertFile());
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            facade.ResetCharacter();
            gridPanel.Invalidate();
        }

        private void LoadGridToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.InitialDirectory =
                Path.Combine(AppContext.BaseDirectory, "Programs");
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            facade.LoadCustomGrid(openFileDialog1.FileName);
            gridPanel.Invalidate();
        }

        private void FromFileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Title = "Load program";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory =
                Path.Combine(AppContext.BaseDirectory, "Programs");
            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                SetInputText(facade.LoadCustomFile(openFileDialog1.FileName));
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, ex.Message, "Unable to load program",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(this, ex.Message, "Unable to load program",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}