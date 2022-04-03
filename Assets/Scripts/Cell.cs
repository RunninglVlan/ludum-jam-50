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
    private new Collider collider = null!;
    private Water water = null!;

    public bool GotResources => collider.enabled;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
        collider = GetComponent<Collider>();
        water = FindObjectOfType<Water>();
        var island = FindObjectOfType<Island>();

        var height = transform.position.y / island.CellHeight / island.maxHeight;
        material.SetColor(COLOR, gradient.Evaluate(height));
    }

    // TODO: This should be called on water raise
    public void DrownCell()
    {
        if (water.transform.position.y > transform.position.y)
        {
            material.SetColor(COLOR, Color.blue);
        }
    }

    public void Deselect() => selection.SetActive(false);
    public void Select() => selection.SetActive(true);
    public void DisableSelection() => collider.enabled = false;
}
