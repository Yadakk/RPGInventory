using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemVoid : MonoBehaviour
{
    private Button _button;
    private Transform _slot;
    private Slot _slotComp;
    private static ItemVoid _instance;

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
        _instance = this;

        _button = transform.GetChild(0).GetComponent<Button>();
        _slot = transform.GetChild(1);
        _slotComp = _slot.GetComponent<Slot>();

        _button.onClick.AddListener(OnVoidItem);
    }
    #endregion

    private void OnVoidItem()
    {
        if (_slot.childCount > 1)
        {
            Destroy(_slot.GetChild(1).gameObject);
        }
    }

    public static void VoidItemStatic(GameObject obj)
    {
        _instance.OnVoidItem();
        _instance._slotComp.Insert(obj);
    }
}
