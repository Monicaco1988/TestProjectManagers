using Godot;
using System;

public partial class RootPivot : Marker3D
{

private int playerId = 1; // seems like each player is given an index so player 1 is index 0, player 2 is index 1 etc. good to know.


//this is not necessary but it was to index every collisionshape, but as the collisionshapes are destroyed they are resett on the index and the next collision shape is index 0 again.
private int collisionshapes = 0;

[Export]
public Area3D areaNodeToDequeue;

	[Export]
	public Node3D _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//sets the camera pivot to the leading car position, use of "this" keyword obs
		this.GlobalPosition = _player.GetChild<CharacterBody3D>(0).GlobalPosition; //_player.GetChild<CharacterBody3D>(playerId).GlobalPosition
	}

		public void OnPlayerEnter(Node3D playerContainer)
	{
		//debugg and ID of body exiting checkpoint
		GD.Print("Detection Entering" + _player.GetChild<CharacterBody3D>(1).Name);

		if(playerContainer.Name == _player.GetChild<CharacterBody3D>(1).Name)
		{//this.GlobalPosition = _player.GetChild<CharacterBody3D>(1).GlobalPosition; Not needed for smooooth transition!!!
		playerId = 1;
		}
		else if (playerContainer.Name == _player.GetChild<CharacterBody3D>(0).Name)
		{//this.GlobalPosition = _player.GetChild<CharacterBody3D>(0).GlobalPosition; Not needed for smooooth transition!!!
		playerId = 0;
		}

		//destroy the collisionshape after a player passes through it!
		areaNodeToDequeue.GetChild<CollisionShape3D>(collisionshapes).QueueFree();

		// This works fine now...

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	// this should smooth out the camera follow on the player by linearinterpolating the distance and refreshing it every delta times a sensitivity to make it faster or slower for the camera to get to the player position.
	this.GlobalPosition = this.GlobalPosition.Lerp(_player.GetChild<CharacterBody3D>(playerId).GlobalPosition,(float)delta * 5f);
	} // it works amazing!
}
