using System.Collections;
using UnityEngine;

public class 視角控制 : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var deltaposition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-deltaposition.x * 1f, 0f, -deltaposition.y * 1f);
        }
    }
}
