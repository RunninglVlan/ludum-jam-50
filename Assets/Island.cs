using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Island : MonoBehaviour {
    public event Action Drowned = delegate { };

    [SerializeField] private Cell cellPrefab = null!;
    [SerializeField] private int size = 5;
    [SerializeField] public int maxHeight = 4;

    public float CellHeight { get; private set; }
    private readonly List<Cell> cells = new();
    public IEnumerable<Cell> DryCells => cells.Where(it => !it.isDrowned);

    void Awake() {
        FindObjectOfType<Water>().Raised += DrownCells;
        CellHeight = cellPrefab.transform.localScale.y;

        var center = (float)size / 2 - .5f;
        var centerPosition = new Vector2(center, center);
        for (var x = 0; x < size; x++) {
            for (var z = 0; z < size; z++) {
                var maxCellHeight = maxHeight + 1;
                maxCellHeight -= (int)Vector2.Distance(new Vector2(x, z), centerPosition);
                PlaceCellsAt(x - center, Random.Range(0, maxCellHeight), z - center);
            }
        }
    }

    private void PlaceCellsAt(float x, int maxCellHeight, float z) {
        var currentCell = NewCellAt(new Vector3(x, 0, z));
        for (var height = 1; height < maxCellHeight + 1; height++) {
            var cell = NewCellOn(currentCell);
            currentCell = cell;
        }
    }

    public Cell NewCellOn(Cell cell) {
        cell.DisableSelection();
        var position = cell.transform.position;
        position.y += CellHeight;
        return NewCellAt(position);
    }

    private Cell NewCellAt(Vector3 position) {
        var cell = Instantiate(cellPrefab, position, Quaternion.identity, transform);
        cells.Add(cell);
        return cell;
    }

    private void DrownCells(float waterHeight) {
        var drowned = 0;
        foreach (var cell in cells) {
            if (!cell.isDrowned) {
                cell.DrownCell(waterHeight);
            }
            if (cell.isDrowned) {
                drowned++;
            }
        }

        if (drowned == cells.Count) {
            Drowned();
        }
    }
}
