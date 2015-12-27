using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Service
{
    public class GameBoardService
    {
        public GameBoardPosition[,] GenerateBoard(int numberOfMines, int boardHeight, int boardWidth)
        {
            var mines = new org.random.JSONRPC.RandomJSONRPC("d2319b89-8389-4d24-b1eb-4dbd80009153").GenerateIntegers(numberOfMines, 1, boardHeight * boardWidth, false);
            var gameBoard = new GameBoardPosition[boardHeight, boardWidth];

            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    gameBoard[y, x] = new GameBoardPosition() {};
                }
            }

            foreach (var mine in mines)
            {
                var xy = GetXY(mine, boardHeight);
                gameBoard[xy.Item1, xy.Item2].HasMine = true;
            }
            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardWidth; x++)
                {

                    gameBoard[y, x].PositionY = y;
                    gameBoard[y, x].PositionX = x;
                    gameBoard[y, x].NumberOfSurroundingMines = NumberOfSurroundingMines(gameBoard, boardHeight, boardWidth, x, y);
                }
            }
            return gameBoard;
        }

        private Tuple<int, int> GetXY(int value, int height)
        {
            var y = (int)Math.Ceiling((double)value / (double)height);
            var x = (value % height);
            return new Tuple<int, int>(x > 0 ? x : (height - 1), y - 1);
        }

        private int NumberOfSurroundingMines(GameBoardPosition[,] gameBoard, int boardHeight, int boardWidth, int checkX, int checkY)
        {
            if (gameBoard[checkY, checkX].HasMine)
            {
                return 0;
            }
            var countOfMines = 0;
            var a = checkX--;
            var b = checkY--;
            for (var y = checkY; y < checkY + 3; y++)
            {
                for (var x = checkX; x < checkX + 3; x++)
                {
                    if (x >= 0 && y >= 0 && x < boardWidth && y < boardHeight && !(x == a && y == b))
                    {
                        if (gameBoard[y, x].HasMine)
                        {
                            countOfMines++;
                        }
                    }
                }
            }
            return countOfMines;
        }
    }
}