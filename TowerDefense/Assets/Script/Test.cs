using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject[] hero = new GameObject[1];
    public GameObject[] heroCard = new GameObject[1];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void ShowHero(int number)
    {
        hero[number].SetActive(true);
        heroCard[number].SetActive(false);
    }

    public void Call()
    {
        //Debug.Log(123);
    }

}
