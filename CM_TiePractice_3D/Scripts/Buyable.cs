using Godot;
using System;

public partial class Buyable : Node3D {

	[Export] private int cost;

	public void Buy(MoneyHUD money) {
		money.Money -= cost;

		this.QueueFree();
	}

}
