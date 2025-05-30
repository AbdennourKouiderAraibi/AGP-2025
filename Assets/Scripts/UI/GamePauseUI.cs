using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        optionsButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        Time.timeScale = 1.0f;
    }

    private void Start() {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);
    }
    private void Hide() {
        gameObject.SetActive(false);
    }
}
