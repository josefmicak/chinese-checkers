using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Game_entities
{
    class ComputerPlayer
    {
        private int pos_X_CP;
        private int pos_Y_CP;
        private int fieldWidth;
        private int fieldLength;
        private int computerPlayerId;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brBlue = new SolidBrush(Color.DodgerBlue);
        SolidBrush brRed = new SolidBrush(Color.Red);
        SolidBrush brGreen = new SolidBrush(Color.LimeGreen);
        SolidBrush brYellow = new SolidBrush(Color.Yellow);
        SolidBrush brPurple = new SolidBrush(Color.Purple);
        SolidBrush brChocolate = new SolidBrush(Color.Chocolate);

        public ComputerPlayer(int pos_X_CP, int pos_Y_CP, int fieldWidth, int fieldLength, int computerPlayerId)
        {
            this.pos_X_CP = pos_X_CP;
            this.pos_Y_CP = pos_Y_CP;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
            this.computerPlayerId = computerPlayerId;
        }

        public int Get_pos_X_CP()
        {
            return pos_X_CP;
        }

        public int Get_pos_Y_CP()
        {
            return pos_Y_CP;
        }

        public int Get_computerPlayerId()
        {
            return computerPlayerId;
        }

        public void DrawComputerPlayer(PaintEventArgs e, int computerPlayerId)
        {
            switch (computerPlayerId)
            {
                case 0:
                    e.Graphics.FillEllipse(brBlue, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
                case 2:
                    e.Graphics.FillEllipse(brRed, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
                case 3:
                    e.Graphics.FillEllipse(brGreen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
                case 4:
                    e.Graphics.FillEllipse(brYellow, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
                case 5:
                    e.Graphics.FillEllipse(brPurple, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
                case 6:
                    e.Graphics.FillEllipse(brChocolate, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    e.Graphics.DrawEllipse(pen, this.pos_X_CP, this.pos_Y_CP, this.fieldWidth, this.fieldLength);
                    break;
            }
        }
    }
}
