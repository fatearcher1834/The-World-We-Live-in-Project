using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboradController : MonoBehaviour
{
    //���a��L�ާ@�]�w
    public GameObject playerBag;
    public bool isOpen;

    // Update is called once per frame
    void Update()
    {
        OpenPlayerBag();
    }

    //���a��L�ާ@(�I�])
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
