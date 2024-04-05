using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using AssetBundleLib;
using JsonSaverLib;
using System.IO;
using static BundleContainer;

public class Inventory : MonoBehaviour
{
    [SerializeField] private string _path;
    [SerializeField] private int _slots;
    public static List<Inventory> Instances = new();
    public List<Item> Items;
    public static Item Empty;

    private void Awake()
    {
        Instances.Add(this);
    }

    public static void Init()
    {
        Empty = AssetGetter<Item>.GetAsset(Bundle, "Empty");

        foreach (var instance in Instances)
        {
            instance.Load();
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < _slots; i++)
        {
            if (i >= Items.Count)
            {
                Items.Add(Empty);
            }

            var item = Items[i];
            var itemGO = Instantiate(item.ItemPrefab, transform) as GameObject;

            var itemImage = itemGO.GetComponent<Image>();
            var itemName = itemGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            var itemDamage = itemGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            var mbScript = itemGO.GetComponent<ItemMB>();

            switch (item.Rarity)
            {
                case Item.ERarity.Empty:
                    itemImage.color = Color.white;
                    break;

                case Item.ERarity.Common:
                    itemImage.color = Color.gray;
                    break;

                case Item.ERarity.Uncommon:
                    itemImage.color = Color.green;
                    break;

                case Item.ERarity.Rare:
                    itemImage.color = Color.cyan;
                    break;

                case Item.ERarity.Exclusive:
                    itemImage.color = Color.red;
                    break;

                case Item.ERarity.NearlyPerfect:
                    itemImage.color = Color.yellow;
                    break;
            }

            if (item.Rarity != Item.ERarity.Empty)
            {
                itemName.text = item.Name;
                itemDamage.text = "Dmg: " + item.Damage;

                mbScript.RelatedInventory = this;
                mbScript.RelatedPlace = i;
            }
        }
    }

    public void Save()
    {
        Saver.Save(_path, Items);
    }
    
    public void Load() 
    {
        if(File.Exists(_path))
            Items = Saver.Load<List<Item>>(_path);
        UpdateInventory();
    }
}