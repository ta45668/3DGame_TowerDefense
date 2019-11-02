using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceUI : MonoBehaviour
{
    private static bool EndGamebool;
    public GameObject pauseScreenUI;
    private void Start()
    {
        EndGamebool = false;
    }

    private void Update()
    {
        if (EndGamebool)
            return;
        if (HP.totalHP <= 0)
        {
            EndGamebool = true;
            StopTime(pauseScreenUI);
        }
    }

    private void StopTime(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry(GameObject ui)
    {
        StopTime(ui);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(GameObject ui)
    {
        StopTime(ui);
        SceneManager.LoadScene("主畫面");
    }
}
