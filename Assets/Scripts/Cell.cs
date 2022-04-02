using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool isDrowned;

    Material cellMaterial;
    GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        cellMaterial = GetComponent<Renderer>().material;
        water = GameObject.Find("Water");
    }

    // Update is called once per frame
    void Update()
    {
        DrownCube();
        ChangeCubeColor();
    }

    public void ChangeCubeColor() 
    {
        var cubeHeight = transform.position.y;
        if (!isDrowned)
        {
            if (cubeHeight < 0.5)
            {
                cellMaterial.SetColor("_Color", Color.green);
            }
            else if (cubeHeight > 0.5 & cubeHeight < 1)
            {
                cellMaterial.SetColor("_Color", Color.yellow);
            }
            else if (cubeHeight > 1 & cubeHeight < 1.5)
            {
                cellMaterial.SetColor("_Color", Color.red);
            }
            else
            {
                cellMaterial.SetColor("_Color", Color.blue);
            }
        }
        else 
        {
            cellMaterial.SetColor("_Color", Color.blue);
        }

    }

    public void DrownCell()
    {
        if (water.transform.position.y > this.transform.position.y)
        {
            isDrowned = true;
        }
    }
}
