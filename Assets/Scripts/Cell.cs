using UnityEngine;

public class Cell : MonoBehaviour
{
    private static readonly int COLOR = Shader.PropertyToID("_Color");

    [SerializeField]
    public bool isDrowned;
    [SerializeField] 
    private GameObject selection = null!;
    [SerializeField]
    private Gradient gradient = null!;

    private Material material = null!;
    private Water water = null!;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        water = FindObjectOfType<Water>();

        material.SetColor(COLOR, gradient.Evaluate(0.9f));
    }

    void Update()
    {
        //DrownCell();
        //ChangeCellColor();
    }

    public void ChangeCellColor() 
    {
        var cellHeight = transform.position.y;
        if (!isDrowned)
        {
            if (cellHeight < 0.5)
            {
                material.SetColor(COLOR, Color.green);
            }
            else if (cellHeight > 0.5 & cellHeight < 1)
            {
                material.SetColor(COLOR, Color.yellow);
            }
            else if (cellHeight > 1 & cellHeight < 1.5)
            {
                material.SetColor(COLOR, Color.red);
            }
            else
            {
                material.SetColor(COLOR, Color.blue);
            }
        }
        else 
        {
            material.SetColor(COLOR, Color.blue);
        }
    }

    public void DrownCell()
    {
        if (water.transform.position.y > transform.position.y)
        {
            isDrowned = true;
        }
    }

    public void Deselect() => selection.SetActive(false);
    public void Select() => selection.SetActive(true);
}
