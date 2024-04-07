using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetBundleLib
{
    public static class AssetGetter
    {
        public static T[] GetAssets<T>(AssetBundle bundle) where T : Object
        {
            T[] assets = bundle.LoadAllAssets<T>();
            return assets;
        }

        public static T GetAsset<T>(AssetBundle bundle, string name) where T : Object
        {
            T asset = bundle.LoadAsset<T>(name);
            return asset;
        }
    }

    public static class AssetUtility
    {
        public static void GetFromBundle<T>(AssetBundle bundle, ref T obj) where T : Object
        {
            obj = AssetGetter.GetAsset<T>(bundle, obj.name);
        }
    }
}