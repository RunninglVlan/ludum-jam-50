using UnityEngine;

public class Water : MonoBehaviour {
    void Update() {
        var thisTransform = transform;
        var position = thisTransform.position;
        position.y += Time.deltaTime;
        thisTransform.position = position;
    }
}
