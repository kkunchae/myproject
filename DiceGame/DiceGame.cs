using System;

namespace Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerDiceNum;
            int compDiceNum;

            int playerScore = 0;
            int compScore = 0;
            
            Random random = new Random();

            Console.WriteLine("Welcome to the Dice Game! Best out of 10 wins! Good luck!");

            //Game Loop
            for(int i = 0; (i < 10); i++)
            {
                Console.WriteLine("Press any key to roll the dice!");

                Console.ReadKey();

                //Returns a number between 1 and 6 for player and computer
                playerDiceNum = random.Next(1,7);
                Console.WriteLine("You rolled a " + playerDiceNum);

                //Waiting for suspends 
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("..");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(300);

                compDiceNum = random.Next(1,7);
                Console.WriteLine("Computer AI rolled a " + compDiceNum);

                //Determine the victor
                if( playerDiceNum > compDiceNum)
                {
                    playerScore++;
                    Console.WriteLine("You win!");
                }
                else if(playerDiceNum < compDiceNum)
                {
                    compScore++;
                    Console.WriteLine("The Computer AI wins!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }

                //Round winner
                Console.WriteLine("Player Score: " + playerScore);
                Console.WriteLine("Computer Score: "+ compScore);

                //If majority of the points has been won, the game is over
                if((playerScore == 6) ^ (compScore == 6))
                {
                    break;
                }
            }

            //Final game winner
            if(playerScore > compScore)
            {
                Console.WriteLine("Congratulations, you won the game!");
            }
            else if(playerScore < compScore)
            {
                Console.WriteLine("Better luck next time! Computer won the game.");
            }
            else
            {
                Console.WriteLine("Wow, the game is tied!");
            }
        }
    }
}