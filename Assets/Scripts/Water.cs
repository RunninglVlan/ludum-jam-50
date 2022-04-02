using UnityEngine;

public class Water : MonoBehaviour {
    void Update() {
        var position = transform.position;
        position.y += Time.deltaTime;
        transform.position = position;
    }
}
