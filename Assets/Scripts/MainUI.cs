using UnityEngine.UIElements;

public class MainUI : UI {
    private Label resources = null!;
    private Button endTurn = null!;

    protected override void Awake() {
        base.Awake();
        resources = documentRoot.Q<Label>("resources");
        FindObjectOfType<ResourceManager>().ResourcesUpdated += SetResources;
        var game = FindObjectOfType<Game>();
        game.TurnEnded += DisableEndTurn;
        endTurn = documentRoot.Q<Button>("end-turn");
        endTurn.clicked += game.EndTurn;
        FindObjectOfType<Water>().Raised += EnableEndTurn;
    }

    private void SetResources(int count) => resources.text = count.ToString();
    private void DisableEndTurn() => endTurn.SetEnabled(false);
    private void EnableEndTurn(float _) => endTurn.SetEnabled(true);
}
