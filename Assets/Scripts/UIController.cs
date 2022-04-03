using System;
using UnityEngine;

public class UIController : MonoBehaviour {
    private UI[] uis = null!;

    void Awake() => uis = FindObjectsOfType<UI>(includeInactive: true);

    public void Show<T>(Action<T>? action = null) where T: UI {
        foreach (var ui in uis) {
            ui.SetActive(false);
            if (ui is T t) {
                ui.SetActive(true);
                action?.Invoke(t);
            }
        }
    }
}
