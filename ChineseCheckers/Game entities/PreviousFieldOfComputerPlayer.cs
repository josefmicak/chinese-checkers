using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class PreviousFieldOfComputerPlayer
    {
        private int pos_X_PFCP;
        private int pos_Y_PFCP;
        private int fieldWidth;
        private int fieldLength;
        private int computerPlayerId;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brCyan = new SolidBrush(Color.Cyan);
        SolidBrush brSalmon = new SolidBrush(Color.Salmon);
        SolidBrush brPaleGreen = new SolidBrush(Color.PaleGreen);
        SolidBrush brKhaki = new SolidBrush(Color.PapayaWhip);
        SolidBrush brMagenta = new SolidBrush(Color.Magenta);
        SolidBrush brPeru = new SolidBrush(Color.BurlyWood);

        public PreviousFieldOfComputerPlayer(int pos_X_PFCP, int pos_Y_PFCP, int fieldWidth, int fieldLength, int computerPlayerId)
        {
            this.pos_X_PFCP = pos_X_PFCP;
            this.pos_Y_PFCP = pos_Y_PFCP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
            this.computerPlayerId = computerPlayerId;
        }

        public int Get_pos_X_PFCP()
        {
            return pos_X_PFCP;
        }

        public int Get_pos_Y_PFCP()
        {
            return pos_Y_PFCP;
        }

        public int Get_computerPlayerId()
        {
            return computerPlayerId;
        }

        public void DrawPreviousFieldOfComputerPlayer(PaintEventArgs e, int computerPlayerId)
        {
            switch (computerPlayerId)
            {
                case 0:
                    e.Graphics.FillEllipse(brCyan, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
                case 2:
                    e.Graphics.FillEllipse(brSalmon, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
                case 3:
                    e.Graphics.FillEllipse(brPaleGreen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
                case 4:
                    e.Graphics.FillEllipse(brKhaki, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
                case 5:
                    e.Graphics.FillEllipse(brMagenta, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
                case 6:
                    e.Graphics.FillEllipse(brPeru, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_PFCP, this.pos_Y_PFCP, this.fieldWidth, this.fieldLength);
                    break;
            }
        }
    }
}
