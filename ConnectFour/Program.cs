using System;

//Author:Qian Wang
//student#:991432584
namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] arr = startGame();
            string color = "Red";
            bool end = false;
            Console.Write("Drop a " + color + " disk at column (0-6): ");
            while (end == false)
            {
                try
                {
                    string disk = (color == "Red") ? "R" : "Y";
                    int row = 5;
                    int column = Convert.ToInt32(Console.ReadLine());
                    if (column < 0 || column > 6)
                        throw new Exception("Please enter a number between 0 and 6");

                    //choose the first blank row at that column
                    while (arr[row, column] != " ")
                    {
                        row--;
                        if (row < 0)
                            throw new Exception("This column is full, please choose another column");
                    }

                    arr = dropDisk(arr, row, column, disk);

                    //check the same-colored disks in a row
                    end = checkRow(arr, row, disk);
                    if (end == true)
                    {
                        Console.WriteLine("The " + color + " player win");
                        break;
                    }

                    //check the same-colored disks in a column;
                    end = checkColumn(arr, column, disk);
                    if (end == true)
                    {
                        Console.WriteLine("The " + color + " player win");
                        break;
                    }

                    //check the same-colored disks in a diagonal;
                    end = checkDiagonal(arr, row, column, disk);
                    if (end == true)
                    {
                        Console.WriteLine("The " + color + " player win");
                        break;
                    }

                    //check wether the board is full
                    end = checkDraw(arr);
                    if (end == true)
                    {
                        Console.WriteLine("The game ended in draw");
                        break;
                    }
                    color = (color == "Red") ? "Yellow" : "Red";

                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 0 and 6");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                Console.Write("Drop a " + color + " disk at column (0-6): ");



            }
            Console.ReadLine();
        }


        public static string[,] startGame()
        {
            string[,] arr = new string[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = " ";
                }

            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("|");
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("---------------");
            return arr;
        }

        //drop the disk on the board
        public static string[,] dropDisk(string[,] arr, int row, int column, string disk)
        {
            arr[row, column] = disk;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("|");
                    if (row == i && column == j)

                        Console.Write(arr[row, column]);

                    else
                    {
                        if (j < 7)
                            Console.Write(arr[i, j]);
                        else
                            Console.Write("");
                    }

                }
                Console.WriteLine();

            }
            Console.WriteLine("---------------");
            return arr;
        }


        //check the same-colored disks in a row;
        public static bool checkRow(string[,] arr, int row, string disk)
        {
            int counter = 0;
            for (int i = 0; i < 7; i++)
            {
                if (arr[row, i] == disk)
                {
                    counter++;
                    if (counter == 4)
                        break;
                }

                else
                    counter = 0;
            }

            if (counter == 4)
                return true;
            else
                return false;

        }

        //check the same-colored disks in a column;
        public static bool checkColumn(string[,] arr, int column, string disk)
        {
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {

                if (arr[i, column] == disk)
                {
                    counter++;
                    if (counter == 4)
                        break;
                }

                else
                    counter = 0;
            }

            if (counter == 4)
                return true;
            else
                return false;
        }

        //check the same-colored disks in a diagonal;
        public static bool checkDiagonal(string[,] arr, int row, int column, string disk)
        {
            int counter = 0;
            int rowTemp = row;
            int colTemp = column;
            while (row <= 5 && column >= 0)
            {
                if (arr[row, column] == disk)
                {
                    counter++;
                    row++;
                    column--;
                }

                else
                    break;

            }
            row = rowTemp;
            row--;
            column = colTemp;
            column++;
            while (row >= 0 && column <= 6)
            {
                if (arr[row, column] == disk)
                {
                    counter++;
                    row--;
                    column++;
                }

                else
                    break;

            }
            if (counter == 4)
                return true;
            else
            {
                int count = 0;
                row = rowTemp;

                column = colTemp;

                while (row >= 0 && column >= 0)
                {
                    if (arr[row, column] == disk)
                    {
                        count++;
                        row--;
                        column--;
                    }

                    else


                        break;


                }
                row = rowTemp;
                row++;
                column = colTemp;
                column++;
                while (row <= 5 && column <= 6)
                {
                    if (arr[row, column] == disk)
                    {
                        count++;
                        row++;
                        column++;

                    }

                    else
                        break;

                }
                if (count == 4)
                    return true;
                else
                    return false;

            }
        }

        //check wether the board is full 
        public static bool checkDraw(string[,] arr)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (arr[i, j] == " ")
                        return false;
                }

            }
            return true;
        }
    }
}
