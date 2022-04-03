using UnityEngine;

public class UIController : MonoBehaviour {
    private UI[] uis = null!;

    void Awake() => uis = FindObjectsOfType<UI>(includeInactive: true);

    public void SetActive<T>(bool value) where T: UI {
        foreach (var ui in uis) {
            ui.SetActive(false);
            if (ui is T) {
                ui.SetActive(value);
            }
        }
    }
}
