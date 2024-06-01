using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Save.readGoodsRecordFile();
        GoodsManager.GoodsInit();
    }
}
