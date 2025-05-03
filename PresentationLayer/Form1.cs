

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

<<<<<<< HEAD
        private void countriesbtn_Click(object sender, EventArgs e)
        {
            CountriesForm countriesForm = new CountriesForm();
            countriesForm.ShowDialog();
=======
        private void continentsbtn_Click(object sender, EventArgs e)
        {
            ContinentsForm cf = new ContinentsForm();
            cf.ShowDialog();
        }

        private void teamsbtn_Click(object sender, EventArgs e)
        {
            TeamsForm tf = new TeamsForm();
            tf.ShowDialog();
>>>>>>> f5413b8 (Added TeamsForm and TrophiesForm)
        }

        private void stadiumssbtn_Click(object sender, EventArgs e)
        {
            StadiumsForm stadiumsForm = new StadiumsForm();
            stadiumsForm.ShowDialog();
        }

        private void continentsbtn_Click(object sender, EventArgs e)
        {
            ContinentsForm continentsForm = new ContinentsForm();
            continentsForm.ShowDialog();
        }
    }
}
