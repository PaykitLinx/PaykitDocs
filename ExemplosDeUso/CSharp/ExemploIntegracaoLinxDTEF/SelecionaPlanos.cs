using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinxDTEF
{

  public partial class SelecionaPlanos : Form
  {
    public int status;
    public SelecionaPlanos()
    {
      status = 0;
      InitializeComponent();
    }

    private void btOk_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      status = -2;
      Close();
    }
  }
}
