using UnityEngine.UIElements;

public class MainUI : UI {
    protected override void Awake() {
        base.Awake();
        var game = FindObjectOfType<Game>();
        documentRoot.Q<Button>("end-turn").clicked += game.EndTurn;
    }
}
