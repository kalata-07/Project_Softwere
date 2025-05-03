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
                List<Footballer> footballers = footballerManager.ReadAll(true, false);
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

                footballerContext.Create(f);

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
                if (footballersdatagrid.CurrentRow == null || footballersdatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a footballer to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Footballer selected = footballersdatagrid.CurrentRow.DataBoundItem as Footballer;

                selected.FirstName = fnametb.Text;
                selected.LastName = lnametb.Text;
                selected.CountryCode = countrycodetb.Text;
                selected.TeamPosition = teampositiontb.Text;
                selected.Age = Convert.ToInt32(agetb.Text);
                selected.ShirtNumber = Convert.ToInt32(shirtnumbertb.Text);
                selected.Salary = Convert.ToDecimal(salarytb.Text);
                selected.Trophies = Convert.ToInt32(trophiestb.Text);
                selected.TeamId = int.Parse(teamidtb.Text);

                footballerManager.Update(selected, true);
                MessageBox.Show("Footballer updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFootballers();
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
                if (footballersdatagrid.CurrentRow == null || footballersdatagrid.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Please select a footballer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Footballer selected = footballersdatagrid.CurrentRow.DataBoundItem as Footballer;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete {selected.FirstName} {selected.LastName}?",
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    footballerManager.Delete(selected.Id);
                    MessageBox.Show("Footballer deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFootballers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
