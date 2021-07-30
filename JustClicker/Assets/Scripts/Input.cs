using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    private void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0))
        {
            GetComponent<Counter>().Count--;
            GetComponent<ImageChanger>().HitAnimAndSound();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Insert))
        {
            GetComponent<Counter>().Count -= 256;
        }
    }
}
