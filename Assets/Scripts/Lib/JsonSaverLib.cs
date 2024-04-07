using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.JsonUtility;
using static System.IO.File;

namespace JsonSaverLib
{
    public static class Saver
    {
        public static void Save<T>(string path, T obj)
        {
            var json = ToJson(obj);
            WriteAllText(path, json);
        }

        public static T Load<T>(string path)
        {
            var json = ReadAllText(path);
            return FromJson<T>(json);
        }
    }
}