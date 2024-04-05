using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMB : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public Inventory RelatedInventory;
    public int RelatedPlace;
    private static Coroutine _coroutine;

    public void OnDrag(PointerEventData eventData)
    {
        if (_coroutine == null)
        {
            RelatedInventory.Items[RelatedPlace] = Inventory.Empty;
            _coroutine = StartCoroutine(Dragging());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator Dragging()
    {
        while (true)
        {
            transform.position = Input.mousePosition;
            yield return null;
        }
    }
}
