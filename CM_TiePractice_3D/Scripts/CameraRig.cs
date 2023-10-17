using Godot;
using System;

public partial class CameraRig : Node3D {

	[Export] private Node3D cameraNode;
	[Export] private Vector2 rotationSpeed;
	[Export] private Vector2 pitchRestriction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		Vector2 mouseInput = Input.GetLastMouseVelocity();

		RotateY(-mouseInput.X * (float) delta * rotationSpeed.X);
		cameraNode.RotateX(mouseInput.Y * (float) delta * rotationSpeed.Y);

		cameraNode.Rotation = new Vector3(Mathf.Clamp(cameraNode.Rotation.X, pitchRestriction.X, pitchRestriction.Y), cameraNode.Rotation.Y, cameraNode.Rotation.Z);

		if (Input.IsKeyPressed(Key.Escape)) {
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}

	}

	public Vector3 GetFlatForward() {
		return Quaternion.FromEuler(GlobalRotation) * Vector3.Forward;
	}

	public Vector3 GetForward() {
		return Quaternion.FromEuler(cameraNode.GlobalRotation) * Vector3.Forward;
	}

	public Vector3 GetFlatRight() {
		return Quaternion.FromEuler(GlobalRotation) * Vector3.Right;
	}

	public Vector3 GetRight() {
		return Quaternion.FromEuler(cameraNode.GlobalRotation) * Vector3.Right;
	}

}
