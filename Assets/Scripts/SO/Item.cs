using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;
using static Item;

[CreateAssetMenu(fileName = "New Item", menuName = "SO/Item", order = 51)]
public class Item : ScriptableObject
{
    public ItemData Data;

    public enum ERarity
    {
        Common,
        Uncommon,
        Rare,
        Exclusive,
        NearlyPerfect,
    }
}

[System.Serializable]
public class ItemData
{
    public string Name;
    public int Damage;
    public ERarity Rarity;
}