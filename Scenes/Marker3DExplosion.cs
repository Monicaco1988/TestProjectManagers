using Godot;
using System;

public partial class Marker3DExplosion : Marker3D
{
    private int playerId = 0;

    [Export]
    public CharacterBody3D _player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //sets the camera pivot to the leading car position, use of "this" keyword obs
        this.GlobalPosition = _player.GetNode<CharacterBody3D>("/root/World/Multiplayer/CharacterBody3D2").GlobalPosition; //_player.GetChild<CharacterBody3D>(playerId).GlobalPosition
    }
    // Called every frame. 'delta' is the elapsed time since the previ
    // ous frame.
    public override void _Process(double delta)
	{
        // this should smooth out the camera follow on the player by linearinterpolating the distance and refreshing it every delta times a sensitivity to make it faster or slower for the camera to get to the player position.
        this.GlobalPosition = this.GlobalPosition.Lerp(_player.GetNode<CharacterBody3D>("/root/World/Multiplayer/CharacterBody3D2").GlobalPosition, (float)delta * 5f);

    }
}
