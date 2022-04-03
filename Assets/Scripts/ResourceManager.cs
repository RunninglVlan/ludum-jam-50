using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int totalCounter = 0;
    public int currentRoundCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectResources()
    {
        var cells = GameObject.Find("Island");

        foreach (Transform child in cells.transform)
        {
            if (!child.GetComponent<Cell>().isDrowned) 
            {
                currentRoundCounter++;
            }
        }
    }

    public void addThisTurnResources() 
    {
        totalCounter += currentRoundCounter;
        currentRoundCounter = 0;
    }

}
