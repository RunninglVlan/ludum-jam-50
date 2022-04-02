using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool isDrowned;
    [SerializeField] private GameObject selection = null!;

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
        DrownCell();
        ChangeCellColor();
    }

    public void ChangeCellColor() 
    {
        var cellHeight = transform.position.y;
        if (!isDrowned)
        {
            if (cellHeight < 0.5)
            {
                cellMaterial.SetColor("_Color", Color.green);
            }
            else if (cellHeight > 0.5 & cellHeight < 1)
            {
                cellMaterial.SetColor("_Color", Color.yellow);
            }
            else if (cellHeight > 1 & cellHeight < 1.5)
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

    public void Deselect() => selection.SetActive(false);
    public void Select() => selection.SetActive(true);
}
