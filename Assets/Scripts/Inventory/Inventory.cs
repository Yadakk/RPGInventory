using UnityEngine;
using UnityEngine.Events;
using JsonSaverLib;
using System;
using Unity.VisualScripting;
using System.IO;

public class Inventory : MonoBehaviour
{
    [SerializeField] private string _savePath;
    [SerializeField] private int _slots;
    [SerializeField] private UnityEngine.Object _slotPrefab;
    [SerializeField] private UnityEngine.Object _itemPrefab;

    [NonSerialized] private Slot[] _slotScripts;

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
        _slotScripts = new Slot[_slots];

        for (int i = 0; i < _slots; i++)
        {
            _slotScripts[i] = Instantiate(_slotPrefab, transform).GetComponent<Slot>();
        }

        Load();
    }
    #endregion

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        InventoryData invData = new(_slots);

        for (int i = 0; i < _slots; i++)
        {
            invData.Items[i] = _slotScripts[i].ItemInside;
        }
        
        Saver.Save(_savePath, invData);
    }

    private void Load()
    {
        if(File.Exists(Application.streamingAssetsPath + _savePath))
        {
            InventoryData invData = Saver.Load<InventoryData>(_savePath);

            for (int i = 0; i < _slots; i++)
            {
                if (invData.Items[i].Name != "")
                {
                    _slotScripts[i].GetComponent<Slot>().ItemInside = invData.Items[i];

                    var item = Instantiate(_itemPrefab, _slotScripts[i].transform) as GameObject;
                    item.GetComponent<RectTransform>().anchoredPosition = default;

                    var info = item.GetComponent<ItemInfo>();
                    var drag = item.GetComponent<ItemDrag>();

                    info.Init();
                    info.SetInfo(invData.Items[i]);

                    drag.Init();
                    drag.IsInsideSlot = true;
                }
            }
        }
    }

    private class InventoryData
    {
        public ItemData[] Items;

        public InventoryData(int slots) => Items = new ItemData[slots];
    }
}