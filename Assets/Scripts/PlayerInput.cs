using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    [SerializeField] private Cell cellPrefab = null!;

    private new Camera camera = null!;
    private Cell? selectedCell;

    void Start() => camera = Camera.main!;

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

        var cellTransform = selectedCell.transform;
        var position = cellTransform.position;
        position.y += cellTransform.localScale.y;
        Instantiate(cellPrefab, position, Quaternion.identity);
    }
}
