# Conways.Game.Of.Life#
## Simple application of Conway's rules for Conway's game "Life"
https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#Variations

This is a terminal application written in C# and .NET Core 3.1 utilising Visual Studio Code an Xunit 2.4.0 Test framework

Basic rules of the game are:
- A Live Cell with less than Two live neighbours dies 
- A Live Cell with 2 or 3 live neighbours lives on to the next generation
- A Dead Cell with exactly 3 live neighbours become alive
- A Live Cell with more than 3 live neighbours dies
in this implemwntation:
- A Cell on the edge of the grid, neighbours are calculated by using the other edge of the grid (wrapping)
- A Cell cannot reference itself as one of it's own neighbours
  
To try out the game for yourself, please clone the main branch.

Once copied the game can be run from the root folder by running `dotnet run --project Conways.Game.Of.Life.Code/Conways.Game.Of.Life.Code.csproj` in your terminal window.

(Tests can be run using the `dotnet test` command while in the root folder)

Once running the user will be given prompts for them to answer. 
First, the user will be prompted to enter a number for rows and columns - This is to set the size of the grid for the game. Once entered a blank grid will be displayed with the rows and columns entered. Enter the number of rows and number of columns seperated by a ',' other formats cause errors.  

example:
```
Please enter the number of rows and columns (eg, 3,4)
5,5
 .  .  .  .  . 
 .  .  .  .  . 
 .  .  .  .  . 
 .  .  .  .  . 
 .  .  .  .  .
 ```
 
 Second, the user will be prompted for file entry - This is whether the user has a pre-filled CSV file of number pairs (locations) they would like the program to use, the other option is to manually enter in locations to be set to 'Alive'. This 'seeds' the grid with a starting state - the seeded state is then shown to the user. To manually enter locations enter pairs of numbers
 
 example:
 ```
File entry y/n?
y
Please enter file path (e.g /Users/Desktop/smallOscillator.csv
/Users/James.Golding/Desktop/smallOscillator.csv
 .  .  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  .  .  .  . 
 ```
 
 **equivalent manual entry example:**
 ```
File entry y/n?
n
Please enter the location (row,column) for any cells you wish to begin alive eg(1,2 3,4 0,0)
1,1 2,1 3,1
```
 Lastly, the user will be prompted for the maximum number of generations - this provides an end point in case a pattern becomes infinitely stable/reproducing. The program will also 'early exit' if all the cells in a generation are 'Dead' to prevent multiple outputs of 'nothing'.
 
 example:
 ```
 Please enter the maximum number of generations you would like to see (eg. 3)
 5
 ```
 (The starting grid is them shown before updating and showing the 'new' grid, in this case 5 times(the program utilises the Console.Clear() function when printing the grids to give the illusion of motion, here the output has been condensed).
 ```
 .  .  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  .  .  .  . 

 .  .  .  .  . 
 .  .  .  .  . 
 A  A  A  .  . 
 .  .  .  .  . 
 .  .  .  .  . 

 .  .  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  .  .  .  . 

 .  .  .  .  . 
 .  .  .  .  . 
 A  A  A  .  . 
 .  .  .  .  . 
 .  .  .  .  . 

 .  .  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  A  .  .  . 
 .  .  .  .  . 

 .  .  .  .  . 
 .  .  .  .  . 
 A  A  A  .  . 
 .  .  .  .  . 
 .  .  .  .  . 
 ```
 
 
 **Note: 
  Some exception handling has been included in the project - the ones included will cause the program to loop to the appropriate prompt while displaying an error message.
  Some tests use a absolute file path to access a file on the Desktop - these tests will fail until that path is updated to your local machine and an appropriately named file (with appropriate data used).
  If a CSV file contains locations outside the grid specified, they will be left out of the grid.**
  When creating a csv file use two columns of data, one for the rows and one for columns eg.
  1 1
  0 0
  2 3
  5 5
  (this is the equivalent to manual entry: 1,1 0,0 2,3 5,5)
 
 
