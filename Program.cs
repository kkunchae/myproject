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
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Press any key to roll the dice!");

                Console.ReadKey();

                //Returns a number between 1 and 6
                playerDiceNum = random.Next(1,7);
                Console.WriteLine("You rolled a " + playerDiceNum);

                compDiceNum = random.Next(1,7);
                Console.WriteLine("Computer AI rolled a " + compDiceNum);

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
            }
        }
    }
}