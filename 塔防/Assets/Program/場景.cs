using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 場景 : MonoBehaviour
{
    public void 關卡切換(string 關卡名)
    {
        SceneManager.LoadScene(關卡名);
    }
}
