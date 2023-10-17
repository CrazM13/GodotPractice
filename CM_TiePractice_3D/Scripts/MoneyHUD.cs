using Godot;
using System;

public partial class MoneyHUD : Label {

	private int _money;
	public int Money {
		get => _money;
		set {
			_money = value;

			Text = _money.ToString("F1");
		}
	}


	public override void _Ready() {
		Money = 100;
	}

}
