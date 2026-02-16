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
    public partial class ContinentsForm : Form
    {
        private LibraryManager<Continent, string> continentManager;
        private ContinentContext continentContext;
        private DBLibraryContext context;
        public ContinentsForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            continentContext = new ContinentContext(context);
            continentManager = new LibraryManager<Continent, string>(continentContext);
        }

        private void ContinentForm_Load(object sender, EventArgs e)
        {
            LoadContinentsAsync();
            continentsDataGrid.DataSource = continentManager.ReadAllAsync(true, false);

        }

        private async Task LoadContinentsAsync()
        {
            try
            {
                IEnumerable<Continent> continents = await continentManager.ReadAllAsync(true, false);
                continentsDataGrid.DataSource = continents;
                continentsDataGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void continentssDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (continentsDataGrid.CurrentRow?.DataBoundItem is Continent selected)
            {
                continentCodetb.Text = selected.ContinentCode;
                continentNametb.Text = selected.ContinentName;

            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                Continent continent = new Continent
                {
                    ContinentCode = continentCodetb.Text,
                    ContinentName = continentNametb.Text
                };

                continentManager.CreateAsync(continent);
                MessageBox.Show("Continent created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadContinentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readAll_Click(object sender, EventArgs e)
        {
            LoadContinentsAsync();
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                Continent continent = new Continent
                {
                    ContinentCode = continentCodetb.Text,
                    ContinentName = continentNametb.Text
                };

                continentManager.UpdateAsync(continent);
                MessageBox.Show("Continent updated successfully.");
                LoadContinentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating continent: " + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string code = continentCodetb.Text.Trim();
                continentManager.DeleteAsync(code);
                MessageBox.Show("Continent deleted successfully.");
                LoadContinentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting continent: " + ex.Message);
            }
        }

      
    }
}
