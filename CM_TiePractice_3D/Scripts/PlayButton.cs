using Godot;
using System;
using System.Collections.Specialized;

public partial class PlayButton : Button {

	[Export] private Control ui;
	[Export] private Node3D player;
	[Export] private Node3D camera;
	[Export] private Control HUD;

	private void OnPlayPressed() {
		ui.Hide();

		camera.GetParent().RemoveChild(camera);
		player.AddChild(camera);

		camera.Rotation = new Quaternion(Vector3.Up, Mathf.DegToRad(180)).GetEuler();
		camera.Position = new Vector3(0, 1, -3);

		Input.MouseMode = Input.MouseModeEnum.Captured;

		HUD.Show();
	}

}
