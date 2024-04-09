using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debug : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Screen.width + " x " + Screen.height;
    }
}
