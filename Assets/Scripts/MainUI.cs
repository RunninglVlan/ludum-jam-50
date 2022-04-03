using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : UI {
    protected override void Awake() {
        base.Awake();
        documentRoot.Q<Button>("end-turn").clicked += EndTurn;
    }

    private void EndTurn() {
        Debug.Log("TODO: End Turn");
    }
}
