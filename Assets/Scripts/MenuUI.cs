using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [Header("UI Refs")]
    public TMP_Text welcomeText;          // WelcomeText (TMP)
    public TMP_InputField nameInput;      // NameInput (TMP)
    public Button goButton;               // GoButton (Unity UI)
    public Button level1Button;           // Level1Button
    public Button level2Button;           // Level2Button
    public Button level3Button;           // Level3Button

    [Header("Scenes")]
    public string level1SceneName = "SampleScene";

    private string playerName = "";

    void Start()
    {
        welcomeText.text = "Welcome! Please enter your name.";
        level1Button.interactable = false;
        level2Button.interactable = false;
        level3Button.interactable = false;

        goButton.onClick.AddListener(OnGoClicked);
        level1Button.onClick.AddListener(OnLevel1Clicked);
    }

    public void OnGoClicked()
    {
        playerName = nameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            welcomeText.text = "Please type your name first.";
            level1Button.interactable = false;
            return;
        }

        welcomeText.text = $"Welcome, {playerName}! Level 1 is unlocked.";
        level1Button.interactable = true;
    }

    public void OnLevel1Clicked()
    {
        SceneManager.LoadScene(level1SceneName);
    }
}
