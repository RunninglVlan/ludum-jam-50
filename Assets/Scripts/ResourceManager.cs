using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public event Action<int> ResourcesUpdated = delegate { };

    private int counter;

    void Awake() {
        FindObjectOfType<Game>().TurnEnded += CollectTurnResources;
    }

    private void CollectTurnResources()
    {
        foreach (var cell in FindObjectsOfType<Cell>()) {
            if (cell.GotResources && !cell.isDrowned) {
                counter++;
            }
        }

        ResourcesUpdated(counter);
    }
}
