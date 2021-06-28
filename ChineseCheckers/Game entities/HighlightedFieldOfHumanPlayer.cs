using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class HighlightedFieldOfHumanPlayer
    {
        private int pos_X_HFHP;
        private int pos_Y_HFHP;
        private int fieldWidth;
        private int fieldLength;
        Pen pen = new Pen(Color.Black, 5);

        public HighlightedFieldOfHumanPlayer(int pos_X_HFHP, int pos_Y_HFHP, int fieldWidth, int fieldLength)
        {
            this.pos_X_HFHP = pos_X_HFHP;
            this.pos_Y_HFHP = pos_Y_HFHP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
        }

        public int Get_pos_X_HFHP()
        {
            return pos_X_HFHP;
        }

        public int Get_pos_Y_HFHP()
        {
            return pos_Y_HFHP;
        }


        public void DrawHighlightedFieldOfHumanPlayer(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen, this.pos_X_HFHP, this.pos_Y_HFHP, this.fieldWidth, this.fieldLength);
        }
    }
}
