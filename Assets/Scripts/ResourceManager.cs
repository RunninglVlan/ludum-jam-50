using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int totalCounter;
    private int turnCounter;

    public void CollectResources()
    {
        var island = FindObjectOfType<Island>();

        foreach (Transform child in island.transform)
        {
            if (!child.GetComponent<Cell>().isDrowned)
            {
                turnCounter++;
            }
        }
    }

    public void addThisTurnResources() 
    {
        totalCounter += turnCounter;
        turnCounter = 0;
    }
}
