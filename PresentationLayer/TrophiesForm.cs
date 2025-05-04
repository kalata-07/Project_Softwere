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
    public partial class TrophiesForm : Form
    {
        private LibraryManager<Trophy, int> trophyManager;
        private TrophiesContext trophyContext;
        private DBLibraryContext context;
        public TrophiesForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            trophyContext = new TrophiesContext(context);
            trophyManager = new LibraryManager<Trophy, int>(trophyContext);
        }

        private void TrophiesForm_Load(object sender, EventArgs e)
        {
            LoadTrophies();
        }

        private void LoadTrophies()
        {
            try
            {
                List<Trophy> teams = trophyManager.ReadAll(true, false);
                trophydatagrid.DataSource = teams;
                trophydatagrid.AutoResizeColumns();
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
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Trophy t = new Trophy
                {
                    Id = Convert.ToInt32(t1.Text),
                    Name = t2.Text,
                    CountryCode = t3.Text,
                    ContinentCode = t4.Text,
                    Footballers = Convert.ToInt32(t5.Text)
                };

                trophyContext.Create(t);
                MessageBox.Show("Trophy added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readallbtn_Click(object sender, EventArgs e)
        {
            LoadTrophies();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (trophydatagrid.CurrentRow == null || trophydatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a team to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Trophy selected = trophydatagrid.CurrentRow.DataBoundItem as Trophy;

                selected.Id = Convert.ToInt32(t1.Text);
                selected.Name = t2.Text;
                selected.CountryCode = t3.Text;
                selected.ContinentCode = t4.Text;
                selected.Footballers = Convert.ToInt32(t5.Text);


                trophyManager.Update(selected, true);
                MessageBox.Show("Trophy updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTrophies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (trophydatagrid.CurrentRow == null || trophydatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a footballer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Trophy selected = trophydatagrid.CurrentRow.DataBoundItem as Trophy;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete {selected.Name}?",
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    trophyManager.Delete(selected.Id);
                    MessageBox.Show("Trophy deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTrophies();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
