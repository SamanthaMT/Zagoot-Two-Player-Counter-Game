using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;




namespace Game_Project
{

    public partial class Form1 : Form
    {
//Initialising variables
//Human player moving

        Boolean turn = true;
        Boolean move = false;

        String counter = "none";
        Boolean round = false;

        int spaceRow;
        int spaceCol;
        int locRow;
        int locCol;

        int moveRow;
        int moveCol;

        int redMove_value;
        int redMove_row;
        int redMove_col;

//Human player seizing
        String seizeCounter = "none";

        int redRow;
        int redCol;

        int blueCounterCount = 12;
        int redCounterCount = 12;

        //AI METHOD

        int[] rndm_select = new int[3] { 1, 2, 3 };
        Random rndm = new Random();
        int rndm_number;

        int new_row;
        int new_col;
        String redCounter_name;

        //AI MIN-MAX

        Boolean seize_blue = false;
        String seizeBlue_name = "none";

        Boolean seizeBlue_max = false;
        String blueName_max = "none";

        int blueCounter_row;
        int blueCounter_col;
        int redCounter_row;
        int redCounter_col;

        int current_value;
        int potential_value;
        int min_value;
        int max_value;

        //HUMAN PLAYER MOVING

        Boolean moveCounter()
        {
            if (round == false)
            {
                _ = humanChecks_square();
            }
            else
            {
                _ = humanChecks_round();
            }

            if (move == true)
            {
                Control counterName = this.Controls[counter];
                counterName.Location = new System.Drawing.Point(moveRow, moveCol);

                turn = false;

                _ = ai();
            }
            counter = "none";
            return turn;
        }

        Boolean humanChecks_square()
        {
            if (counter != "none")
            {
                if (spaceCol > locCol && spaceCol < locCol + 10)
                {
                    //checks left
                    if (spaceRow + 35 < locRow && spaceRow + 45 > locRow)
                    {
                        move = true;
                        moveRow = locRow - 48;
                        moveCol = locCol;

                    }
                    //checks right
                    else if (locRow + 50 < spaceRow && locRow + 60 > spaceRow)
                    {
                        move = true;
                        moveRow = locRow + 48;
                        moveCol = locCol;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else if (spaceRow > locRow && spaceRow < locRow + 10)
                {
                    //check down
                    if (locCol + 50 < spaceCol && locCol + 60 > spaceCol)
                    {
                        move = true;
                        moveRow = locRow;
                        moveCol = locCol + 48;
                    }
                    //checks up
                    else if (spaceCol + 35 < locCol && spaceCol + 45 > locCol)
                    {
                        move = true;
                        moveRow = locRow;
                        moveCol = locCol - 48;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else
                {
                    move = false;
                }
            }
            else
            {
                move = false;
            }
            return move;
        }

        Boolean humanChecks_round()
        {
            if (counter != "none")
            {
                if (spaceCol + 35 < locCol && spaceCol + 45 > locCol)
                {
                    //checks upper left
                    if (spaceRow + 35 < locRow && spaceRow + 45 > locRow)
                    {
                        move = true;
                        moveRow = locRow - 48;
                        moveCol = locCol - 48;

                    }
                    //checks upper right
                    else if (locRow + 50 < spaceRow && locRow + 60 > spaceRow)
                    {
                        move = true;
                        moveRow = locRow + 48;
                        moveCol = locCol - 48;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else if (locCol + 50 < spaceCol && locCol + 60 > spaceCol)
                {
                    //checks lower left
                    if (spaceRow + 35 < locRow && spaceRow + 45 > locRow)
                    {
                        move = true;
                        moveRow = locRow - 48;
                        moveCol = locCol + 48;

                    }
                    //checks lower right
                    else if (locRow + 50 < spaceRow && locRow + 60 > spaceRow)
                    {
                        move = true;
                        moveRow = locRow + 48;
                        moveCol = locCol + 48;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else
                {
                    move = false;
                }
            }
            else
            {
                move = false;
            }
            return move;
        }

        //HUMAN PLAYER SEIZING        

        Boolean seizeRed()
        {
            if (round == false)
            {
                _ = squareSeize();
            }
            else
            {
                _ = roundSeize();
            }

            if (move == true)
            {
                Control counterName = this.Controls[counter];
                counterName.Location = new System.Drawing.Point(redRow, redCol);

                Control seizeCounterName = this.Controls[seizeCounter];
                seizeCounterName.Location = new System.Drawing.Point(11, 297);

                redCounterCount--;

                turn = false;

                _ = redCount_display();

                if (redCounterCount == 0)
                {
                    this.congratulations.Size = new System.Drawing.Size(670, 320);
                }
                else
                {
                    _ = ai();
                }
            }
            counter = "none";
            return turn;
        }

        Boolean squareSeize()
        {
            if (counter != "none")
            {
                if (redCol == locCol)
                {
                    //checks left
                    if (redRow + 48 == locRow)
                    {
                        move = true;

                    }
                    //checks right
                    else if (locRow + 48 == redRow)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else if (redRow == locRow)
                {
                    //checks up
                    if (redCol + 48 == locCol)
                    {
                        move = true;
                    }
                    //checks down
                    else if (locCol + 48 == redCol)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else
                {
                    move = false;
                }
            }
            else
            {
                Console.WriteLine("Please select a counter first");
                move = false;
            }
            return move;
        }

        Boolean roundSeize()
        {
            if (counter != "none")
            {
                if (locCol + 48 == redCol)
                {
                    //checks lower left
                    if (redRow + 48 == locRow)
                    {
                        move = true;

                    }
                    //checks lower right
                    else if (locRow + 48 == redRow)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else if (redCol + 48 == locCol)
                {
                    //checks upper left
                    if (redRow + 48 == locRow)
                    {
                        move = true;

                    }
                    //checks upper right
                    else if (locRow + 48 == redRow)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                }
                else
                {
                    move = false;
                }
            }
            else
            {
                Console.WriteLine("Please select a counter first");
                move = false;
            }
            return move;
        }

//AI METHOD

        int ai()
        {
            redMove_value = -100;

            redSquare_max(redSquare1);

        //Check if new max value is greater than current max value
            if (redMove_value < max_value)
            {
                //update red counter information to move
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare1";
            }
        //Check if new max value is equal to current max value
            else if (redMove_value == max_value)
            {
                //Randomly decide whether to update counter information
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare1";
                }
            }
            redSquare_max(redSquare2);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare2";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare2";
                }
            }
            redSquare_max(redSquare3);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare3";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare3";
                }
            }
            redSquare_max(redSquare4);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare4";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare4";
                }
            }
            redSquare_max(redSquare5);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare5";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare5";
                }
            }
            redSquare_max(redSquare6);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redSquare6";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redSquare6";
                }
            }
            redRound_max(redRound1);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound1";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound1";
                }
            }
            redRound_max(redRound2);
            if (redMove_value < max_value)
            { 
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound2";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound2";
                }
            }
            redRound_max(redRound3);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound3";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound3";
                }
            }
            redRound_max(redRound4);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound4";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound4";
                }
            }
            redRound_max(redRound5);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound5";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound5";
                }
            }
            redRound_max(redRound6);
            if (redMove_value < max_value)
            {
                redMove_value = max_value;
                redMove_row = new_row;
                redMove_col = new_col;
                redCounter_name = "redRound6";
            }
            else if (redMove_value == max_value)
            {
                rndm_number = rndm.Next(rndm_select.Length);
                if (rndm_number == 2)
                {
                    redMove_value = max_value;
                    redMove_row = new_row;
                    redMove_col = new_col;
                    redCounter_name = "redRound6";
                }
            }

            Control redCounter_move = this.Controls[redCounter_name];
            redCounter_move.Location = new System.Drawing.Point(redMove_row, redMove_col);

            _ = seizedBlue_removal();
            _ = blueCount_display();

            if (blueCounterCount == 0)
            {
                this.gameOver.Size = new System.Drawing.Size(670, 320);
            }
            else
            {
                turn = true;
            }
            return 0;
        }

//AI MIN-MAX

        
        int redSquare_max(Button redCounter)
        {
            max_value = -100;
            //check counter is still in play
            if (redCounter.Location.X != 11) {

                //check up
                redCounter_row = redCounter.Location.X;
                if (redCounter.Location.Y - 48 >= 17)
                {
                    redCounter_col = redCounter.Location.Y - 48;
                    depth_1();
                    blueMove_min();
                    max_value_method();
                }

                //check down
                redCounter_row = redCounter.Location.X;
                if (redCounter.Location.Y + 48 <= 401)
                {
                    redCounter_col = redCounter.Location.Y + 48;
                    depth_1();
                    blueMove_min();
                    max_value_method();
                }

                //check left
                redCounter_col = redCounter.Location.Y;
                if (redCounter.Location.X - 48 >= 193)
                {
                    redCounter_row = redCounter.Location.X - 48;
                    depth_1();
                    blueMove_min();
                    max_value_method();
                }

                //check right
                redCounter_col = redCounter.Location.Y;
                if (redCounter.Location.X + 48 <= 577)
                {
                    redCounter_row = redCounter.Location.X + 48;
                    depth_1();
                    blueMove_min();
                    max_value_method();
                }
            }

            return max_value;
        }

        int redRound_max(Button redCounter)
        {
            max_value = -100;

            if (redCounter.Location.X != 11) {

                //check upper left
                if (redCounter.Location.X - 48 >= 193)
                {
                    redCounter_row = redCounter.Location.X - 48;
                    if (redCounter.Location.Y - 48 >= 17)
                    {
                        redCounter_col = redCounter.Location.Y - 48;
                        depth_1();
                        blueMove_min();
                        max_value_method();
                    }
                }

                //check upper right
                if (redCounter.Location.X + 48 <= 577)
                {
                    redCounter_row = redCounter.Location.X + 48;
                    if (redCounter.Location.Y - 48 >= 17)
                    {
                        redCounter_col = redCounter.Location.Y - 48;
                        depth_1();
                        blueMove_min();
                        max_value_method();
                    }
                }

                //check lower left
                if (redCounter.Location.X - 48 >= 193)
                {
                    redCounter_row = redCounter.Location.X - 48;
                    if (redCounter.Location.Y + 48 <= 401)
                    {
                        redCounter_col = redCounter.Location.Y + 48;
                        depth_1();
                        blueMove_min();
                        max_value_method();
                    }
                }

                //check lower right
                if (redCounter.Location.X + 48 <= 577)
                {
                    redCounter_row = redCounter.Location.X + 48;
                    if (redCounter.Location.Y + 48 <= 401)
                    {
                        redCounter_col = redCounter.Location.Y + 48;
                        depth_1();
                        blueMove_min();
                        max_value_method();
                    }
                }
            }

            return max_value;
        }

        //method to check counter colour of space red wants to move to
        int depth_1()
        {
            //red counters
            if ((redCounter_row == redSquare1.Location.X && redCounter_col == redSquare2.Location.Y)
                || (redCounter_row == redSquare2.Location.X && redCounter_col == redSquare2.Location.Y)
                || (redCounter_row == redSquare3.Location.X && redCounter_col == redSquare3.Location.Y)
                || (redCounter_row == redSquare4.Location.X && redCounter_col == redSquare4.Location.Y)
                || (redCounter_row == redSquare5.Location.X && redCounter_col == redSquare5.Location.Y)
                || (redCounter_row == redSquare6.Location.X && redCounter_col == redSquare6.Location.Y)
                || (redCounter_row == redRound1.Location.X && redCounter_col == redRound1.Location.Y)
                || (redCounter_row == redRound2.Location.X && redCounter_col == redRound2.Location.Y)
                || (redCounter_row == redRound3.Location.X && redCounter_col == redRound3.Location.Y)
                || (redCounter_row == redRound4.Location.X && redCounter_col == redRound4.Location.Y)
                || (redCounter_row == redRound5.Location.X && redCounter_col == redRound5.Location.Y)
                || (redCounter_row == redRound6.Location.X && redCounter_col == redRound6.Location.Y))
            {
                current_value = -100;
            }
            //blue counters
            else if ((redCounter_row == blueSquare1.Location.X && redCounter_col == blueSquare1.Location.Y)
                || (redCounter_row == blueSquare2.Location.X && redCounter_col == blueSquare2.Location.Y)
                || (redCounter_row == blueSquare3.Location.X && redCounter_col == blueSquare3.Location.Y)
                || (redCounter_row == blueSquare4.Location.X && redCounter_col == blueSquare4.Location.Y)
                || (redCounter_row == blueSquare5.Location.X && redCounter_col == blueSquare5.Location.Y)
                || (redCounter_row == blueSquare6.Location.X && redCounter_col == blueSquare6.Location.Y)
                || (redCounter_row == blueRound1.Location.X && redCounter_col == blueRound1.Location.Y)
                || (redCounter_row == blueRound2.Location.X && redCounter_col == blueRound2.Location.Y)
                || (redCounter_row == blueRound3.Location.X && redCounter_col == blueRound3.Location.Y)
                || (redCounter_row == blueRound4.Location.X && redCounter_col == blueRound4.Location.Y)
                || (redCounter_row == blueRound5.Location.X && redCounter_col == blueRound5.Location.Y)
                || (redCounter_row == blueRound6.Location.X && redCounter_col == blueRound6.Location.Y))
            {
                current_value = 5;
            }
            //empty space
            else
            {
                current_value = 0;
            }

            return current_value;
        }

        int blueMove_min ()
        {
            int[] potentialValues_array = new int[12] 
            { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

            potentialValues_array [0] = square_depth_2(blueSquare1);
            potentialValues_array [1] = square_depth_2(blueSquare2);
            potentialValues_array [2] = square_depth_2(blueSquare3);
            potentialValues_array [3] = square_depth_2(blueSquare4);
            potentialValues_array [4] = square_depth_2(blueSquare5);
            potentialValues_array [5] = square_depth_2(blueSquare6);
            potentialValues_array [6] = round_depth_2(blueRound1);
            potentialValues_array [7] = round_depth_2(blueRound2);
            potentialValues_array [8] = round_depth_2(blueRound3);
            potentialValues_array [9] = round_depth_2(blueRound4);
            potentialValues_array [10] = round_depth_2(blueRound5);
            potentialValues_array [11] = round_depth_2(blueRound6);

            min_value = potentialValues_array.Min();

            return min_value;
        }

        //calculates value for each blue counter
        //depends on whether they are in a position to seize
        // -5 means they can seize
        int square_depth_2(Button blueCounter)
        {
            blueCounter_row = blueCounter.Location.X;
            blueCounter_col = blueCounter.Location.Y;

            potential_value = 0;

            //check if counter is not in play
            if (blueCounter_row == 11)
            {
                potential_value = 100;
            }
            else if (redCounter_col == blueCounter_col)
            {
                //checks left
                if (redCounter_row + 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
                //checks right
                else if (redCounter_row - 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
            }
            else if (redCounter_row == blueCounter_row)
            {
                //checks up
                if (redCounter_col + 48 == blueCounter_col )
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
                //checks down
                else if (redCounter_col - 48 == blueCounter_col)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
            }
            return potential_value;
        }

        int round_depth_2 (Button blueCounter)
        {
            blueCounter_row = blueCounter.Location.X;
            blueCounter_col = blueCounter.Location.Y;

            potential_value = 0;

            //check if counter is not in play
            if (blueCounter_row == 11)
            {
                potential_value = 100;
            }
            else if (blueCounter_col + 48 == redCounter_col)
            {
                //checks lower left
                if (redCounter_row + 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
                //checks lower right
                else if (redCounter_row - 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
            }
            else if (redCounter_col + 48 == blueCounter_col)
            {
                //checks upper left
                if (redCounter_row + 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }

                }
                //checks upper right
                else if (redCounter_row - 48 == blueCounter_row)
                {
                    if (potential_value > -5)
                    {
                        potential_value = -5;
                    }
                }
            }
            return potential_value;
        }

        //adds together scores found in first and second method
        //find overall maximum score for this counter
        int max_value_method()
        {
            if (min_value + current_value >= max_value)
            {
                max_value = min_value + current_value;
                new_row = redCounter_row;
                new_col = redCounter_col;

                seizeBlue_max = seize_blue;
                blueName_max = seizeBlue_name;
            }
            return max_value;
        }

//AI SEIZING

        int seizedBlue_removal()
        {
            if (redMove_row == blueSquare1.Location.X && redMove_col == blueSquare1.Location.Y)
            {
                blueSquare1.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueSquare2.Location.X && redMove_col == blueSquare2.Location.Y)
            {
                blueSquare2.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueSquare3.Location.X && redMove_col == blueSquare3.Location.Y)
            {
                blueSquare3.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueSquare4.Location.X && redMove_col == blueSquare4.Location.Y)
            {
                blueSquare4.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueSquare5.Location.X && redMove_col == blueSquare5.Location.Y)
            {
                blueSquare5.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueSquare6.Location.X && redMove_col == blueSquare6.Location.Y)
            {
                blueSquare6.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound1.Location.X && redMove_col == blueRound1.Location.Y)
            {
                blueRound1.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound2.Location.X && redMove_col == blueRound2.Location.Y)
            {
                blueRound2.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound3.Location.X && redMove_col == blueRound3.Location.Y)
            {
                blueRound3.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound4.Location.X && redMove_col == blueRound4.Location.Y)
            {
                blueRound4.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound5.Location.X && redMove_col == blueRound5.Location.Y)
            {
                blueRound5.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            if (redMove_row == blueRound6.Location.X && redMove_col == blueRound6.Location.Y)
            {
                blueRound6.Location = new System.Drawing.Point(11, 123);
                blueCounterCount--;
            }
            return blueCounterCount;
        }

//DISPLAY

        int blueCount_display()
        {
            if (blueCounterCount == 11)
            {
                this.red1.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 10)
            {
                this.red2.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 9)
            {
                this.red3.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 8)
            {
                this.red4.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 7)
            {
                this.red5.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 6)
            {
                this.red6.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 5)
            {
                this.red7.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 4)
            {
                this.red8.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 3)
            {
                this.red9.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 2)
            {
                this.red10.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 1)
            {
                this.red11.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (blueCounterCount == 0)
            {
                this.red12.Font = new System.Drawing.Font("Calibri", 18F);
            }
            return 0;
        }

        int redCount_display()
        {
            if (redCounterCount == 11)
            {
                this.blue1.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 10)
            {
                this.blue2.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 9)
            {
                this.blue3.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 8)
            {
                this.blue4.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 7)
            {
                this.blue5.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 6)
            {
                this.blue6.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 5)
            {
                this.blue7.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 4)
            {
                this.blue8.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 3)
            {
                this.blue9.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 2)
            {
                this.blue10.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 1)
            {
                this.blue11.Font = new System.Drawing.Font("Calibri", 18F);
            }
            else if (redCounterCount == 0)
            {
                this.blue12.Font = new System.Drawing.Font("Calibri", 18F);
            }
            return 0;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void space11_Click(object sender, EventArgs e)
        {
            spaceRow = space11.Location.X;
            spaceCol = space11.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space12_Click(object sender, EventArgs e)
        {
            spaceRow = space12.Location.X;
            spaceCol = space12.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space13_Click(object sender, EventArgs e)
        {
            spaceRow = space13.Location.X;
            spaceCol = space13.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space14_Click(object sender, EventArgs e)
        {
            spaceRow = space14.Location.X;
            spaceCol = space14.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space15_Click(object sender, EventArgs e)
        {
            spaceRow = space15.Location.X;
            spaceCol = space15.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space16_Click(object sender, EventArgs e)
        {
            spaceRow = space16.Location.X;
            spaceCol = space16.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space17_Click(object sender, EventArgs e)
        {
            spaceRow = space17.Location.X;
            spaceCol = space17.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space18_Click(object sender, EventArgs e)
        {
            spaceRow = space18.Location.X;
            spaceCol = space18.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space19_Click(object sender, EventArgs e)
        {
            spaceRow = space19.Location.X;
            spaceCol = space19.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space21_Click(object sender, EventArgs e)
        {
            spaceRow = space21.Location.X;
            spaceCol = space21.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space22_Click(object sender, EventArgs e)
        {
            spaceRow = space22.Location.X;
            spaceCol = space22.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space23_Click(object sender, EventArgs e)
        {
            spaceRow = space23.Location.X;
            spaceCol = space23.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space24_Click(object sender, EventArgs e)
        {
            spaceRow = space24.Location.X;
            spaceCol = space24.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space25_Click(object sender, EventArgs e)
        {
            spaceRow = space25.Location.X;
            spaceCol = space25.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space26_Click(object sender, EventArgs e)
        {
            spaceRow = space26.Location.X;
            spaceCol = space26.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space27_Click(object sender, EventArgs e)
        {
            spaceRow = space27.Location.X;
            spaceCol = space27.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space28_Click(object sender, EventArgs e)
        {
            spaceRow = space28.Location.X;
            spaceCol = space28.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space29_Click(object sender, EventArgs e)
        {
            spaceRow = space29.Location.X;
            spaceCol = space29.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space31_Click(object sender, EventArgs e)
        {
            spaceRow = space31.Location.X;
            spaceCol = space31.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space32_Click(object sender, EventArgs e)
        {
            spaceRow = space32.Location.X;
            spaceCol = space32.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space33_Click(object sender, EventArgs e)
        {
            spaceRow = space33.Location.X;
            spaceCol = space33.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space34_Click(object sender, EventArgs e)
        {
            spaceRow = space34.Location.X;
            spaceCol = space34.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space35_Click(object sender, EventArgs e)
        {
            spaceRow = space35.Location.X;
            spaceCol = space35.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space36_Click(object sender, EventArgs e)
        {
            spaceRow = space36.Location.X;
            spaceCol = space36.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space37_Click(object sender, EventArgs e)
        {
            spaceRow = space37.Location.X;
            spaceCol = space37.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space38_Click(object sender, EventArgs e)
        {
            spaceRow = space38.Location.X;
            spaceCol = space38.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space39_Click(object sender, EventArgs e)
        {
            spaceRow = space39.Location.X;
            spaceCol = space39.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space41_Click(object sender, EventArgs e)
        {
            spaceRow = space41.Location.X;
            spaceCol = space41.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space42_Click(object sender, EventArgs e)
        {
            spaceRow = space42.Location.X;
            spaceCol = space42.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space43_Click(object sender, EventArgs e)
        {
            spaceRow = space43.Location.X;
            spaceCol = space43.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space44_Click(object sender, EventArgs e)
        {
            spaceRow = space44.Location.X;
            spaceCol = space44.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space45_Click(object sender, EventArgs e)
        {
            spaceRow = space45.Location.X;
            spaceCol = space45.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space46_Click(object sender, EventArgs e)
        {
            spaceRow = space46.Location.X;
            spaceCol = space46.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space47_Click(object sender, EventArgs e)
        {
            spaceRow = space47.Location.X;
            spaceCol = space47.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space48_Click(object sender, EventArgs e)
        {
            spaceRow = space48.Location.X;
            spaceCol = space48.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space49_Click(object sender, EventArgs e)
        {
            spaceRow = space49.Location.X;
            spaceCol = space49.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space51_Click(object sender, EventArgs e)
        {
            spaceRow = space51.Location.X;
            spaceCol = space51.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space52_Click(object sender, EventArgs e)
        {
            spaceRow = space52.Location.X;
            spaceCol = space52.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space53_Click(object sender, EventArgs e)
        {
            spaceRow = space53.Location.X;
            spaceCol = space53.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space54_Click(object sender, EventArgs e)
        {
            spaceRow = space54.Location.X;
            spaceCol = space54.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space55_Click(object sender, EventArgs e)
        {
            spaceRow = space55.Location.X;
            spaceCol = space55.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space56_Click(object sender, EventArgs e)
        {
            spaceRow = space56.Location.X;
            spaceCol = space56.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space57_Click(object sender, EventArgs e)
        {
            spaceRow = space57.Location.X;
            spaceCol = space57.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space58_Click(object sender, EventArgs e)
        {
            spaceRow = space58.Location.X;
            spaceCol = space58.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space59_Click(object sender, EventArgs e)
        {
            spaceRow = space59.Location.X;
            spaceCol = space59.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space61_Click(object sender, EventArgs e)
        {
            spaceRow = space61.Location.X;
            spaceCol = space61.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space62_Click(object sender, EventArgs e)
        {
            spaceRow = space62.Location.X;
            spaceCol = space62.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space63_Click(object sender, EventArgs e)
        {
            spaceRow = space63.Location.X;
            spaceCol = space63.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space64_Click(object sender, EventArgs e)
        {
            spaceRow = space64.Location.X;
            spaceCol = space64.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space65_Click(object sender, EventArgs e)
        {
            spaceRow = space65.Location.X;
            spaceCol = space65.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space66_Click(object sender, EventArgs e)
        {
            spaceRow = space66.Location.X;
            spaceCol = space66.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space67_Click(object sender, EventArgs e)
        {
            spaceRow = space67.Location.X;
            spaceCol = space67.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space68_Click(object sender, EventArgs e)
        {
            spaceRow = space68.Location.X;
            spaceCol = space68.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space69_Click(object sender, EventArgs e)
        {
            spaceRow = space69.Location.X;
            spaceCol = space69.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space71_Click(object sender, EventArgs e)
        {
            spaceRow = space71.Location.X;
            spaceCol = space71.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space72_Click(object sender, EventArgs e)
        {
            spaceRow = space72.Location.X;
            spaceCol = space72.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space73_Click(object sender, EventArgs e)
        {
            spaceRow = space73.Location.X;
            spaceCol = space73.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space74_Click(object sender, EventArgs e)
        {
            spaceRow = space74.Location.X;
            spaceCol = space74.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space75_Click(object sender, EventArgs e)
        {
            spaceRow = space75.Location.X;
            spaceCol = space75.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space76_Click(object sender, EventArgs e)
        {
            spaceRow = space76.Location.X;
            spaceCol = space76.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space77_Click(object sender, EventArgs e)
        {
            spaceRow = space77.Location.X;
            spaceCol = space77.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space78_Click(object sender, EventArgs e)
        {
            spaceRow = space78.Location.X;
            spaceCol = space78.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space79_Click(object sender, EventArgs e)
        {
            spaceRow = space79.Location.X;
            spaceCol = space79.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space81_Click(object sender, EventArgs e)
        {
            spaceRow = space81.Location.X;
            spaceCol = space81.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space82_Click(object sender, EventArgs e)
        {
            spaceRow = space82.Location.X;
            spaceCol = space82.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space83_Click(object sender, EventArgs e)
        {
            spaceRow = space83.Location.X;
            spaceCol = space83.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space84_Click(object sender, EventArgs e)
        {
            spaceRow = space84.Location.X;
            spaceCol = space84.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space85_Click(object sender, EventArgs e)
        {
            spaceRow = space85.Location.X;
            spaceCol = space85.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space86_Click(object sender, EventArgs e)
        {
            spaceRow = space86.Location.X;
            spaceCol = space86.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space87_Click(object sender, EventArgs e)
        {
            spaceRow = space87.Location.X;
            spaceCol = space87.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space88_Click(object sender, EventArgs e)
        {
            spaceRow = space88.Location.X;
            spaceCol = space88.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space89_Click(object sender, EventArgs e)
        {
            spaceRow = space89.Location.X;
            spaceCol = space89.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space91_Click(object sender, EventArgs e)
        {
            spaceRow = space91.Location.X;
            spaceCol = space91.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space92_Click(object sender, EventArgs e)
        {
            spaceRow = space92.Location.X;
            spaceCol = space92.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space93_Click(object sender, EventArgs e)
        {
            spaceRow = space93.Location.X;
            spaceCol = space93.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space94_Click(object sender, EventArgs e)
        {
            spaceRow = space94.Location.X;
            spaceCol = space94.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space95_Click(object sender, EventArgs e)
        {
            spaceRow = space95.Location.X;
            spaceCol = space95.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space96_Click(object sender, EventArgs e)
        {
            spaceRow = space96.Location.X;
            spaceCol = space96.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space97_Click(object sender, EventArgs e)
        {
            spaceRow = space97.Location.X;
            spaceCol = space97.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space98_Click(object sender, EventArgs e)
        {
            spaceRow = space98.Location.X;
            spaceCol = space98.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void space99_Click(object sender, EventArgs e)
        {
            spaceRow = space99.Location.X;
            spaceCol = space99.Location.Y;

            if (turn == true)
            {
                _ = moveCounter();
            }
        }

        private void blueSquare1_Click(object sender, EventArgs e)
        {
            counter = "blueSquare1";
            round = false;

            locRow = blueSquare1.Location.X;
            locCol = blueSquare1.Location.Y;

        }

        private void blueSquare2_Click(object sender, EventArgs e)
        {
            counter = "blueSquare2";
            round = false;

            locRow = blueSquare2.Location.X;
            locCol = blueSquare2.Location.Y;
        }

        private void blueSquare3_Click(object sender, EventArgs e)
        {
            counter = "blueSquare3";
            round = false;

            locRow = blueSquare3.Location.X;
            locCol = blueSquare3.Location.Y;
        }

        private void blueSquare4_Click(object sender, EventArgs e)
        {
            counter = "blueSquare4";
            round = false;

            locRow = blueSquare4.Location.X;
            locCol = blueSquare4.Location.Y;
        }

        private void blueSquare5_Click(object sender, EventArgs e)
        {
            counter = "blueSquare5";
            round = false;

            locRow = blueSquare5.Location.X;
            locCol = blueSquare5.Location.Y;
        }

        private void blueSquare6_Click(object sender, EventArgs e)
        {
            counter = "blueSquare6";
            round = false;

            locRow = blueSquare6.Location.X;
            locCol = blueSquare6.Location.Y;
        }

        private void blueRound1_Click(object sender, EventArgs e)
        {
            counter = "blueRound1";
            round = true;

            locRow = blueRound1.Location.X;
            locCol = blueRound1.Location.Y;

        }

        private void blueRound2_Click(object sender, EventArgs e)
        {
            counter = "blueRound2";
            round = true;

            locRow = blueRound2.Location.X;
            locCol = blueRound2.Location.Y;
        }

        private void blueRound3_Click(object sender, EventArgs e)
        {
            counter = "blueRound3";
            round = true;

            locRow = blueRound3.Location.X;
            locCol = blueRound3.Location.Y;
        }

        private void blueRound4_Click(object sender, EventArgs e)
        {
            counter = "blueRound4";
            round = true;

            locRow = blueRound4.Location.X;
            locCol = blueRound4.Location.Y;
        }

        private void blueRound5_Click(object sender, EventArgs e)
        {
            counter = "blueRound5";
            round = true;

            locRow = blueRound5.Location.X;
            locCol = blueRound5.Location.Y;
        }

        private void blueRound6_Click(object sender, EventArgs e)
        {
            counter = "blueRound6";
            round = true;

            locRow = blueRound6.Location.X;
            locCol = blueRound6.Location.Y;
        }

        private void redSquare1_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare1";

            redRow = redSquare1.Location.X;
            redCol = redSquare1.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redSquare2_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare2";

            redRow = redSquare2.Location.X;
            redCol = redSquare2.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redSquare3_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare3";

            redRow = redSquare3.Location.X;
            redCol = redSquare3.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redSquare4_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare4";

            redRow = redSquare4.Location.X;
            redCol = redSquare4.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redSquare5_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare5";

            redRow = redSquare5.Location.X;
            redCol = redSquare5.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redSquare6_Click(object sender, EventArgs e)
        {
            seizeCounter = "redSquare6";

            redRow = redSquare6.Location.X;
            redCol = redSquare6.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound1_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound1";

            redRow = redRound1.Location.X;
            redCol = redRound1.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound2_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound2";

            redRow = redRound2.Location.X;
            redCol = redRound2.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound3_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound3";

            redRow = redRound3.Location.X;
            redCol = redRound3.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound4_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound4";

            redRow = redRound4.Location.X;
            redCol = redRound4.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound5_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound5";

            redRow = redRound5.Location.X;
            redCol = redRound5.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }

        private void redRound6_Click(object sender, EventArgs e)
        {
            seizeCounter = "redRound6";

            redRow = redRound6.Location.X;
            redCol = redRound6.Location.Y;

            if (turn == true)
            {
                _ = seizeRed();
            }
        }
    }

}
