using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class Field
    {
        private int pos_X_F;
        private int pos_Y_F;
        private int fieldWidth;
        private int fieldLength;
        private bool isActive;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brWhite = new SolidBrush(Color.White);
        SolidBrush brGray = new SolidBrush(Color.Gray);

        public Field(int pos_X_F, int pos_Y_F, int fieldWidth, int fieldLength, bool isActive)
        {
            this.pos_X_F = pos_X_F;
            this.pos_Y_F = pos_Y_F;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
            this.isActive = isActive;
        }

        public int Get_pos_X_F()
        {
            return pos_X_F;
        }

        public int Get_pos_Y_F()
        {
            return pos_Y_F;
        }

        public void Set_isActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public void DrawField(PaintEventArgs e)
        {
            if (isActive)
            {
                e.Graphics.FillEllipse(brWhite, this.pos_X_F, this.pos_Y_F, this.fieldWidth, this.fieldLength);
            }
            else
            {
                e.Graphics.FillEllipse(brGray, this.pos_X_F, this.pos_Y_F, this.fieldWidth, this.fieldLength);
            }
            e.Graphics.DrawEllipse(pen, this.pos_X_F, this.pos_Y_F, this.fieldWidth, this.fieldLength);
        }
    }
}
