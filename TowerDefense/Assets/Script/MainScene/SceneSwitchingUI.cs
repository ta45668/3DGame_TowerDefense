using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitchingUI : MonoBehaviour
{
    /// <summary>
    /// 切換關卡輸入關卡名
    /// </summary>
    /// <param name="SceneName"></param>
    public void Switching(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
