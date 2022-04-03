using UnityEngine;

public class Island : MonoBehaviour {
    [SerializeField] private Cell cellPrefab = null!;

    private float cellHeight;

    void Awake() => cellHeight = cellPrefab.transform.localScale.y;

    public void NewCellOn(Cell cell) {
        var position = cell.transform.position;
        position.y += cellHeight;
        Instantiate(cellPrefab, position, Quaternion.identity, transform);
    }
}
