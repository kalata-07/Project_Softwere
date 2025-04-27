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
using ServiceLayer;

namespace PresentationLayer
{
    public partial class FootballersForm : Form
    {
        private LibraryManager<Footballer, int> footmallerManager;
        private FootballerContext footballerContext;
        private DBLibraryContext context;
        public FootballersForm()
        {
            InitializeComponent();
            context = new DBLibraryContext();
            footballerContext = new FootballerContext(context);
            footmallerManager = new LibraryManager<Footballer, int>(footballerContext);
        }

        private void FootballersForm_Load(object sender, EventArgs e)
        {

        }

        private void footballersread_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            footballersread.DataSource = footmallerManager.ReadAll(true, false);
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (fnametb.Text.Length != 0)
                {
                    Footballer footballer = new Footballer();
                    footballer.FirstName = fnametb.Text;
                    footballer.LastName = lnametb.Text;
                    footballer.CountryCode = countrycodetb.Text;
                    footballer.TeamPosition = teampositiontb.Text;
                    footballer.Age = Convert.ToInt32(agetb.Text);
                    footballer.ShirtNumber = Convert.ToInt32(shirtnumbertb.Text);
                    footballer.Price = Convert.ToDecimal(pricetb.Text);
                    footballer.Salary = Convert.ToDecimal(salarytb.Text);

                    footmallerManager.Create(footballer);

                    MessageBox.Show("Footballer Created");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void readallbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
