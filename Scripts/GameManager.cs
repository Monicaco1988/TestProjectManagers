using Godot;
using System;

public partial class GameManager : Node
{
    // this is an example of the use of command pattern to use it in the GameManager
    private static GameManager Instance;

    public GameState State;

// how do i get this to work?


    //public static event Action<GameState>OnGameStateChanged; //this does not seem to work in godot but it works in unity -> [Signal] is the equivalent is seems

[Signal]
public delegate void SendingStateSignalEventHandler();


// the awake function runs when an enabled script instance is being loaded, the difference between this and ready is that ready will run once when class is called. i think...
    void Awake()
    {
        Instance = this;
    }
    public override void _Ready()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Menu:
                HandleMenuSelect();
                //GD.Print("hi");
                break;
            case GameState.PlayerManager:
                GD.Print("hi there, seems fine");
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
        throw new NotImplementedException();
    }


    private void HandleMenuSelect()
    {
        //throw new NotImplementedException();
    }

}

public enum GameState
{
    Menu,
    PlayerManager,
    LevelManager

}
