using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject draggingItem = null;
    private Transform itemLisTr;
    private Transform inventoryTr;

    void Start()
    {
        inventoryTr = GameObject.Find("Inventory").transform;
        itemLisTr = GameObject.Find("ItemList").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       draggingItem = this.gameObject;
       GetComponent<CanvasGroup>().blocksRaycasts = false;
       transform.SetParent(inventoryTr);
    }

    public void OnDrag(PointerEventData eventData)
    {
       this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingItem = null;
       GetComponent<CanvasGroup>().blocksRaycasts = true;

       if(transform.parent ==inventoryTr)
       {
           transform.SetParent(itemLisTr);
       }
    }

  
}
