using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    void Start()
    {
        ActiveCanvas.InitAll();
        BundleContainer.Init();
        ItemDrag.InitAll();
        RandomItemCreator.InitAll();
        ItemVoid.InitAll();
        Inventory.InitAll();
        Tooltip.InitAll();
    }
}
