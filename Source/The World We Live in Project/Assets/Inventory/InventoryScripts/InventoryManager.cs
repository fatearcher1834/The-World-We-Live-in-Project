using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //遊戲中獲得道具時，透過此類別將道具增加至玩家背包
    public static InventoryManager instance;
    public Inventory myBag;
    //public Slot slotPrefab;
    public GameObject slotGrid;
    public GameObject emptySlot;
    public Text itemInfo;

    public List<GameObject> slots = new List<GameObject>();

    public Slot test;


    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    /*public  static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfo.text = "";
    }
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfo.text = itemDescription;
    }
    public static void RefreshItem()
    {
        //將slotGrid的子物件全部破壞
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot,instance.slotGrid.transform));
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);

      

        }




    }




}
