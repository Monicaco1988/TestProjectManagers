using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class MenuManager : Control
{
    //[SerializedField] int unity Is the same as [Export] int godot 

    [Export]
    private Button _pressButton;


    private GameManager _GetSignalFromGameManager;

    public override void _Ready()
    {
        //Getting signal from GameManager.
        _GetSignalFromGameManager = GetNode<GameManager>("/root/Managers/GameManager");
    }

    void OnButtonPressed()
    {
        GD.Print("Hello " + _GetSignalFromGameManager.State);
        _GetSignalFromGameManager.State++;
        GD.Print("Hello again " + _GetSignalFromGameManager.State);
        
        //not getting this to work
        EmitSignal(nameof(_GetSignalFromGameManager.State));


    }


}