using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhepHinh
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            LoadImage();
        }
        public static Image filename;
        void LoadImage()
        {
            try
            {
                if (filename!=null)
                
                pitImageHelp.Image = filename;
            }
            catch
            {
               
            }
          
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
    }
}
