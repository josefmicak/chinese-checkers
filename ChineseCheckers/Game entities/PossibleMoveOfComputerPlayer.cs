namespace ChineseCheckers.Game_entities
{
    class PossibleMoveOfComputerPlayer
    {
        private int pos_X_PM;
        private int pos_Y_PM;
        private int pos_X_PFPMCP;
        private int pos_Y_PFPMCP;
        private int computerPlayerId;

        public PossibleMoveOfComputerPlayer(int pos_X_PM, int pos_Y_PM, int pos_X_PFPMCP, int pos_Y_PFPMCP, int computerPlayerId)
        {
            this.pos_X_PM = pos_X_PM;
            this.pos_Y_PM = pos_Y_PM;
            this.pos_X_PFPMCP = pos_X_PFPMCP;
            this.pos_Y_PFPMCP = pos_Y_PFPMCP;
            this.computerPlayerId = computerPlayerId;
        }

        public int Get_pos_X_PM()
        {
            return pos_X_PM;
        }

        public int Get_pos_Y_PM()
        {
            return pos_Y_PM;
        }

        public int Get_pos_X_PFPMCP()
        {
            return pos_X_PFPMCP;
        }

        public int Get_pos_Y_PFPMCP()
        {
            return pos_Y_PFPMCP;
        }

        public int Get_computerPlayerId()
        {
            return computerPlayerId;
        }
    }
}
