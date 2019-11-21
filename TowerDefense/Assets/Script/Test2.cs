using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [Header("滑鼠的位置")]
    public Vector2 mouse;//距離約10~150[-5~5]{95~430}
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
    }
}
