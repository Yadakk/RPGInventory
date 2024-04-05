using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    void Start()
    {
        BundleContainer.Init();
        Inventory.Init();
    }
}
