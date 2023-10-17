using Godot;
using System;

public partial class TieController : Node3D {

	[Export] private string[] tiePaths;
	[Export] private float turnSpeed = 1;

	[Signal]
	public delegate void OnTieChangedEventHandler();

	private int currentTie = 0;
	private int targetTie = 0;

	private float timeUntilComplete = 1;
	private float currentRotation;

	private float RadiansToTurn => Mathf.DegToRad(360f / tiePaths.Length);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		timeUntilComplete = -1;

		for (int i = 0; i < tiePaths.Length; i++) {
			PackedScene newTie = GD.Load<PackedScene>(tiePaths[i]);
			Node3D node = (Node3D)newTie.Instantiate();
			AddChild(node);
			Quaternion rotation = new Quaternion(Vector3.Up, Mathf.DegToRad(180) + i * -RadiansToTurn);

			node.Position = rotation * (Vector3.Forward * 2.5f);
			node.Rotation = rotation.GetEuler();
		}

		EmitSignal(SignalName.OnTieChanged, tiePaths[0]);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		if (currentTie != targetTie) {
			timeUntilComplete -= ((float) delta) * turnSpeed;

			if (timeUntilComplete <= 0) {
				Rotation = new Vector3(0, targetTie * RadiansToTurn, 0);

				//targetTie %= tieNumber;
				currentTie = targetTie;

				timeUntilComplete = -1;
			} else {
				float newRotation = Mathf.Lerp(targetTie * RadiansToTurn, currentRotation, timeUntilComplete);
				Rotation = new Vector3(0, newRotation, 0);
			}

		}
	}

	public void TurnClockwise() {
		currentTie = targetTie;
		targetTie++;

		currentRotation = Rotation.Y;

		timeUntilComplete = 1;

		EmitSignal(SignalName.OnTieChanged, tiePaths[currentTie % tiePaths.Length]);
	}

	public void TurnCounterClockwise() {
		currentTie = targetTie;
		targetTie--;

		currentRotation = Rotation.Y;

		timeUntilComplete = 1;

		int realTie = ((targetTie % tiePaths.Length) + tiePaths.Length) % tiePaths.Length;
		EmitSignal(SignalName.OnTieChanged, tiePaths[realTie]);
	}

	public String GetSelectedTie() {
		int realIndex = currentTie % tiePaths.Length;
		return tiePaths[realIndex];
	}
}
