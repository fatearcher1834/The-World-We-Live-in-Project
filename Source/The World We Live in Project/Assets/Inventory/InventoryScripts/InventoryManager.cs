using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //遊戲中獲得道具時，透過此類別將道具增加至玩家背包

    public static InventoryManager instance;
    public Inventory myBag;
    public Slot slotPrefab;
    public GameObject slotGrid;
    public Text itemInfo;

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    public  static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfo.text = "";
    }
    public static void UpdateItemInfo(Item item)
    {
        instance.itemInfo.text = item.itemInfo;
    }
    public static void RefreshItem()
    {
        //將slotGrid的子物件全部破壞
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }


}
