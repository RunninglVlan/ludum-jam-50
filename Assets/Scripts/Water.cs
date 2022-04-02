using UnityEngine;
using NaughtyAttributes;

public class Water : MonoBehaviour {

    [SerializeField]
    private float step = 0.5f;

    void Update() {

    }

    public void raiseLevelInRealTime()
    {
        var thisTransform = transform;
        var position = thisTransform.position;
        position.y += Time.deltaTime;
        thisTransform.position = position;
    }

    [Button]
    public void raiseLevel()
    {
        this.transform.position += new Vector3(0, step, 0);;
    }
}
