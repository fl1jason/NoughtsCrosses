using System;
using System.Timers;
using AppKit;
using Foundation;
using NoughtsCrosses.Game;

namespace NoughtsCrosses
{
    public partial class ViewController : NSViewController
    {
        NoughtsCrosses.Game.GameController _game = new NoughtsCrosses.Game.GameController();
        public string PlayingAs = "-";
        private static System.Timers.Timer aTimer;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            // Initialise the base class
            base.ViewDidLoad();

            // Give the Game Controller access to the UI
            _game.UI = this;

            // Set up a new Game
            this.NewGame();
        }

        private void NewGame()
        {
            // Reset the Game Controller
            _game.NewGame();

            // Clear the playing Board
            this.ClearBoard();

            // Do any additional setup after loading the view.
            Random rnd = new Random();
            string[] side = { "O", "X" };

            // Generate random indexes for pet names.
            int nIndex = rnd.Next(side.Length);
            this.PlayingAs = side[nIndex];

            // Set Player 2 as playing for the other side
            int nPlayer2 = (nIndex == 0) ? 1 : 0;
            _game.ComputerPlayAs = side[nPlayer2];

            // Update the Status
            this.lblResult.StringValue = string.Format("You're playing as {0}, Mac is playing as {1}", this.PlayingAs, _game.ComputerPlayAs);
        }

        /// <summary>
        /// Sets the Text on the Button - i.e. Plays a O or an X
        /// </summary>
        /// <param name="nNumber"></param>
        /// <param name="strChar"></param>
        public void SetButton(int nNumber, string strChar)
        {
            switch (nNumber)
            { 
                case 1:
                    this.btn1.Title = strChar;
                    break;

                case 2:
                    this.btn2.Title = strChar;
                    break;

                case 3:
                    this.btn3.Title = strChar;
                    break;

                case 4:
                    this.btn4.Title = strChar;
                    break;

                case 5:
                    this.btn5.Title = strChar;
                    break;

                case 6:
                    this.btn6.Title = strChar;
                    break;

                case 7:
                    this.btn7.Title = strChar;
                    break;

                case 8:
                    this.btn8.Title = strChar;
                    break;

                case 9:
                    this.btn9.Title = strChar;
                    break;
            }
        }

        public void SetWinner(int nPlayerNumber)
        {
            string strMessage = string.Format("Player {0} is the Winner!", nPlayerNumber.ToString());
            Console.WriteLine(strMessage);

            this.lblResult.StringValue = strMessage;
            this.btnPlayAgain.Enabled = true;
        }

        public void SetNoWinner()
        {
            string strMessage = "No-one won!";
            Console.WriteLine(strMessage);

            this.lblResult.StringValue = strMessage;
            this.btnPlayAgain.Enabled = true;
        }

        /// <summary>
        /// Clears the board for a new game
        /// </summary>
        public void ClearBoard()
        {
            this.btn1.Title = " - ";
            this.btn2.Title = " - ";
            this.btn3.Title = " - ";
            this.btn4.Title = " - ";
            this.btn5.Title = " - ";
            this.btn6.Title = " - ";
            this.btn7.Title = " - ";
            this.btn8.Title = " - ";
            this.btn9.Title = " - ";
            this.lblResult.StringValue = "";
            this.btnPlayAgain.Enabled = false;

            this.btn1.State = NSCellStateValue.Off;
            this.btn2.State = NSCellStateValue.Off;
            this.btn3.State = NSCellStateValue.Off;
            this.btn4.State = NSCellStateValue.Off;
            this.btn5.State = NSCellStateValue.Off;
            this.btn6.State = NSCellStateValue.Off;
            this.btn7.State = NSCellStateValue.Off;
            this.btn8.State = NSCellStateValue.Off;
            this.btn9.State = NSCellStateValue.Off;

        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        partial void onBtn1_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(1, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn2_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(2, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn3_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(3, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn4_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(4, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn5_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(5, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn6_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(6, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn7_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(7, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn8_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(8, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onBtn9_Click(Foundation.NSObject sender)
        {
            _game.PlayerPlayMove(9, this.PlayingAs);
            _game.ComputerPlayMove();
        }

        partial void onPlayAgain_Click(Foundation.NSObject sender)
        {
            this.NewGame();
        }
    }
}
