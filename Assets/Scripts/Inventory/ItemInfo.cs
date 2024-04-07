using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public ItemData Data;

    private TextMeshProUGUI _nameUgui;
    private TextMeshProUGUI _dmgUgui;
    private Image _image;

    public void Init()
    {
        _nameUgui = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _dmgUgui = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _image = GetComponent<Image>();
    }

    public void SetInfo(ItemData data)
    {
        Data = data;

        _nameUgui.text = Data.Name;
        _dmgUgui.text = "Dmg: " + Data.Damage;

        switch (Data.Rarity)
        {
            case Item.ERarity.Common:
                _image.color = Color.gray;
                break;

            case Item.ERarity.Uncommon:
                _image.color = Color.green;
                break;

            case Item.ERarity.Rare:
                _image.color = Color.cyan;
                break;

            case Item.ERarity.Exclusive:
                _image.color = Color.red;
                break;

            case Item.ERarity.NearlyPerfect:
                _image.color = Color.yellow;
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Tooltip.ToggleTooltipStatic("Name: " + Data.Name + '\n' +
                                  "Damage: " + Data.Damage + '\n' +
                                  "Rarity: " + Data.Rarity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}
