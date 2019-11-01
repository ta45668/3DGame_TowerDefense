using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 關卡管理 : MonoBehaviour
{
    private static bool EndGamebool;

    public GameObject gameoverUI;

    void Start()
    {
        EndGamebool = false;
    }
    void Update()
    {
        if (EndGamebool)
            return;
        /*if (分數.主塔血量 <= 0)
        {
            EndGame();
        }*/
    }

    void EndGame()
    {
        EndGamebool = true;
        時間(gameoverUI);
    }

    public void 時間(GameObject ui)
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
        時間(ui);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu(GameObject ui)
    {
        時間(ui);
        SceneManager.LoadScene("主畫面");
    }
}
