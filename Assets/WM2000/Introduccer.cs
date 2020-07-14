using UnityEngine;

public class Introduccer : MonoBehaviour
{
    string[] level1 = { "city", "report", "file", "tax", "case" };
    string[] level2 = { "movies", "channels", "games", "banned", "manage" };
    string[] level3 = { "criminals", "agencies", "prison", "information", "planning" };

    string password;
    const string menuText = "Type \"menu\" for returning back to menu or \"next\" for next guess: ";
    string level;

    enum GameStates {menu,password,result};
    GameStates states;


    void Start()
    {
        Menu();
    }

    void Menu()
    {
        states = GameStates.menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("what would you like to hack into?");
        Terminal.WriteLine("press 1 for FBA");
        Terminal.WriteLine("press 2 for PTA");
        Terminal.WriteLine("Press 3 for CIA");

    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Menu();
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("If on web, close the tab");
            Application.Quit();
        }
        else if (states == GameStates.menu)
        {
            passwordGuessing(input);
        }
        else if(states==GameStates.password)
        {
            checking(input);
        }
        else if(states==GameStates.result)
        {
            if(input=="next")
            {
                passwordGuessing(level);
            }
        }
        
    }

    void passwordGuessing(string input)
    {
        bool isValidInput = (input == "1" || input == "2" || input == "3");
        if (isValidInput)
        {
            states = GameStates.password;
            Terminal.ClearScreen();
            if (input == "1")
            {
                level = "1";
                password = level1[Random.Range(0, level1.Length)];
            }
            else if (input == "2")
            {
                level = "2";
                password = level2[Random.Range(0, level2.Length)];
            }
            else
            {
                level = "3";
                password = level3[Random.Range(0, level3.Length)];
            }

            Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        }

        else
        {
            Terminal.WriteLine("Invalid Input");
        }
    }

    void checking(string input)
    {
        if(input==password)
        {
            winScreen();
        }
        else
        {
            passwordGuessing(level);
        }
    }

    void winScreen()
    {
        states = GameStates.result;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuText);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case "1":
                Terminal.WriteLine("A book with millions of record...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case "2":
                Terminal.WriteLine("You got the network key!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case "3":
                Terminal.WriteLine(@"
 _____ _____ ______
/     \  |   |    |
|        |   |    |
|        |   |----|
\_____/_____ |    |
"
                );
                Terminal.WriteLine("Welcome to CIA's secret system!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

}
