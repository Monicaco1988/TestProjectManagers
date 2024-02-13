using Godot;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

public partial class MenuManager : Control
{
    //[SerializedField] int unity Is the same as [Export] int godot 

    private Button _pressButton;

    public static MenuManager Instance;

    private GameManager _GetSignalFromGameManager;

    void Awake ()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        //Getting signal from GameManager.
        _GetSignalFromGameManager = GetNode<GameManager>("/root/Managers/GameManager");
        // activating signal on the function "OnButtonPressed"
        _GetSignalFromGameManager.UpdateGameState2 += Test2;
    }

    private void Test2(GameState tst)
    {
        if(GameState.Menu != _GetSignalFromGameManager.State)
            _GetSignalFromGameManager.UpdateGameState2 -= Test2; //deque avoid memleak
    }

    public void OnButtonPressed() // when pressing Start the State should change to PlayerState but now it would be nice with whichever tho...
    {
        GD.Print("Hello " + _GetSignalFromGameManager.State);
       
        

        _GetSignalFromGameManager.State++; // changes the state to next in enum in the GameManager script which is PlayerState

        GD.Print("Hello again " + _GetSignalFromGameManager.State);

        if (GameState.Menu != _GetSignalFromGameManager.State)
        {
            this.Hide();
        }

        //its working but i cant send the right signal exactly, instead of sending the "_GetSignalFromGameManager.State" which i believe is the "playerManager" i need to send the index of the state which is "1"... 
        _GetSignalFromGameManager.EmitSignal(nameof(_GetSignalFromGameManager.UpdateGameState2), 1);
        //not getting this to work
        //EmitSignal(MySignal);

        //GameManager.Instance.UpdateGameState(GameState.PlayerManager); // why isnt this one working?

        //dequeueing the signal to avoid memleaks
        _GetSignalFromGameManager.UpdateGameState2 -= Test2;
    }

    void OnButtonPressed2() // this button is connected to "Quit"
    {
        //When pressed the game should quit.
        GetTree().Quit();
    }

    
}