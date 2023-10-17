using Godot;
using System;

public partial class CharacterTie : Node {

	private Node currentTie;

	private void OnTieChanged(String tiePath) {
		currentTie?.QueueFree();

		PackedScene newTie = GD.Load<PackedScene>(tiePath);
		currentTie = newTie.Instantiate();
		AddChild(currentTie);
	}

}
