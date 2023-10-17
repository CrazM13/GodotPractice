using Godot;
using System;
using System.Collections.Specialized;

public partial class PlayerMovement : Node3D {

	[Export] private float movementSpeed;
	[Export] private CameraRig camera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		Vector2 movementInput = new Vector2(Input.GetAxis("ui_right", "ui_left"), Input.GetAxis("ui_up", "ui_down"));

		Position += (camera.GetFlatRight() * movementInput.X * (float) delta * movementSpeed) + (camera.GetFlatForward() * movementInput.Y * (float) delta * movementSpeed);

		Vector3 storedRotation = camera.GlobalRotation;

		Rotation = new Vector3(Rotation.X, camera.GlobalRotation.Y, Rotation.Z);
		camera.GlobalRotation = storedRotation;

		//Position += new Vector3(movementInput.X * (float) delta * movementSpeed, 0, movementInput.Y * (float) delta * movementSpeed);

	}
}
