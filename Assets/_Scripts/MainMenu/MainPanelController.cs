using UnityEngine;
using UnityEngine.UI;

public class MainPanelController : MonoBehaviour
{
    public Dropdown LevelDropdown;
    public InputField NameField;
    public Text StartButtonText;

    public void SetCurrentLevel()
    {
        var master = vp_MPMaster.Instance;
        switch (LevelDropdown.value)
        {
            case 0:
                master.CurrentLevel = "MainLevel";
                break;
            case 1:
                master.CurrentLevel = "Station";
                break;
            default:
                break;
        }
    }

    public void SetPlayerName(string name)
    {
        while (name.Length < 3)
        {
            name = "#" + name;
        }
        var mainmenu = vp_MPDemoMainMenu.Instance;
        mainmenu.SetPlayerName(name);
        NameField.text = name;
    }

    public void QuitGame()
    {
        Debug.LogWarning("Closing application!");
        Application.Quit();
    }

    public void StartGame()
    {
        var mainmenu = vp_MPDemoMainMenu.Instance;
        StartButtonText.text = mainmenu.StartGame();
    }
}
