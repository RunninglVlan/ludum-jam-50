using UnityEngine.UIElements;

public class MainUI : UI {
    private Label resources = null!;

    protected override void Awake() {
        base.Awake();
        resources = documentRoot.Q<Label>("resources");
        // TODO: Uncomment when MonoBehaviour exists
        // var resourceManager = FindObjectOfType<ResourceManager>();
        // TODO: Remove when MonoBehaviour exists
        var resourceManager = new ResourceManager();
        resourceManager.ResourcesUpdated += SetResources;
        var game = FindObjectOfType<Game>();
        documentRoot.Q<Button>("end-turn").clicked += game.EndTurn;
    }

    private void SetResources(int count) => resources.text = count.ToString();

    // TODO: Delete when MonoBehaviour exists
    private class ResourceManager { public event System.Action<int> ResourcesUpdated = delegate { }; }
}
