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
            LoadTeams();
        }

        private void LoadTeams()
        {
            try
            {
                List<Team> teams = teamManager.ReadAll(true, false);
                teamdatagrid.DataSource = teams;
                teamdatagrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Clear();
            t6.Clear();
            t7.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                Team t = new Team
                {
                    Id = Convert.ToInt32(t1.Text),
                    Name = t2.Text,
                    CountryCode = t3.Text,
                    CoachName = t4.Text,
                    Colours = t5.Text,
                    Founded = Convert.ToInt32(t6.Text),
                    TeamStadium = t7.Text
                };

                teamContext.Create(t);
                MessageBox.Show("Team added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void teamGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void readAll_Click(object sender, EventArgs e)
        {
            LoadTeams();
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {

                Team team = new Team
                {

                    Id = int.Parse(t1.Text.Trim()),
                    Name = t2.Text.Trim(),
                    CountryCode = t3.Text.Trim(),
                    CoachName = t4.Text.Trim(),
                    Colours = t4.Text.Trim(),
                    Founded = int.Parse(t6.Text.Trim()),
                    TeamStadium = t7.Text.Trim()
                };

                teamManager.Update(team);
                MessageBox.Show("Team updated successfully!");
                LoadTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating team: " + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(t1.Text.Trim());
                teamManager.Delete(id);
                MessageBox.Show("Team deleted successfully.");
                LoadTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting team: " + ex.Message);
            }
            ClearForm();
        }
    }
}
