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
                if (teamdatagrid.CurrentRow == null || teamdatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a team to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Team selected = teamdatagrid.CurrentRow.DataBoundItem as Team;

                selected.Id = Convert.ToInt32(t1.Text);
                selected.Name = t2.Text;
                selected.CountryCode = t3.Text;
                selected.CoachName = t4.Text;
                selected.Colours = t4.Text;
                selected.Founded = Convert.ToInt32(t6.Text);
                selected.TeamStadium = t7.Text;

                teamManager.Update(selected, true);
                MessageBox.Show("Team updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (teamdatagrid.CurrentRow == null || teamdatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a team to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Team selected = teamdatagrid.CurrentRow.DataBoundItem as Team;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete {selected.Name}?",
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    teamManager.Delete(selected.Id);
                    MessageBox.Show("Footballer deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTeams();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
