using System;
using System.Collections;
using UnityEngine;

public class Water : MonoBehaviour {
    public event Action<float> Raised = delegate { };

    [SerializeField]
    private float step = 0.5f;
    [SerializeField]
    private float animationSeconds = .5f;

    private float elapsedTime;

    void Awake() {
        FindObjectOfType<Game>().TurnEnded += raiseLevel;
    }

    private void raiseLevel()
    {
        elapsedTime = 0;
        var start = transform.position;
        var end = start + new Vector3(0, step, 0);
        StartCoroutine(Raise());

        IEnumerator Raise() {
            while (elapsedTime < animationSeconds) {
                transform.position = Vector3.Lerp(start, end, elapsedTime / animationSeconds);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Raised(transform.position.y);
        }
    }
}
