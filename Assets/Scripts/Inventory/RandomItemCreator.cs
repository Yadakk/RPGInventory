using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using AssetBundleLib;

public class RandomItemCreator : MonoBehaviour
{
    [SerializeField] private Object _itemPrefab;

    private Button _button;
    private Transform _slot;
    private Item[] _randomItems;

    #region Initter
    private static UnityEvent _initAll = new();
    private void Awake()
    {
        _initAll.AddListener(OnInitAll);
    }
    public static void InitAll()
    {
        _initAll.Invoke();
    }
    private void OnInitAll()
    {
        _button = transform.GetChild(0).GetComponent<Button>();
        _slot = transform.GetChild(1);

        _button.onClick.AddListener(OnCreateRandomItem);

        _randomItems = AssetGetter.GetAssets<Item>(BundleContainer.Bundle);
    }
    #endregion

    private void OnCreateRandomItem()
    {
        if (_slot.childCount < 2)
        {
            GameObject item = Instantiate(_itemPrefab, _slot) as GameObject;
            ItemDrag drag = item.GetComponent<ItemDrag>();
            ItemInfo info = item.GetComponent<ItemInfo>();

            var randomItem = _randomItems[Random.Range(0, _randomItems.Length)].Data;

            drag.Init();

            info.Init();
            info.SetInfo(randomItem);

            item.GetComponent<RectTransform>().anchoredPosition = default;
            item.GetComponent<ItemDrag>().IsInsideSlot = true;
        }
    }
}
