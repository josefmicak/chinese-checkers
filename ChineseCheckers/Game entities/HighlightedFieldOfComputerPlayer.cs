using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class HighlightedFieldOfComputerPlayer
    {
        private int pos_X_HFCP;
        private int pos_Y_HFCP;
        private int fieldWidth;
        private int fieldLength;
        Pen pen = new Pen(Color.Black, 5);

        public HighlightedFieldOfComputerPlayer(int pos_X_HFCP, int pos_Y_HFCP, int fieldWidth, int fieldLength)
        {
            this.pos_X_HFCP = pos_X_HFCP;
            this.pos_Y_HFCP = pos_Y_HFCP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
        }

        public int Get_pos_X_HFCP()
        {
            return pos_X_HFCP;
        }

        public int Get_pos_Y_HFCP()
        {
            return pos_Y_HFCP;
        }

        public void DrawHighlightedFieldOfComputerPlayer(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen, this.pos_X_HFCP, this.pos_Y_HFCP, this.fieldWidth, this.fieldLength);
        }
    }
}
