using UnityEngine;

public class Game : MonoBehaviour {
    private UIController uiController = null!;

    void Awake() => uiController = FindObjectOfType<UIController>();

    void Start() {
        uiController.SetActive<MainUI>(true);
    }
}
