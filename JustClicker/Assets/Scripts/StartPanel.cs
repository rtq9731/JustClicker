using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : MonoBehaviour
{
    private void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
