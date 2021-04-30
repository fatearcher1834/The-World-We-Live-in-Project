using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour,IDragHandler
{
    RectTransform currentRect;

    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        currentRect.anchoredPosition += eventData.delta; //錨點位置 += 滑鼠上一幀數移動量
    }

}
