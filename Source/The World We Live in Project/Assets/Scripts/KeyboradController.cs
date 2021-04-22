using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboradController : MonoBehaviour
{
    //玩家鍵盤操作設定
    public GameObject playerBag;
    public bool isOpen;

    // Update is called once per frame
    void Update()
    {
        OpenPlayerBag();
    }

    //玩家鍵盤操作(背包)
    void OpenPlayerBag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            playerBag.SetActive(isOpen);
        }
    }
    public void ClosePlayerBag()
    {
        isOpen = false;
    }




}
