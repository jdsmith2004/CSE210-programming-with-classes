using System;
using System.Collections;

namespace tic_tac_toe
{
    class Program
    {
        static void PrintBoard(List<string> boardList, string currentPlayer) 
        {
            if (currentPlayer == "player")
            {
                Console.Write(boardList[0] +  " | " + boardList[1] + " | " + boardList[2]
                 + "\n" + boardList[3] + " | " + boardList[4] + " | " + boardList[5]
                 + "\n" + boardList[6] + " | " + boardList[7] + " | " + boardList[8] + "\n");
            }
        }   


        static string NextPlayer(string currentPlayer)
        {
            if (currentPlayer == "player")
            {
                currentPlayer = "computer";
            } else
            {
                currentPlayer = "player";
            }
            return currentPlayer;
        }
        static bool CheckWin(List<string> boardList, string currentPlayer)
        {
            bool isWinner = false;
            if ((boardList[0] == "x" && boardList[1] == "x" && boardList[2] == "x")
                || (boardList[3] == "x" && boardList[4] == "x" && boardList[5] == "x")
                || (boardList[6] == "x" && boardList[7] == "x" && boardList[8] == "x")
                || (boardList[0] == "x" && boardList[3] == "x" && boardList[6] == "x")
                || (boardList[1] == "x" && boardList[4] == "x" && boardList[7] == "x")
                || (boardList[2] == "x" && boardList[5] == "x" && boardList[8] == "x")
                || (boardList[0] == "x" && boardList[4] == "x" && boardList[8] == "x")
                || (boardList[2] == "x" && boardList[4] == "x" && boardList[6] == "x")
                )
            {
                isWinner = true;
            }
            return isWinner;
        }

        static int GetUserInput(string player)
        {
            int playerInput = 0;
            if (player == "player")
            {
                Console.Write($"{player}'s turn to choose a square (1-9): ");
                string moveString = Console.ReadLine();
                playerInput = int.Parse(moveString);
                playerInput = playerInput - 1;
            }
            return playerInput;
        }
        static List<string> AddInput(List<string> boardList, int playerInput, string currentPlayer)
        {
            if (currentPlayer == "player")
            {
                boardList[playerInput] = "x";
            }

            return boardList;
        }
        static List<string> ComputerPick(List<string> boardList, string currentUser)
        {
            Random rand = new Random();
            int randNumber = rand.Next(0,8);
            bool open = false;

            if (currentUser != "computer")
            {
                return boardList;
            }

            while(open != true)
            {
                if (boardList[randNumber] != "x")
                {
                    boardList[randNumber] = "o";
                    open = true;
                } else
                {
                    randNumber = rand.Next(0,8); 
                }
            }

            return boardList;
        }

        static bool CheckTie(List<string> boardList)
        {
            bool checkDigit = false;

            foreach (string value in boardList)
            {
                if (char.IsDigit(value[0]))
                {
                    checkDigit = true;
                    break;
                }
            }
            return !checkDigit;
        }
        static void Main(string[] args)
        {
            List<string> boardList = new List<string>();
            String currentPlayer = "player";
            bool checkWin = false;
            bool checkTie = false;
            int userInput;
            
            boardList.Add("1");
            boardList.Add("2");
            boardList.Add("3");
            boardList.Add("4");
            boardList.Add("5");
            boardList.Add("6");
            boardList.Add("7");
            boardList.Add("8");
            boardList.Add("9");
            
        while(!checkWin & !checkTie)
        {
            PrintBoard(boardList, currentPlayer);             
            userInput = GetUserInput(currentPlayer);
            ComputerPick(boardList, currentPlayer);
            AddInput(boardList, userInput, currentPlayer);
            currentPlayer = NextPlayer(currentPlayer);
            checkWin = CheckWin(boardList, currentPlayer);
            checkTie = CheckTie(boardList);
                       
        }
        currentPlayer = "player";
        PrintBoard(boardList, currentPlayer);
        Console.WriteLine("Good game. Thanks for playing!");
        }    
    }
}