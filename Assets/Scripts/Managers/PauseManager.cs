using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMune;

    public void OpenPauseMenu()
    {
        Time.timeScale = pauseMune.activeSelf ? 1 : 0;
        pauseMune.SetActive(!pauseMune.activeSelf);
    }

    public void Continue()
    {
        pauseMune.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
