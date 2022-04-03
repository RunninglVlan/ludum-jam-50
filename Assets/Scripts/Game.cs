using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public event Action TurnEnded = delegate { };

    private UIController uiController = null!;
    private CameraControls controls = null!;
    private PlayerInput input = null!;

    void Awake() {
        uiController = FindObjectOfType<UIController>();
        controls = FindObjectOfType<CameraControls>();
        input = FindObjectOfType<PlayerInput>();
    }

    void Start() => ShowStart();

    private void ShowStart() {
        SetActiveControls(false);
        uiController.Show<StartUI>();
    }

    public void StartGame() {
        SetActiveControls(true);
        uiController.Show<MainUI>();
    }

    private void SetActiveControls(bool value) {
        controls.enabled = value;
        input.enabled = value;
    }

    public void EndTurn() {
        var islandDrowned = false; // TODO: Implement logic
        if (!islandDrowned) {
            TurnEnded();
        } else {
            ShowEnd();
        }
    }

    private void ShowEnd() {
        SetActiveControls(false);
        uiController.Show<EndUI>(end => end.SetDays(2)); // TODO: Implement count
    }
}
