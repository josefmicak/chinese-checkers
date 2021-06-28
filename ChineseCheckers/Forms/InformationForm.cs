using System;
using System.Windows.Forms;

namespace ChineseCheckers.Forms
{
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();
            rulesTB.Text = "Pravidla a princip hry Čínská dáma:\r\n" +
    "Hra je pro 2 až 6 hráčů. Cílem hry je přemístit všechna svá pole do protilehlého cípu hvězdy. Hráč, který jako první přemístí všechna svá pole do protilehlého cípu hvězdy, vyhrává.\r\n" +
    "Ve hře je tedy rozhodující rychlost, s jakou je hráč schopen přemístit všechna svá pole. Existují dva typy pohybu - pohyb o jeden krok a pohyb skokem.\r\n" +
    "Hráč provede během jednoho tahu vždy jeden z těchto pohybů. Hráč při tahu hýbe vždy jedním polem. Pokud hráč provede pohyb o jeden krok, jeho tah je ukončen. Pokud provede pohyb skokem, může v tahu pokračovat.\r\n" +
    "Hráč může při pohybu skokem v tahu pokračovat v případě, že je pole na které chce skočit volné (nenachází se na něm pole některého hráče), že je délka skoku stejná jako u prvního skoku, a že hráč při skoku přeskočí pole některého z hráčů.\r\n" +
    "Při přeskoku není pole, přes které daný hráč skáče, ze hry vyřazeno. Hráč přeskakuje vždy nejbližší pole v daném směru.";

            rulesTB.Text = "The rules and principles of the game Chinese Checkers:\r\n" +
                "The game is played by 2 to 6 players. The purpose of the game is to move all player's marbles to the opposite corner of the star. The player who manages to do this first wins.\r\n" +
                "Because of this, the most important factor in the game is the speed at which the player's able to move all his marbles. There are two types of moves - move by a single step and move by jump.\r\n" +
                "The player executes one of these types of moves during each of his turns. The player always moves a single marble during one turn. If the player executes a move by a single step, his turn is over. If he performs a jump, he may continue moving his marble.\r\n" +
                "The player can continue moving his marble if the field he wants to jump into is empty (there isn't a marble of any other player located there), the length of the jump is equal to the length of the first jump, and he jumps over other marble during his jump.\r\n" +
                "If a marble is jumped over, it is not discarded. The player always jumps over the closest marble in given direction.";

            controlTB.Text = "Playing the game Chinese Checkers:\r\n" +
                "We begin the move by clicking the marble that we want to move during this turn." +
                "After clicking the given pole we are shown the possible moves from this field. During the turn we can display possible moves of an arbitary amount of fields, but after selecting a possible move we must finish the move with the marble that we had first moved.\r\n" +
                "We are going to be shown possible moves also from the fields on which we moved using a jump. The turn can be finished by either clicking on the field that we jumped on, or by clicking the 4th button in the control panel.";

            aboutTB.Text = "Information about this aplication:\r\n" +
                "The application has been created as a part of the Čínská dáma bachelor thesis, which has been successfully defended on the Faculty of Electrical Engineering and Computer Science at VSB - Technical University of Ostrava in the academic year 2020/2021.\r\n" +
                "Student: Josef Micak / MIC0378\r\n" +
                "Contact: josef.micak.st@vsb.cz";

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
