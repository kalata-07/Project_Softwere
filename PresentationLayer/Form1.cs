

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void footballersbtn_Click(object sender, EventArgs e)
        {
            FootballersForm footballersForm = new FootballersForm();
            footballersForm.ShowDialog();
        }
    }
}
