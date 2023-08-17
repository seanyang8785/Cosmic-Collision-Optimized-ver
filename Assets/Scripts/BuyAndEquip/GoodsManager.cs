using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

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
    static bool first = true;
    void Awake()
    {
        if(first)
        {
            List<string> names = new List<string>(){"NB","SG","STL","SEL","SB","TV","TF","ES","SS","QS","EO"};
            List<int> statuses = new List<int>(){2,0,0,0,0,0,0,0,0,0,0};
            List<int> prices = new List<int>(){0,10,10,20,20,30,40,40,50,50,60};
            List<float> cds = new List<float>(){0.3f,0.5f,0.75f,0.75f,0.75f,10,15,15,15,20,25};
            List<int> difficultyCounts = new List<int>(){1,2,2,3,3,1,2,2,3,3,4};

            for(int i = 0;i < names.Count;i ++){
                goods_info good_info_temp = new goods_info();
                
                good_info_temp.price = prices[i];
                good_info_temp.status = statuses[i];
                good_info_temp.cd = cds[i];
                good_info_temp.difficultyCount = difficultyCounts[i];
                 
                goods.Add(names[i],good_info_temp);
                // Debug.Log(names[i]+" " +goods[names[i]].cd.ToString());
            }
            first = false;
        }
        // Debug.Log(first); 
        // Debug.Log(goods["QS"].status); 
    }
}
