using Godot;
using Godot.Collections;
using System;

public partial class PurchaseRay : RayCast3D {

	[Export] private MoneyHUD money;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		base._Process(delta);

		if (Input.IsMouseButtonPressed(MouseButton.Left)) {

			
			GodotObject colliderObj = this.GetCollider();
			if (colliderObj != null && colliderObj is Buyable buyableObject) {
				buyableObject.Buy(money);
			}

		}

	}

}
