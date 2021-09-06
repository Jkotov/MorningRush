using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GetTimerEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = GameObject.Find("Timer").GetComponent<TimerScript>().Time
            .ToString("F", new CultureInfo("en-US"));
        Destroy(GameObject.Find("Timer"));
    }

}
