using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public event Action<int> ResourcesUpdated = delegate { };

    [SerializeField] private int counter = 25;

    void Awake() {
        FindObjectOfType<Game>().TurnEnded += CollectTurnResources;
    }

    void Start() => ResourcesUpdated(counter);

    private void CollectTurnResources()
    {
        foreach (var cell in FindObjectsOfType<Cell>()) {
            if (cell.GotResources && !cell.isDrowned) {
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
