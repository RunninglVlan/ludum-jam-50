using UnityEngine.UIElements;

public class MainUI : UI {
    private Label resources = null!;

    protected override void Awake() {
        base.Awake();
        resources = documentRoot.Q<Label>("resources");
        FindObjectOfType<ResourceManager>().ResourcesUpdated += SetResources;
        var game = FindObjectOfType<Game>();
        documentRoot.Q<Button>("end-turn").clicked += game.EndTurn;
    }

    private void SetResources(int count) => resources.text = count.ToString();
}
