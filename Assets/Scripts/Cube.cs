using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private bool isDrowned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drownCube();
        changeCubeColor();
    }

    public void changeCubeColor() 
    {
        var cubeRenderer = GetComponent<Renderer>();
        var cubeHeight = transform.position.y;
        if (!isDrowned)
        {
            if (cubeHeight < 0.5)
            {
                cubeRenderer.material.SetColor("_Color", Color.green);
            }
            else if (cubeHeight > 0.5 & cubeHeight < 1)
            {
                cubeRenderer.material.SetColor("_Color", Color.yellow);
            }
            else if (cubeHeight > 1 & cubeHeight < 1.5)
            {
                cubeRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                cubeRenderer.material.SetColor("_Color", Color.blue);
            }
        }
        else 
        {
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }

    }

    public void drownCube()
    {
        var water = GameObject.Find("Water");
        if (water.transform.position.y > this.transform.position.y)
        {
            isDrowned = true;
        }
    }
}
