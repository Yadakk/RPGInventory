using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public ItemData ItemInside;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && transform.childCount < 2)
        {
            GameObject itemInMouse = eventData.pointerDrag;

            itemInMouse.GetComponent<RectTransform>().anchoredPosition = default;
            itemInMouse.transform.SetParent(transform, false);
            ItemInside = itemInMouse.GetComponent<ItemInfo>().Data;
            itemInMouse.GetComponent<ItemDrag>().IsInsideSlot = true;
        }
    }
}