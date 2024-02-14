using Godot;
using System;

public partial class GameManager : Node
{
    // this is an example of the use of command pattern to use it in the GameManager
    public static GameManager Instance;

    public GameState State;

// how do i get this to work?


    //public static event Action<GameState>OnGameStateChanged; //this does not seem to work in godot but it works in unity -> [Signal] is the equivalent is seems


    //this sends a signal everywhere to all scripts and thells them that there that if something happens in this function (in my case "UpdateGameState2") then it will send a signal so that it triggers an action everywhere where the scripts are listening
    //to this signal -> UpdateGameState2"
    [Signal]
    public delegate void UpdateGameState2EventHandler(GameState newState2);


// the awake function runs when an enabled script instance is being loaded, the difference between this and ready is that ready will run once when class is called. i think...
    void Awake()
    {
        Instance = this;
    }

    public override void _Ready()
    {
       // This line below will add the signals function to the function "Test", if something happens to the function "Test" then it will trigger a signal to all other functions that are connected to "Test" in this case we have connected it to MenuManagers function
       // "Test2" and there it will be triggerd, it will also send the information in "int fem" to all the functions everywhere!
        UpdateGameState2 += UpdateGameState;
        UpdateGameState(GameState.Menu);
        //EmitSignal(nameof(UpdateGameState2), 5); // This Emit signal will send a signal from "UpdateGameState2" that we have to name as a string therefor the nameof(IpdateGameState2) to all functions that are listening and send the value - > 5 everywhere!
        // in other words it gives int fem = 5;
    }

    public void UpdateGameState(GameState newState)
    {

        //EmitSignal(nameof(UpdateGameState2), 5);

        State = newState;
        switch (newState)
        {
            case GameState.Menu:
                HandleMenuSelect();
                //EmitSignal(nameof(UpdateGameState2), 5); // testing how the EmitSignal function worked
                //GD.Print("hi");
                break;
            case GameState.PlayerManager:
                HandlePlayerSelect();
                break;
            case GameState.LevelManager:
                HandleLevelSelect();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

    }

    private void HandleLevelSelect()
    {
        throw new NotImplementedException();
    }
    private void HandlePlayerSelect()
    {
        GD.Print("hi there, seems fine");
        //throw new NotImplementedException();
    }
    private void HandleMenuSelect()
    {
        //UpdateGameState(GameState.PlayerManager);
        //throw new NotImplementedException();
       // EmitSignal(nameof(UpdateGameState2), 5);
    }

    // this function is an inbuilt function that allows us to use inputs to trigger events
    public override void _UnhandledInput(InputEvent @event)
    {
        // if am @event is the triggered key (in this case the escape key" then this loop will trigger 
        if(@event is InputEventKey eventKey)
        {
            // last nested lood will trigger if the eventKey is pressed down (activated) and the eventKey built in keycode is == the escape Key
            if(eventKey.Pressed && eventKey.Keycode == Key.Escape)
            {
                //this only gets the Quit function from the main treenode and closes the program, it probably returns 0 if the main is of int type (int main, where the game starts from)
                GetTree().Quit();
            }

        }

    }

}

public enum GameState
{
    Menu,
    PlayerManager,
    LevelManager

}
