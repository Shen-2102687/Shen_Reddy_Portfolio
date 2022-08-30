//<2102687>

//Below are the necessary headers that needed to be included for this project
#include <iostream>
#include<iomanip>
#include<vector>
#include <fstream>
#include <string>
#include <sstream>
#include <cmath>

using namespace std;

//The function below initializes the random function for random number generation
void initialiseRand() {

    srand(time(0));

}

//The function below dynamically creates the number of snakes to be used in the board design
int numSnakesDynamic(int boardSizeN) {

    int numSnakes = 0;
    int temp = boardSizeN;

    numSnakes = 6 + rand() % temp + 1;
    std::cout << numSnakes << " number of snakes generated" << endl;

    return numSnakes;
}

//The function below dynamically creates the number of ladders to be used in the board design
int numLaddersDynamic(int boardSizeN) {

    int numLadders = 0;
    int temp = boardSizeN;

    numLadders = 6 + rand() % temp + 1;
    std::cout << numLadders << " number of ladders generated" << endl;

    return numLadders;
}


//The function below creates the length of snakes or ladders
vector<int> ladderLengthDynamic(vector<int> ladderStartVec, vector<int> ladderEndVec, string boardElement) {

    vector<int> ladderLengthVec;
    int vecSize = ladderStartVec.size();
    int ladderLength = 0;
    int start = 0;
    int end = 0;

    for (int i = 0; i < vecSize; i++) {

        start = ladderStartVec[i];
        end = ladderEndVec[i];

        ladderLength = end - start;

        ladderLengthVec.push_back(ladderLength); //Adding the length of the ladder to the ladder length vector

        if (boardElement == "ladder") {
            std::cout << "ladderLength: " << ladderLengthVec[i] << endl;
        }

        if (boardElement == "snake") {
            std::cout << "snakeLength: " << ladderLengthVec[i] << endl;
        }

    }

    std::cout << endl;
    return ladderLengthVec;
}

//The function below generates the end positions for ladders and snakes
vector<int> ladderEndDynamic(int numLadders, vector<int> ladderStartVec, string boardElement, int numTiles) {

    vector<int> ladderEndVec;
    int ladderEnd = 0;
    int temp = 0;
    int temp2 = 0;
    bool positionExists = false;

    for (int i = 0; i < numLadders; i++) {

        if (boardElement == "ladder") {
            temp = ladderStartVec[i] + 1;
            temp2 = numTiles - temp;
            ladderEnd = rand() % temp2 + temp;
        }

        if (boardElement == "snake") {
            temp = ladderStartVec[i] - 1;
            ladderEnd = rand() % temp + 1;
        }
        
        ladderEndVec.push_back(ladderEnd); //Adding the ladder end position to the ladder end vector

        if (boardElement == "ladder") {
            std::cout << "ladderEnd: " << ladderEndVec[i] << endl;
        }

        if (boardElement == "snake") {
            std::cout << "snakeEnd: " << ladderEndVec[i] << endl;
        }

    }

    std::cout << endl;
    return ladderEndVec;
}


//The function below is used  to generate the start position for the snakes
vector<int> snakeStartPos(int numSnakes, vector<int> ladderStartVec) {

    vector<int> snakeStartVec;
    int snakeStart = 0;
    int temp = 0;
    bool positionExists = false;

    for (int i = 0; i < numSnakes; i++) {

        snakeStart = rand() % 99 + 2;

        for (int j = 0; j < ladderStartVec.size(); j++) {
            if (snakeStart == ladderStartVec[j]) {
                positionExists = true;
            }
        }

        if (positionExists == true) {
            i--;
            positionExists = false;
            std::cout << "same as ladder detected" << endl;
            continue;
        }
        
        for (int k = 0; k < snakeStartVec.size(); k++) {
            if (snakeStart == snakeStartVec[k]) {
                positionExists = true;
            }
        }
        
        if (positionExists == true) {
            i--;
            positionExists = false;
            std::cout << "same as snakeVec detected" << endl;
            continue;
        }

        snakeStartVec.push_back(snakeStart);
        std::cout << "snakeStart: " << snakeStartVec[i] << endl;
    }

    std::cout << endl;
    return snakeStartVec;
}

//The function below is used to generate the ladder start positions
vector<int> LadderPosition(int numLadders, string boardElement) {

    vector<int> ladderStartVec;
    int ladderStart = 0;
    int temp = 0;
    bool positionExists = false;


    for (int i = 0; i < numLadders; i++) {
        
        if (boardElement == "ladder") {
            ladderStart = rand() % 90 + 2;     //where 90 = board size - n
        }

        if (boardElement == "snake") {
            ladderStart = rand() % 99 + 2;
        }

        for (int j = 0; j < ladderStartVec.size(); j++) {
            if (ladderStart == ladderStartVec[j]) {
                positionExists = true;
            }
        }

        if (positionExists == true) {
            i--;
            std::cout << "same detected" << endl;
            positionExists = false;
            continue;
        }

        ladderStartVec.push_back(ladderStart);

        if (boardElement == "ladder") {
            std::cout << "ladderstart: " << ladderStartVec[i] << endl;
        }
        if (boardElement == "snake") {
            std::cout << "snakestart: " << ladderStartVec[i] << endl;
        }
  
    }

    std::cout << endl;
    return ladderStartVec;
}

//The function below generates a number of ladders determined by the student number in binary form
int numLaddersBin(string studentNumBin) {

    int numLength = 0; 
    numLength = studentNumBin.length();
    char ladderIdentifier = '1';
    int numLadders = 0;

    for (int i = 0; i < numLength; i++) {

        if (studentNumBin[i] == ladderIdentifier) {
            numLadders++;
        }
    }

    return numLadders;

}

//The function below generates a number of snakes determined by the student number in binary form
int numSnakesBin(string studentNumBin) {

    int numLength = 0;
    numLength = studentNumBin.length();
    char snakeIdentifier = '0';
    int numSnakes = 0;


    for (int i = 0; i < numLength; i++) {
 
        if (studentNumBin[i] == snakeIdentifier) {
            numSnakes++;
        }
    }

    return numSnakes;
}

//The function below splits the input string from the file into the board size, student number, number of players and binary form of the student number
vector<string> splitString(string currentString, int numGames, string delimiter = " ") {


    int stringStart = 0; //The start index of the string
    int stringEnd = currentString.find(delimiter);  //A delimiter is used to identify when a new word appears and needs to be stored in a temp string
    string newString; //String value for the new string
    string nextString; //String value for the next string
    string tempString; //A temporary string variable
    string boardSize; //The board size
    string numPlayers; //The number of players
    string studentNumDec; //The student number in decimal
    string studentNumBin; //The student number in binary
    vector<string> inputVecList; //A vector to store the string list

    inputVecList.clear(); //Clearing the vector input list

    while (stringEnd != -1) {
        tempString = currentString.substr(stringStart, (stringEnd - stringStart));
        inputVecList.push_back(tempString);
        stringStart = stringEnd + delimiter.size();             //The start and end points are changed so that a new word in the input string can be identified
        stringEnd = currentString.find(delimiter, stringStart);
    }

    tempString = currentString.substr(stringStart, (stringEnd - stringStart));
    inputVecList.push_back(tempString);

    if (numGames == 0) { //Getting the game data for the first game
        boardSize = inputVecList[0];
        numPlayers = inputVecList[1];
        studentNumDec = inputVecList[2];
        studentNumBin = inputVecList[3];

        return inputVecList;
    }
    else
    { //Getting the game data for games after the first game
        boardSize = inputVecList[0];
        numPlayers = inputVecList[1];

        return inputVecList;
    }

}

//The function below is used to get an input string for use in the program
string newInputString(int numElements, vector<int> elementStartVec, vector<int> elementLengthVec, string identifier) {

    string newInput;

    for (int i = 0; i < numElements; i++) {
        newInput = newInput + identifier + " " + to_string(elementStartVec[i]) + "-" + to_string(elementLengthVec[i]) + "\n";
    }

    return newInput;
}

//The function below is used to clear the input file using truncation
void clearInput(string fileName) {

    ofstream file;
    file.open(fileName, std::ofstream::trunc); //Opens file for truncation
    file.close();

}

//The function below is the actual game and outputs a string containing the output results of the game
string playGame(int numTiles, int numPlayers, vector<int> ladderStartVec, vector<int> ladderLengthVec, vector<int> snakeStartVec, vector<int> snakeLengthVec) {

    bool gameOver = false; //Boolean element to show when the game is over
    int player = 0; //Integer for the player
    int dieRoll = 0; //Integer for the dice roll
    int playerPos = 0; //Integer for the players position
    bool onLadder = false; //Boolean to check if on a ladder
    bool playerWin = false; //Boolean to check if the player has won
    string outputString; //The output string to be returned at the end of the function
    vector<vector<int>> gameInfoVec; //2D Vector to store information of the players through the game
    vector<int> tempVec; //A temporary vector
    string SLD = " D-"; //String that holds either S- L- or D-
    string winner; //String to hold the winner
    int gameRound = 0; //Initializing the amount of game rounds to 0

    for (int i = 0; i < numPlayers; i++) { //For loop to initialize the players

        for (int j = 0; j < 4; j++) {
            tempVec.push_back(0); //Creating a vector of 4 for each player
        }

        tempVec[1] = i + 1; //Adding the player number to the vector
        
        //Below appends the output string
        outputString = outputString + "R-" + to_string(tempVec[0]) + " P-" + to_string(tempVec[1]) + " D-" + to_string(tempVec[2]) + " M-" + to_string(tempVec[3]) + "\n";

        //Below adds the player's vector to the 2D gamedata vector
        gameInfoVec.push_back(tempVec);

        //Clearing the temporary vector
        tempVec.clear();
    }
    winner.clear(); //Clearing the winner string
    while (!gameOver) { //While the game is not over, the rounds take place
        gameRound++; //Incrementing the number of rounds
        for (int i = 1; i <= numPlayers; i++) {//For loop to allow each player to have a turn
            tempVec.clear(); //clearing the temporary vector
            tempVec = gameInfoVec[i - 1]; //Storing the current players data into the temporary vector
            tempVec[0] = gameRound; //Storing the round in the temporary vector
            tempVec[2] = 0; //Setting the amount of places moved to 0

            rollDie: //Flag for rolling the dice
            dieRoll = rand() % 6 + 1; //Generating the dice roll between 1 and 6
            tempVec[2] = dieRoll; //Setting amount of places moved to the dice roll

            if (dieRoll == 6) {
                goto rollDie; //If the dice roll was 6, player goes back to the rollDie flag and rolls the dice again
            }

            tempVec[3] = tempVec[3] + tempVec[2]; //Adding the dice rolls to the player position
            playerPos = tempVec[3]; //Setting the players current position

            for (int j = 0; j < ladderStartVec.size(); j++) { //Checking to see if the players position is on a ladder
                if (playerPos == ladderStartVec[j]) {
                    //If player landed on a ladder, the amount of moves is increased accordingly and the position of the player is updated
                    tempVec[3] = tempVec[3] + ladderLengthVec[j];
                    tempVec[2] = tempVec[2] + ladderLengthVec[j];
                    SLD = " L-"; //Setting SLD string to ladder
                }
            }

            for (int k = 0; k < snakeStartVec.size(); k++) { //Checking to see if players position is on a snake
                if (playerPos == snakeStartVec[k]) {
                    //If a player landed on a snake, the amount of moves is decreased accordingly and the position of the player is updated
                    tempVec[2] = tempVec[2] - snakeLengthVec[k];
                    tempVec[3] = tempVec[3] - snakeLengthVec[k];
                    SLD = " S-"; //Setting SLD string to snake
                }
            }

            if (playerPos > numTiles) { //If the players position is greater than the number of tiles the player does not move
                playerPos = playerPos - tempVec[2];
                tempVec[3] = playerPos;
            }

            if (tempVec[3] == numTiles) { //If the player has landed on the final tile the player wins
                playerWin = true; //The player win flag is set to true
            }
            //The cout statements below are for debugging purposes and should be ignored
            cout << "Rounds: " << tempVec[0] << endl;
            cout << SLD << endl;
            cout << "Player: " << tempVec[1] << "position = " << tempVec[3] << "\n";
            //The output string is appended accordingly
            outputString = outputString + "R-" + to_string(tempVec[0]) + " P-" + to_string(tempVec[1]) + SLD + to_string(tempVec[2]) + " M-" + to_string(tempVec[3]) + "\n";
            //The current players info is stored to the gameinfo vector
            gameInfoVec[i - 1] = tempVec;
            if (playerWin) { //If a player has won the game is over
                gameOver = true;
                winner = "wP-" + to_string(tempVec[1]); //The winner string is created
                outputString = outputString + winner + "\n"; //The winner string is appended to the output string
                break; //The for loop ends
                
            }

        }

    }

    return outputString; //Returns the output string
}

int main()
{
    ifstream inFile; //input file variable to store the input file                               //The following variables are declared for use in the program
    ofstream outFile; //output file variable to output to the output file
    ofstream newInFile; //output file variable to clear the input string
    string inputFile = "input.txt"; //Declaring the input file

    string inputString; //String to store file input
    string inputStringAppend; //String to append to the input file
    string outputString; //String to output to the output file

    string binaryCondition; //String containing the binary student number format
    string studentNumDec; //String containing the decimal student number
    string ladderString; //String containing ladders
    string snakeString; //String containing snakes
    string boardCondition; //String containing the board size

    string snakeIdentifier = "S"; //String to identify snakes
    string ladderIdentifier = "L"; //String to identify ladders

    int numTiles = 0; //Integer to store the number of tiles
    int boardSizeN = 0; //Integer to store the board size
    int numGames = 0; //Integer to store the number of games played
    int numSnakes = 0; //Integer to store the number of snakes
    int numLadders = 0; //Integer to store the number of ladders
    int numPlayers = 0; //Integer to store the number of players

    vector<int> ladderStartVec; //Vector to store the ladder start positions
    vector<int> ladderEndVec; //Vector to store the ladder end positons
    vector<int> ladderLengthVec; //Vector to store the ladder lengths

    vector<int> snakeStartVec; //Vector to store the snake start positions
    vector<int> snakeEndVec; //Vector to store the snake end positions
    vector<int> snakeLengthVec; //Vector to store the snake lengths

    string elementSnake = "snake"; //String to store word snake
    string elementLadder = "ladder"; //String to store word ladder

    initialiseRand(); //Calling function to initialize random function

    outFile.open("results.txt", ios::trunc);         //This ensures the output file is cleared before use so that it displays the correct information
    outFile.close(); //Closing output file

    inFile.open("input.txt", ios::in); //Opening the input file

    if (inFile.is_open()) { //Checking if the input file is opened

        while (!inFile.eof()) { //While not at the end of the input file
            std::getline(inFile, inputString); //getting the line of the input file
            
            if (inputString.empty()) {
                continue; //Continueing out of the loop if the string is empty
            }

            if (numGames == 0) { //Checking if this is the first game

                boardCondition = (splitString(inputString, numGames, " "))[0]; //Getting the board size
                numPlayers = stoi((splitString(inputString, numGames, " "))[1]); //Getting the number of players
                numTiles = stoi(boardCondition); //Getting the number of tiles
                boardSizeN = sqrt(numTiles); //Finding the squre root of the number of tiles
                binaryCondition = (splitString(inputString, numGames, " "))[3]; //Getting the binary version of the student number
                studentNumDec = (splitString(inputString, numGames, " "))[2]; //Getting the decimal version of the student number
                numLadders = numLaddersBin(binaryCondition); //Getting the number of ladders based on the binary number
                ladderStartVec = LadderPosition(numLadders, elementLadder); //Getting the ladder start positions
                ladderEndVec = ladderEndDynamic(numLadders, ladderStartVec, elementLadder, numTiles); //Getting the ladder end positions
                ladderLengthVec = ladderLengthDynamic(ladderStartVec, ladderEndVec, elementLadder); //Getting the ladder lengths
                numSnakes = numSnakesBin(binaryCondition); //Getting the number of snakes based on the binary number
                snakeStartVec = snakeStartPos(numSnakes, ladderStartVec); //Getting the snake start positions
                snakeEndVec = ladderEndDynamic(numSnakes, snakeStartVec, elementSnake, numTiles); //Getting the snake end positions
                snakeLengthVec = ladderLengthDynamic(snakeEndVec, snakeStartVec, elementSnake); //Getting the snake lengths
      
                //Below is the output string outputted after the game has been played
                outputString = outputString + boardCondition + " " + studentNumDec + " " + binaryCondition + "\n" + playGame(numTiles, numPlayers, ladderStartVec, ladderLengthVec, snakeStartVec, snakeLengthVec) + "\n";

                //The below two lines get the strings to append to the input file
                ladderString = newInputString(numLadders, ladderStartVec, ladderLengthVec, ladderIdentifier);
                snakeString = newInputString(numSnakes, snakeStartVec, snakeLengthVec, snakeIdentifier);

                //Getting the string to be appended to the input file
                inputStringAppend = inputStringAppend + inputString + "\n" + ladderString + snakeString + "\n";

            }
            else
            {
                boardCondition = (splitString(inputString, numGames, " "))[0]; //Getting the board position based on file input line
                numPlayers = stoi((splitString(inputString, numGames, " "))[1]); //Getting the number of players based on the input file
                //numSnakes = numSnakesDynamic();
                numTiles = stoi(boardCondition); //Getting the number of tiles based on the input file
                boardSizeN = sqrt(numTiles); //Getting the board size n
                numLadders = numLaddersDynamic(boardSizeN); //Dynamically generating the number of ladders
                ladderStartVec = LadderPosition(numLadders, elementLadder); //Getting the positions of the ladders
                ladderEndVec = ladderEndDynamic(numLadders, ladderStartVec, elementLadder, numTiles); //Getting the end positions of the ladders
                ladderLengthVec = ladderLengthDynamic(ladderStartVec, ladderEndVec, elementLadder); //Getting the length of the ladder
                numSnakes = numSnakesDynamic(boardSizeN); //Dynamically generating the number of snakes
                snakeStartVec = snakeStartPos(numSnakes, ladderStartVec); //Getting the snake start positions
                snakeEndVec = ladderEndDynamic(numSnakes, snakeStartVec, elementSnake, numTiles); //Getting the snake end positions
                snakeLengthVec = ladderLengthDynamic(snakeEndVec, snakeStartVec, elementSnake); //Getting the snake lengths

                //The line below generates the output string based on the game played
                outputString = outputString + boardCondition + "\n" + playGame(numTiles, numPlayers, ladderStartVec, ladderLengthVec, snakeStartVec, snakeLengthVec) + "\n"; 

                //The below two lines get the strings to be appended to the input file
                ladderString = newInputString(numLadders, ladderStartVec, ladderLengthVec, ladderIdentifier);
                snakeString = newInputString(numSnakes, snakeStartVec, snakeLengthVec, snakeIdentifier);

                //Generating the input string to append to the input file
                inputStringAppend = inputStringAppend  + inputString + "\n" + ladderString  + snakeString + "\n";

            }
            numGames++; //Incrementing the number of games
        }

        inFile.close(); //Closing the input file
    }

    clearInput(inputFile); //Clearing the input file

    newInFile.open("input.txt", ios::app); //Opening the input file for appending
    newInFile << inputStringAppend;//adding the appendstring to the input file
    newInFile.close(); //Closing the input file

    outFile.open("results.txt", ios::app); //Opening the results file for appending
    outFile << outputString; //Adding the output string to the results file
    outFile.close(); //Closing the output file

}

