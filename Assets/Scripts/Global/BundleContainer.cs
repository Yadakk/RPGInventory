using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BundleContainer
{
    private static string _path = Application.streamingAssetsPath + "/game";
    public static AssetBundle Bundle;

    public static void Init()
    {
        Bundle = AssetBundle.LoadFromFile(_path);
    }
}