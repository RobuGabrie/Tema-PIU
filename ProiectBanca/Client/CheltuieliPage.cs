using System.Windows.Forms;

namespace ProiectBanca
{
    public class CheltuieliPage : UserControl
    {
        public CheltuieliPage()
        {
            Label label = new Label
            {
                Text = "Cheltuieli Page",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
        }
    }
}
