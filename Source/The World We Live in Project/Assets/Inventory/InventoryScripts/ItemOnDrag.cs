using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private Vector3 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;
        transform.SetParent(transform.parent.parent.parent); //parent.parent造成一開始拖動時會被Grid排列，所以設定3次par。
        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On: " + eventData.pointerCurrentRaycast.gameObject.name);
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //只有偵測的到滑鼠位置的時候可以改動層級與位置
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
            {
                //拖曳的道具與目標道具互換→位置與層級互換
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalPosition;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)" && eventData.pointerCurrentRaycast.gameObject.transform.childCount != 0)
            {
                //拖曳道具與沒有道具的slot互換
                //要先調整位置，若先調整父集，GetChild(0)會沒有東西。
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject.transform.position = originalPosition; 
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).gameObject.transform.SetParent(originalParent);

                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            }
            else
            {
                //其餘狀況都不允許改動層級與位置→設回原本層級與位置
                transform.SetParent(originalParent);
                transform.position = originalPosition;
            } 
        }
        else
        {
            transform.SetParent(originalParent);
            transform.position = originalPosition;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
