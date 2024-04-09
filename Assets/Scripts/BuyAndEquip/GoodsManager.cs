using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    public static bool spend = false;
    public struct goods_info{
        public int price;
        public int status;
        public float cd;
        public int difficultyCount;
    }
    public static Dictionary<string,goods_info> goods = new Dictionary<string,goods_info>(){};

    public static List<int> goods_count = new List<int>(){5,6};
    public static List<string> names = new List<string>(){"NB","SG","STL","SEL","SB","TV","TF","ES","SS","QS","EO"};
    public static List<int> statuses = new List<int>(){2,0,0,0,0,0,0,0,0,0,0};
    public static List<int> prices = new List<int>(){0,10,10,15,15,20,25,25,30,30,40};
    public static List<float> cds = new List<float>(){0.5f,1f,1f,1f,1.5f,10,15,15,15,20,40};
    public static List<int> difficultyCounts = new List<int>(){1,2,2,3,3,1,2,2,3,3,4};
    static bool first = true;
    void Awake()
    {
        if(first)
        {
            for(int i = 0;i < names.Count;i ++){
                goods_info good_info_temp = new goods_info
                {
                    price = prices[i],
                    status = statuses[i],
                    cd = cds[i],
                    difficultyCount = difficultyCounts[i]
                };

                goods.Add(names[i],good_info_temp);
                // Debug.Log(names[i]+" " +goods[names[i]].cd.ToString());
            }
            first = false;
        }
        // Debug.Log(first); 
        // Debug.Log(goods["QS"].status); 
    }
}
