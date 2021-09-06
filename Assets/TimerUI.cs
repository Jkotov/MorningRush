using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private float timeToFail;
    public float Timer { get; private set; }
    private Text _text;
    private IFormatProvider _format;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<UnityEngine.UI.Text>();
        _format = new CultureInfo("en-US");
    }

    // Update is called once per frame
    void Update()
    {
        Timer = timeToFail - Time.timeSinceLevelLoad;
        if (Timer < 0)
            SceneManager.LoadScene("StartScene");
        _text.text = Timer.ToString("F", _format);
    }
}
