using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    MainMenuManager Instance;
    public AudioMixer audioMixer;
    public Canvas settingsMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
       SceneManager.LoadScene("Introduction");
    }

    public void OpenSettings()
    {
        settingsMenu.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.gameObject.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullscreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }
}
