using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    private new Camera camera = null!;
    private Cell? previousCell;

    void Start() => camera = Camera.main!;

    void Update() {
        var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out var hitInfo, 100) || !hitInfo.transform.TryGetComponent<Cell>(out var cell)) {
            DeselectPrevious();
            return;
        }

        if (previousCell == cell) {
            return;
        }

        DeselectPrevious();

        cell.Select();
        previousCell = cell;
    }

    private void DeselectPrevious() {
        if (previousCell) {
            previousCell!.Deselect();
        }
        previousCell = null;
    }
}
