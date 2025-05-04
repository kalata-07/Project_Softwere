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

                Trophy trophy = new Trophy
                {

                    Id = int.Parse(t1.Text.Trim()),
                    Name = t2.Text.Trim(),
                    CountryCode = t3.Text.Trim(),
                    ContinentCode = t4.Text.Trim(),
                    Footballers = int.Parse(t5.Text.Trim())
                };


                trophyManager.Update(trophy);
                MessageBox.Show("Trophy updated successfully!");
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
                int id = int.Parse(t1.Text.Trim());
                trophyManager.Delete(id);
                MessageBox.Show("Trophy deleted successfully.");
                LoadTrophies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting trophy: " + ex.Message);
            }
            ClearForm();
        }

        

        
    }
}
