using System.Linq;

using System.Collections.Generic;

using System.Text.Json;

List<int> CountAvg = new List<int>();
List<int> SaveScore;

Random Number = new Random();

// random number generated for each level
int correctNumber = Number.Next(1, 31);
int correctNumberLvl2 = Number.Next(1, 51);
int correctNumberLvl3= Number.Next(1, 71);
int correctNumberLvl4 = Number.Next(1, 101);


bool win = false;
// count for each level 
int count = 0;
int count2 = 0;
int count3 = 0;
int count4 = 0;
int avg = 1;
/// ///////////////// 

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Cyan;


Console.WriteLine("Daniel Zahiroddini's Guessing Game");



// LOAD SCORE FROM FILE
string scoreStr = File.ReadAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt");

if (scoreStr != "")
{
    var options = new JsonSerializerOptions();
    SaveScore = JsonSerializer.Deserialize<List<int>>(scoreStr, options);
} else
{
    SaveScore = new List<int>();
}



BeginningGame(); // asks if user wants to load save file, or start from scratch // 






do
{
    GuessingGame();  // main code of game
    if (win == true)
    {
        Console.WriteLine("\nWould you like to play again?");
        Console.WriteLine("\n Press Y to play again \tPress Z to play level 2 \n Press N to exit \n Press S to save"); // p // 
        string response = Console.ReadLine().ToUpper();
        if (response == "N")
        {
            Console.WriteLine("\nHave a great day!");

            break;


        }
        else if (response == "Y")
        {
            RestartGame();

            continue;
        }
        else if (response == "S")
        {
            Console.WriteLine("Saving...");

            var options = new JsonSerializerOptions();
            string jsonString = JsonSerializer.Serialize(SaveScore, options);
            // Write String Data to File
            // File will be created if it doesn't exist
            // File.WriteAllText(path_to_file, string_to_write);

            File.WriteAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt", jsonString);

            Console.WriteLine("Saved!"); // wip // 
            BeginningGame();



        }
        else if (response == "Z")
        {
            avg++;
            win = false;
            Console.WriteLine("\nI am thinking of a number between 1-50. Can you guess the number?");
            
            
            do
            {

                GuessingGameLvl2();
                





                if (win == true)
                {
                    Console.WriteLine("\nWould you like to play again?");
                    Console.WriteLine("\nPress Z to play level 3 \n Press N to exit \n Press S to save"); // p // 
                    string responseLvl2 = Console.ReadLine().ToUpper();
                    if (responseLvl2 == "N")
                    {
                        Console.WriteLine("\nHave a great day!");

                        Environment.Exit(0);
                        

                        


                    }
                    else if (responseLvl2 == "Y")
                    {
                        RestartGame();

                        continue;
                    }
                    else if (responseLvl2 == "S")
                    {
                        Console.WriteLine("Saving...");

                        var options = new JsonSerializerOptions();
                        string jsonString = JsonSerializer.Serialize(SaveScore, options);
                        // Write String Data to File
                        // File will be created if it doesn't exist
                        // File.WriteAllText(path_to_file, string_to_write);

                        File.WriteAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt", jsonString);

                        Console.WriteLine("Saved!"); // wip // 
                        BeginningGame();

                    } else if (responseLvl2 == "Z")
                    {
                        avg++;
                        win = false;
                        Console.WriteLine("\nI am thinking of a number between 1-70. Can you guess the number?");

                        do
                        {

                            GuessingGameLvl3();

                            if (win == true)
                            {

                                Console.WriteLine("\nWould you like to play again?");
                                Console.WriteLine("\nPress Z to play level 4 \n Press N to exit \n Press S to save"); // p // 
                                string responseLvl3 = Console.ReadLine().ToUpper();

                                if (responseLvl3 == "N")
                                {
                                    Console.WriteLine("Have a great day!");

                                    Environment.Exit(0);
                                } else if (responseLvl3 == "S")
                                {
                                    Console.WriteLine("Saving...");

                                    var options = new JsonSerializerOptions();
                                    string jsonString = JsonSerializer.Serialize(SaveScore, options);
                                    // Write String Data to File
                                    // File will be created if it doesn't exist
                                    // File.WriteAllText(path_to_file, string_to_write);

                                    File.WriteAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt", jsonString);

                                    Console.WriteLine("Saved!"); // wip // 
                                    BeginningGame();
                                } else if (responseLvl3 == "Z")
                                {
                                    avg++;
                                    win = false;
                                    Console.WriteLine("\nI am thinking of a number between 1-100. Can you guess the number?");

                                    do
                                    {
                                        GuessingGameLvl4();

                                        if (win == true)
                                        {
                                            Console.WriteLine("\nCONGRATS! You just beat the game!");

                                            Console.WriteLine("\nHere are your final stats:");

                                            AverageAttempts();

                                            Console.WriteLine("Would you like to save? If so, press S \nIf not, press N to exit the game");

                                            string finalResponse = Console.ReadLine().ToUpper();

                                            if (finalResponse == "N")
                                            {
                                                Console.WriteLine("Thanks for playing!");
                                                Environment.Exit(0);
                                            } else if (finalResponse == "S")
                                            {
                                                Console.WriteLine("Saving...");

                                                var options = new JsonSerializerOptions();
                                                string jsonString = JsonSerializer.Serialize(SaveScore, options);
                                                // Write String Data to File
                                                // File will be created if it doesn't exist
                                                // File.WriteAllText(path_to_file, string_to_write);

                                                File.WriteAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt", jsonString);

                                                Console.WriteLine("Saved!"); // wip // 
                                                BeginningGame();
                                            }
                                        }



                                    } while (true);
                                }
                                


                            }
                        } while (true);



                    }
                } 

            } while (true);

        }



        
    }

} while (true);



void GuessingGame()
{

    string input = Console.ReadLine(); // get user input
    int num = -1;
   
    
    if (!int.TryParse(input, out num)) // check if user input is an integer, otherwise return as "not an integer"
    {
        Console.WriteLine("\nNot an integer");
    } else if (num > 30)
    {
        Console.WriteLine("\nPlease enter a number inside the range");


    }
    else if (num > correctNumber)

    {

        Console.WriteLine("Smaller");
        count++;
        Console.WriteLine($"\n{count} total attempts");

    }
    else if (num < correctNumber)

    {
        Console.WriteLine("\nHigher");
        count++;
        Console.WriteLine($"\n{count} total attempts");

    }
    else if (num == correctNumber)
    {
        Console.WriteLine($"\nCorrect! The digit was {correctNumber}");
        count++;
        
        SaveScore.Add(count);
        SaveScore.Add(avg);
       

        Console.WriteLine($"\nIt took {count} total attempts to get the number right");
        CountAvg.Add(count);


        AverageAttempts();  // # of attempts each game stored in a list // 


        win = true;

    }
   
}

void GuessingGameLvl2()
{
    
    
    
    int num = -1;



    string input = Console.ReadLine(); // get user input

  


    if (!int.TryParse(input, out num)) // check if user input is an integer, otherwise return as "not an integer"
    {
        Console.WriteLine("\nNot an integer");
    }
    else if (num > 50)
    {
        Console.WriteLine("\nPlease enter a number inside the range");
    }
    else if (num > correctNumberLvl2)

    {

        Console.WriteLine("Smaller");
        count2++;
        Console.WriteLine($"\n{count2} total attempts");

    }
    else if (num < correctNumberLvl2)

    {
        Console.WriteLine("\nHigher");
        count2++;
        
        Console.WriteLine($"\n{count2} total attempts");

    }
    else if (num == correctNumberLvl2)
    {
        Console.WriteLine($"\nCorrect! The digit was {correctNumberLvl2}");
        count2++;
        SaveScore.Add(count2);
        SaveScore.Add(avg);


        Console.WriteLine($"\nIt took {count2} total attempts to get the number right");
        CountAvg.Add(count2);



        AverageAttempts();   // # of attempts each game stored in a list // 


        win = true;

    }
}

void GuessingGameLvl3()
{
    


    int num = -1;



    string input = Console.ReadLine(); // get user input




    if (!int.TryParse(input, out num)) // check if user input is an integer, otherwise return as "not an integer"
    {
        Console.WriteLine("\nNot an integer");
    }
    else if (num > 70)
    {
        Console.WriteLine("\nPlease enter a number inside the range");
    }
    else if (num > correctNumberLvl3)

    {

        Console.WriteLine("Smaller");
        count3++;
        Console.WriteLine($"\n{count3} total attempts");

    }
    else if (num < correctNumberLvl3)

    {
        Console.WriteLine("\nHigher");
        count3++;

        Console.WriteLine($"\n{count3} total attempts");

    }
    else if (num == correctNumberLvl3)
    {
        Console.WriteLine($"\nCorrect! The digit was {correctNumberLvl3}");
        count3++;

        SaveScore.Add(count3);
        SaveScore.Add(avg);


        Console.WriteLine($"\nIt took {count3} total attempts to get the number right");
        CountAvg.Add(count3);


        AverageAttempts();  // # of attempts each game stored in a list // 


        win = true;

    }
}

void GuessingGameLvl4()
{
    int num = -1;



    string input = Console.ReadLine(); // get user input




    if (!int.TryParse(input, out num)) // check if user input is an integer, otherwise return as "not an integer"
    {
        Console.WriteLine("\nNot an integer");
    }
    else if (num > 100)
    {
        Console.WriteLine("\nPlease enter a number inside the range");
    }
    else if (num > correctNumberLvl4)

    {

        Console.WriteLine("Smaller");
        count4++;
        Console.WriteLine($"\n{count4} total attempts");

    }
    else if (num < correctNumberLvl4)

    {
        Console.WriteLine("\nHigher");
        count4++;

        Console.WriteLine($"\n{count4} total attempts");

    }
    else if (num == correctNumberLvl4)
    {
        Console.WriteLine($"\nCorrect! The digit was {correctNumberLvl4}");
        count4++;

        SaveScore.Add(count4);
        SaveScore.Add(avg);


        Console.WriteLine($"\nIt took {count4} total attempts to get the number right");
        CountAvg.Add(count4);


        AverageAttempts();  // # of attempts each game stored in a list // 


        win = true;

    }
}


void RestartGame()
  {
    avg++; // increases avg everytime you restart game
    count = 0; // count is reset
    win = false;
    correctNumber = Number.Next(1, 31); // new rng number is generated
    Console.WriteLine("\nI am thinking of a number between 1-30. Can you guess the number?");

  }

 
 

 void AverageAttempts()
{


    int store = CountAvg.Sum(x => Convert.ToInt32(x)); // adds all the integer values stored in the countavg list
    double ttlavg = (double)store / avg; // gets the average
    Console.WriteLine($"\nAverage attempts: {ttlavg}");

   
    Console.WriteLine($"\nTotal attempts: {store} ");

}

void BeginningGame()
{

    win = false;
    
    Console.WriteLine("Welcome!\n \nWould you like to play from a previous load, or start from scratch?\nA for previous load save.\nB for start from scratch");
    string responsePrev = Console.ReadLine().ToUpper();
    if (responsePrev == "A")
    {
        Console.WriteLine("Was this your data?\nY for yes.\nN for no.");


        // Load JSON string from file
        string jsonStringFromFile = File.ReadAllText(@"C:\Users\d.zahiroddini\Desktop\SaveScore\score1.txt");
        Console.WriteLine(jsonStringFromFile);

        

        string answer = Console.ReadLine();
        if (answer == "Y")
        {
            RestartGame();
            
            
            if (win == true)
            {
                SaveScore.Add(count);
                SaveScore.Add(avg); 
                
            }
        } else
        {
            Environment.Exit(0);
        }
    }
    else if (responsePrev == "B")
    {
        Console.WriteLine("\nI am thinking of a number between 1-30. Can you guess the number?");
        correctNumber = Number.Next(1, 31);

        Clear();
        
        GuessingGame();
        avg = 0;
        avg++;
        
        
    }
}


void Clear()
{
    SaveScore.Clear();
    CountAvg.Clear();
}



