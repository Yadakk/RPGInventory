using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemVoid : MonoBehaviour
{
    private Button _button;
    private Transform _slot;

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
}
