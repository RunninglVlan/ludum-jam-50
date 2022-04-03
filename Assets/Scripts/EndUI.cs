using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndUI : UI {
    private Label days = null!;

    protected override void Awake() {
        base.Awake();
        days = documentRoot.Q<Label>("days");
        documentRoot.Q<Button>("retry").clicked += Restart;
    }

    private static void Restart() {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void SetDays(int value) => days.text = value.ToString();
}
