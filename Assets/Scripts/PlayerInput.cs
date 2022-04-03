using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private int cellsPerTurn = 3;

    private new Camera camera = null!;
    private Island island = null!;
    private Cell? selectedCell;

    void Awake() {
        camera = Camera.main!;
        island = FindObjectOfType<Island>();
    }

    void Update() {
        SelectCell();
        PlaceCell();
    }

    private void SelectCell() {
        var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out var hitInfo, 100) || !hitInfo.transform.TryGetComponent<Cell>(out var cell)) {
            DeselectPrevious();
            return;
        }

        if (selectedCell == cell) {
            return;
        }

        DeselectPrevious();

        cell.Select();
        selectedCell = cell;
    }

    private void DeselectPrevious() {
        if (selectedCell) {
            selectedCell!.Deselect();
        }

        selectedCell = null;
    }

    private void PlaceCell() {
        if (selectedCell == null || !Mouse.current.leftButton.wasPressedThisFrame) {
            return;
        }

        if (cellsPerTurn == 0) {
            return;
        }

        island.NewCellOn(selectedCell);
        cellsPerTurn--;
    }
}
