using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BundleContainer
{
    private static string _path = "Assets/AssetBundles/game";
    public static AssetBundle Bundle;

    public static void Init()
    {
        Bundle = AssetBundle.LoadFromFile(_path);
    }
}