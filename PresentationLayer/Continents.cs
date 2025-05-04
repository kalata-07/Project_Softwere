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
            LoadContinents();
            continentsDataGrid.DataSource = continentManager.ReadAll(true, false);

        }

        private void LoadContinents()
        {
            try
            {
                List<Continent> continents = continentManager.ReadAll(true, false);
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

                continentManager.Create(continent);
                MessageBox.Show("Continent created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadContinents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readAll_Click(object sender, EventArgs e)
        {
            LoadContinents();
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

                continentManager.Update(continent);
                MessageBox.Show("Continent updated successfully.");
                LoadContinents();
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
                continentManager.Delete(code);
                MessageBox.Show("Continent deleted successfully.");
                LoadContinents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting continent: " + ex.Message);
            }
        }

      
    }
}
