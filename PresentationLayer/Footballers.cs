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
using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class FootballersForm : Form
    {
        private LibraryManager<Footballer, int> footballerManager;
        private FootballerContext footballerContext;
        private DBLibraryContext context;


        public FootballersForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            footballerContext = new FootballerContext(context);
            footballerManager = new LibraryManager<Footballer, int>(footballerContext);
        }


        private void FootballersForm_Load(object sender, EventArgs e)
        {
            LoadFootballers();
        }

        private void LoadFootballers()
        {
            try
            {
                IEnumerable<Footballer> footballers = (IEnumerable<Footballer>)footballerManager.ReadAllAsync(true, false);
                footballersdatagrid.DataSource = footballers;
                footballersdatagrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            idtb.Clear();
            fnametb.Clear();
            lnametb.Clear();
            agetb.Clear();
            shirtnumbertb.Clear();
            teampositiontb.Clear();
            countrycodetb.Clear();
            salarytb.Clear(); 
            trophiestb.Clear();
            teamidtb.Clear();
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Footballer f = new Footballer
                {
                    Id = int.Parse(idtb.Text),
                    FirstName = fnametb.Text,
                    LastName = lnametb.Text,
                    Age = int.Parse(agetb.Text),
                    ShirtNumber = int.Parse(shirtnumbertb.Text),
                    TeamId = int.Parse(teamidtb.Text), 
                    TeamPosition = teampositiontb.Text,
                    CountryCode = countrycodetb.Text,
                    Salary = decimal.Parse(salarytb.Text),
                    Trophies = int.Parse(trophiestb.Text)
                };

                footballerContext.CreateAsync(f);

                MessageBox.Show("Footballer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readallbtn_Click(object sender, EventArgs e)
        {
            LoadFootballers();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Footballer footballer = new Footballer
                {
                    Id = int.Parse(idtb.Text.Trim()),
                    FirstName = fnametb.Text.Trim(),
                    LastName = lnametb.Text.Trim(),
                    Age = int.Parse(agetb.Text.Trim()),
                    ShirtNumber = int.Parse(shirtnumbertb.Text.Trim()),
                    TeamPosition = teampositiontb.Text.Trim(),
                    CountryCode = countrycodetb.Text.Trim(),
                    Trophies = int.Parse(trophiestb.Text.Trim()),
                    Salary = decimal.Parse(salarytb.Text.Trim()),
                    TeamId = int.Parse(teamidtb.Text.Trim())
                };

                footballerManager.UpdateAsync(footballer);
                MessageBox.Show("Footballer updated successfully.");
                LoadFootballers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating footballer: " + ex.Message);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idtb.Text.Trim());
                footballerManager.DeleteAsync(id);
                MessageBox.Show("Footballer deleted successfully.");
                LoadFootballers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting footballer: " + ex.Message);
            }
            ClearForm();
        }
    }
}
