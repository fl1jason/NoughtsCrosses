using System;
using System.Collections;
using System.Timers;

namespace NoughtsCrosses.Game
{
    public class GameController
    {
        int[] _board = new int[10];
        int[] _possible_moves = new int[10];

        int _nPlayer1Moves = 0;
        int _nPlayer2Moves = 0;
        int _nPlayer1FirstMove = 0;

        public ViewController UI { get; set; } = null;

        public string ComputerPlayAs { get; set; } = "-";

        public GameController()
        {
            // Initialise as a new game
            this.NewGame();
        }

        public GameController(ViewController ui)
        {
            UI = ui;

            // Initialise as a new game
            this.NewGame();
        }
        
        /// <summary>
        /// Plays a move on behalf of the Player
        /// </summary>
        /// <param name="nNumber"></param>
        /// <param name="strPlayAs"></param>
        public void PlayerPlayMove(int nNumber, string strPlayAs)
        {
            _board[nNumber] = 1;
            UI.SetButton(nNumber, strPlayAs);

            // Increment the number of moves played
            _nPlayer1Moves++;

            // Is this our first move?
            if (_nPlayer1Moves == 1)
                _nPlayer1FirstMove = nNumber;

            // Did we win?
            if (this.CalculateWinner(1))
            {
                // Yay we won!
                UI.SetWinner(1);
            }
            else
            {
                if ((_nPlayer1Moves + _nPlayer2Moves) == 9)
                    UI.SetNoWinner();
            }
        }

        /// <summary>
        /// Plays a move on behalf of the computer
        /// </summary>
        public void ComputerPlayMove()
        {
            // Reset the Move logic as this is a new Move
            this.NewMove();

            // Play a Random First Move is this is a First move scenario
            bool bFirstMove = this.PlayRandomFirstMove();
            if (!bFirstMove)
            { 
                // Calulate the next Move
                int nNextMove = CalculateMove();

                // Play the next move
                _board[nNextMove] = 2;
                UI.SetButton(nNextMove, ComputerPlayAs);
                _nPlayer2Moves++;

                // Did we win?
                if (this.CalculateWinner(2))
                {
                    // Yay we won!
                    UI.SetWinner(2);
                }
                else
                {
                    if ((_nPlayer1Moves + _nPlayer2Moves) == 9)
                        UI.SetNoWinner();
                }
            }
        }

        /// <summary>
        /// Plays a Random Move on behalf of the computer when Player one has made the first move
        /// </summary>
        public bool PlayRandomFirstMove()
        {
            bool bFirstMove = false;

            // Has Player 1 made the first move?
            if (((_nPlayer1Moves == 1) && (_nPlayer2Moves == 0)) || (_nPlayer1Moves == 0) && (_nPlayer2Moves == 0))
            {
                // Pick a random number
                Random rnd = new Random();

                /// make sure it's not the position as Player 1 has just played!
                int nFirstMove = _nPlayer1FirstMove;
                while (nFirstMove == _nPlayer1FirstMove)
                    nFirstMove = rnd.Next(1, 9);

                // Make our first random move
                _board[nFirstMove] = 2;
                UI.SetButton(nFirstMove, ComputerPlayAs);

                bFirstMove = true;
            }
            return (bFirstMove);
        }

        /// <summary>
        /// Calculates the next move based on the other player's move
        /// </summary>
        /// <returns></returns>
        private int CalculateMove()
        {
            int nNextMove = 0;

            // Work out any risks, so cells where we need to play in order not to lose
            CalculateRisks();

            // Work out if there are any opportunities
            CalculateOpportunities();

            // Based on Opportunity, what' our next move?
            nNextMove = GetNextMove();

            // Pick off the first item
            return (nNextMove);
        }

        /// <summary>
        /// Works out if there are any Opportunities
        /// </summary>
        private void CalculateOpportunities()
        {
            this.CalculateRowOpportunity(1, 2, 3);
            this.CalculateRowOpportunity(4, 5, 6);
            this.CalculateRowOpportunity(7, 8, 9);
            this.CalculateRowOpportunity(1, 4, 7);
            this.CalculateRowOpportunity(2, 5, 8);
            this.CalculateRowOpportunity(3, 6, 9);
            this.CalculateRowOpportunity(7, 5, 3);
            this.CalculateRowOpportunity(9, 5, 1);

            return;
        }

        /// <summary>
        /// Loops through the possible moves to work out the most suitable
        /// </summary>
        /// <returns>returns the positions number</returns>
        private int GetNextMove()
        {
            int nNextMove = 0;
            for (int nPosition = 0; nPosition < _possible_moves.Length; nPosition++)
            {
                if (_possible_moves[nPosition] > 0)
                    nNextMove = nPosition;
            }
            return (nNextMove);
        }

        /// <summary>
        /// Works out if anyone has won
        /// </summary>
        /// <param name="nPlayerNumber"></param>
        /// <returns></returns>
        private bool CalculateWinner(int nPlayerNumber)
        {
            bool bIsWinner = false;

            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 1, 2, 3);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 4, 5, 6);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 7, 8, 9);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 1, 4, 7);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 2, 5, 8);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 3, 6, 9);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 7, 5, 3);
            bIsWinner |= this.CalculateRowWinner(nPlayerNumber, 9, 5, 1);

            return (bIsWinner);
        }

        private bool CalculateRowWinner(int nPlayerNumber, int n1, int n2, int n3)
        {
            string strRow = string.Format("{0}{1}{2}",
                _board[n1].ToString(),
                _board[n2].ToString(),
                _board[n3].ToString());

            string strPlayerWin = string.Format("{0}{0}{0}", nPlayerNumber.ToString());
            return (strPlayerWin == strRow);
        }

        /// <summary>
        /// Works out if there are any risks
        /// </summary>
        private void CalculateRisks()
        {
            this.CalculateRowRisk(1, 2, 3);
            this.CalculateRowRisk(4, 5, 6);
            this.CalculateRowRisk(7, 8, 9);
            this.CalculateRowRisk(1, 4, 7);
            this.CalculateRowRisk(2, 5, 8);
            this.CalculateRowRisk(3, 6, 9);            
            this.CalculateRowRisk(7, 5, 3);
            this.CalculateRowRisk(9, 5, 1);
        }

        /// <summary>
        /// Retrives a Row of moves and compares them to see if there's 2 or more of the opposing player, therefore a "Risk"
        /// </summary>
        /// <param name="n1">The first number in the row to retrieve data for</param>
        /// <param name="n2">The second number in the row to retrieve data for</param>
        /// <param name="n3">The third number in the row to retrieve data for</param>
        private void CalculateRowRisk(int n1, int n2, int n3)
        {
            string strRow = string.Format("{0}{1}{2}",
                _board[n1].ToString(),
                _board[n2].ToString(),
                _board[n3].ToString());

            if (strRow == "110")
            {
                _possible_moves[n3] = _possible_moves[n3] + 1;
            }
            if (strRow == "101")
            {
                _possible_moves[n2] = _possible_moves[n2] + 1;
            }
            if (strRow == "011")
            {
                _possible_moves[n1] = _possible_moves[n1] + 1;
            }
            return;
        }



        private void CalculateRowOpportunity(int n1, int n2, int n3)
        {
            string strRow = string.Format("{0}{1}{2}",
                _board[n1].ToString(),
                _board[n2].ToString(),
                _board[n3].ToString());

            if (strRow == "200")
            {
                _possible_moves[n2] = _possible_moves[n2] + 1;
            }
            if (strRow == "020")
            {
                _possible_moves[n1] = _possible_moves[n1] + 1;
            }
            if (strRow == "002")
            {
                _possible_moves[n2] = _possible_moves[n2] + 1;
            }
            return;
        }

        /// <summary>
        /// Resets game data and starts a new Game
        /// </summary>
        public void NewGame()
        {
            // Reset the Board
            for (int n = 0; n < _board.Length; n++)
                _board[n] = 0;

            // Reset the Playing Characeter
            this.ComputerPlayAs = "-";

            // Reset the number of moves made by players 1 and 2
            _nPlayer1Moves = 0;
            _nPlayer2Moves = 0;

            // Reset Player 1's First Move marker
            _nPlayer1FirstMove = 0;
        }

        /// <summary>
        /// Reset the Controller State before making a new Move
        /// </summary>
        public void NewMove()
        {
            // Reset the Board
            for (int n = 0; n < _possible_moves.Length; n++)
                _possible_moves[n] = 0;
        }
    }
}
