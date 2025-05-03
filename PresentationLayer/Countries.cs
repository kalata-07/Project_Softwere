using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer
{
    public partial class CountriesForm : Form
    {
        private LibraryManager<Country, string> countryManager;
        private CountryContext countryContext;
        private DBLibraryContext context;

        public CountriesForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            countryContext = new CountryContext(context);
            countryManager = new LibraryManager<Country, string>(countryContext);
        }

        private void CountryForm_Load(object sender, EventArgs e)
        {
            LoadCountries();
            countriesDataGrid.DataSource = countryManager.ReadAll(true, false);

        }

        private void LoadCountries()
        {
            try
            {
                List<Country> countries = countryManager.ReadAll(true, false);
                countriesDataGrid.DataSource = countries;
                countriesDataGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Country country = new Country
                {
                    CountryCode = countrycodetb.Text,
                    CountryName = countrynametb.Text,
                    ContinentCode = continentcodetb.Text
                };
                countryManager.Create(country);
                MessageBox.Show("Country created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCountries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readallbtn_Click(object sender, EventArgs e)
        {
            LoadCountries();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (countriesDataGrid.CurrentRow?.DataBoundItem is not Country selected)
                {
                    MessageBox.Show("Select a country to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selected.CountryName = countrynametb.Text;
                selected.ContinentCode = continentcodetb.Text;

                countryManager.Update(selected);
                MessageBox.Show("Country updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCountries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (countriesDataGrid.CurrentRow?.DataBoundItem is not Country selected)
                {
                    MessageBox.Show("Select a country to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Delete country {selected.CountryName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    countryManager.Delete(selected.CountryCode);
                    MessageBox.Show("Country deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCountries();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void countriesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (countriesDataGrid.CurrentRow?.DataBoundItem is Country selected)
            {
                countrycodetb.Text = selected.CountryCode;
                countrynametb.Text = selected.CountryName;
                continentcodetb.Text = selected.ContinentCode;
            }
        }
        
    }
}
