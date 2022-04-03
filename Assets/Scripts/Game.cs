using UnityEngine;

public class Game : MonoBehaviour {
    private UIController uiController = null!;
    private CameraControls controls = null!;
    private PlayerInput input = null!;

    void Awake() {
        uiController = FindObjectOfType<UIController>();
        controls = FindObjectOfType<CameraControls>();
        input = FindObjectOfType<PlayerInput>();
    }

    void Start() => ShowStart();

    private void ShowStart() {
        controls.enabled = false;
        input.enabled = false;
        uiController.SetActive<StartUI>(true);
    }

    public void StartGame() {
        controls.enabled = true;
        input.enabled = true;
        uiController.SetActive<MainUI>(true);
    }
}
