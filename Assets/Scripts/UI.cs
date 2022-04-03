using UnityEngine;
using UnityEngine.UIElements;

public abstract class UI : MonoBehaviour {
    [SerializeField] private UIDocument document = null!;

    protected VisualElement documentRoot = null!;

    protected virtual void Awake() {
        document.gameObject.SetActive(true);
        documentRoot = document.rootVisualElement;
        SetActive(false);
    }

    public void SetActive(bool value) {
        documentRoot.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
