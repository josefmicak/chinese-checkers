using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class PossibleMoveOfHumanPlayer
    {
        private int pos_X_PM;
        private int pos_Y_PM;
        private int pos_X_PFPMHP;
        private int pos_Y_PFPMHP;
        private int fieldWidth;
        private int fieldLength;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush br = new SolidBrush(Color.Cyan);

        public PossibleMoveOfHumanPlayer(int pos_X_PM, int pos_Y_PM, int pos_X_PFPMHP, int pos_Y_PFPMHP, int fieldWidth, int fieldLength)
        {
            this.pos_X_PM = pos_X_PM;
            this.pos_Y_PM = pos_Y_PM;
            this.pos_X_PFPMHP = pos_X_PFPMHP;
            this.pos_Y_PFPMHP = pos_Y_PFPMHP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
        }

        public int Get_pos_X_PM()
        {
            return pos_X_PM;
        }

        public int Get_pos_Y_PM()
        {
            return pos_Y_PM;
        }

        public int Get_pos_X_PFPMHP()
        {
            return pos_X_PFPMHP;
        }

        public int Get_pos_Y_PFPMHP()
        {
            return pos_Y_PFPMHP;
        }
        public void DrawPossibleMoveOfHumanPlayer(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, this.pos_X_PM, this.pos_Y_PM, this.fieldWidth, this.fieldLength);
            e.Graphics.DrawEllipse(pen, this.pos_X_PM, this.pos_Y_PM, this.fieldWidth, this.fieldLength);
        }
    }
}
