using Godot;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

public partial class MenuManager : Control
{
    //[SerializedField] int unity Is the same as [Export] int godot 

    [Export]
    private Button _pressButton;

    public static MenuManager Instance;

    [Export]
    private GameManager _GetSignalFromGameManager;

    void Awake ()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        //Getting signal from GameManager.
        _GetSignalFromGameManager = GetNode<GameManager>("/root/Managers/GameManager");
        _GetSignalFromGameManager.UpdateGameState2 += Test2;
    }


    public void Test2(int fe)
    {
        GD.Print(fe+1);

    }

    void OnButtonPressed() // when pressing Start the State should change to PlayerState but now it would be nice with whichever tho...
    {
        GD.Print("Hello " + _GetSignalFromGameManager.State);
        _GetSignalFromGameManager.State++; // changes the state to next in enum in the GameManager script which is PlayerState
        GD.Print("Hello again " + _GetSignalFromGameManager.State);

        _GetSignalFromGameManager.EmitSignal(nameof(_GetSignalFromGameManager.UpdateGameState2), 5);

        if (GameState.Menu != _GetSignalFromGameManager.State)
        {
            this.Hide();

        }
        //not getting this to work
        //EmitSignal(MySignal);

        //GameManager.Instance.UpdateGameState(GameState.PlayerManager); // why isnt this one working?


    }

    void OnButtonPressed2() // this button is connected to "Quit"
    {
        //When pressed the game should quit.
        GetTree().Quit();
    }

    
}