using UnityEngine.UIElements;

public class StartUI : UI {
    protected override void Awake() {
        base.Awake();
        var game = FindObjectOfType<Game>();
        documentRoot.Q<Button>("play").clicked += game.StartGame;
    }
}
