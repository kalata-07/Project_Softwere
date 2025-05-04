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
    public partial class StadiumsForm : Form
    {
        private LibraryManager<Stadium, int> stadiumManager;
        private StadiumContext stadiumContext;
        private DBLibraryContext context;


        public StadiumsForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            stadiumContext = new StadiumContext(context);
            stadiumManager = new LibraryManager<Stadium, int>(stadiumContext);
        }

        private void StadiumForm_Load(object sender, EventArgs e)
        {
            LoadStadiums();
            stadiumsDataGrid.DataSource = stadiumManager.ReadAll(true, false);

        }

        private void LoadStadiums()
        {
            try
            {
                List<Stadium> stadiums = stadiumManager.ReadAll(true, false);
                stadiumsDataGrid.DataSource = stadiums;
                stadiumsDataGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            townNametb.Clear();
            countryCodetb.Clear();
            capacitytb.Clear();
            nametb.Clear();
            idtb.Clear();

        }
        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                Stadium stadium = new Stadium
                {
                    Id = int.Parse(idtb.Text),
                    Name = nametb.Text,
                    Capacity = int.Parse(capacitytb.Text),
                    CountryCode = countryCodetb.Text,
                    TownName = townNametb.Text
                };
                stadiumManager.Create(stadium);
                MessageBox.Show("Stadium created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStadiums();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readAll_Click(object sender, EventArgs e)
        {
            LoadStadiums();
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                Stadium stadium = new Stadium
                {
                    Id = int.Parse(idtb.Text.Trim()),
                    Name = nametb.Text.Trim(),
                    Capacity = int.Parse(capacitytb.Text.Trim()),
                    CountryCode = countryCodetb.Text.Trim(),
                    TownName = townNametb.Text.Trim()
                };

                stadiumManager.Update(stadium);
                MessageBox.Show("Stadium updated successfully.");
                LoadStadiums();
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stadium: " + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idtb.Text.Trim());
                stadiumManager.Delete(id);
                MessageBox.Show("Stadium deleted successfully.");
                LoadStadiums();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting stadium: " + ex.Message);
            }
            ClearForm();
        }
    }
}
