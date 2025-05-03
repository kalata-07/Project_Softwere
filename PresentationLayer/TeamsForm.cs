using BusinessLayer;
using DataLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{

    public partial class TeamsForm : Form
    {
        private LibraryManager<Team, int> teamManager;
        private TeamsContext teamContext;
        private DBLibraryContext context;
        public TeamsForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            teamContext = new TeamsContext(context);
            teamManager = new LibraryManager<Team, int>(teamContext);
        }
        private void TeamsForm_Load(object sender, EventArgs e)
        {
            teamGridView.DataSource = teamManager.ReadAll(true, false);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {

                if (t2.Text.Length != 0)
                {
                    Team team = new Team();
                    team.Name = t2.Text;
                    team.CountryCode = t3.Text;
                    team.CoachName = t4.Text;
                    team.Colours = t5.Text;
                    team.Founded = Convert.ToInt32(t6.Text);
                    team.TeamStadium = t7.Text;

                    teamManager.Create(team);

                    MessageBox.Show("Team Created");
                    teamGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
