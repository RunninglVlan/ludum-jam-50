using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public event Action<int> ResourcesUpdated = delegate { };

    [SerializeField] private int counter = 25;

    private Island island = null!;

    void Awake() {
        FindObjectOfType<Game>().TurnEnded += CollectTurnResources;
        island = FindObjectOfType<Island>();
    }

    void Start() => ResourcesUpdated(counter);

    private void CollectTurnResources()
    {
        foreach (var cell in island.DryCells) {
            if (cell.GotResources) {
                counter++;
            }
        }

        ResourcesUpdated(counter);
    }

    public bool Has(int count) => counter >= count;

    public void Take(int count) {
        counter -= count;
        ResourcesUpdated(counter);
    }
}
