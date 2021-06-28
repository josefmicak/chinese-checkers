using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class HumanPlayer
    {
        private int pos_X_HP;
        private int pos_Y_HP;
        private int fieldWidth;
        private int fieldLength;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush br = new SolidBrush(Color.DodgerBlue);

        public HumanPlayer(int pos_X_HP, int pos_Y_HP, int fieldWidth, int fieldLength)
        {
            this.pos_X_HP = pos_X_HP;
            this.pos_Y_HP = pos_Y_HP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
        }

        public int Get_pos_X_HP()
        {
            return pos_X_HP;
        }

        public int Get_pos_Y_HP()
        {
            return pos_Y_HP;
        }

        public void DrawHumanPlayer(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, this.pos_X_HP, this.pos_Y_HP, this.fieldWidth, this.fieldLength);
            e.Graphics.DrawEllipse(pen, this.pos_X_HP, this.pos_Y_HP, this.fieldWidth, this.fieldLength);
        }
    }
}
