using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 遊戲管理 : MonoBehaviour
{
    static 遊戲管理 instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this!=instance)
        {
            Destroy(gameObject);
        }
    }
}
