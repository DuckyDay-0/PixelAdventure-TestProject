using Godot;
using System;

public partial class ScoreRoomFinal : Node2D
{
    private Label fruitLabel;
    private Label deathCounter;

    public override void _Ready()
    {
        fruitLabel = GetNode<Label>("labels/bananaScore");
        deathCounter = GetNode<Label>("labels/deathScore");
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        deathCounter.Text = $"Death Couter: {Global.Instance.deathCounter}";
        fruitLabel.Text = $"Fruit Collected: {Global.Instance.fruitCounter}";
    }
}
