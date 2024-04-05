using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;

[CreateAssetMenu(fileName = "New Item", menuName = "SO/Item", order = 51)]
public class Item : ScriptableObject
{
    public string Name;
    public int Damage;
    public ERarity Rarity;
    public Object ItemPrefab;

    public enum ERarity
    {
        Empty,
        Common,
        Uncommon,
        Rare,
        Exclusive,
        NearlyPerfect,
    }
}