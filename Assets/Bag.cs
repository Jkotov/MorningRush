using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bag : MonoBehaviour
{
    [SerializeField] private int itemsForWin;
    [SerializeField] private GameObject openBag;
    [SerializeField] private float openBagTime;
    private SpriteRenderer _openSprite;
    private int _curItems;
    // Start is called before the first frame update
    void Start()
    {
        _openSprite = openBag.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _curItems++;
            if (_curItems >= itemsForWin)
                Win();
            _openSprite.enabled = false;
            StartCoroutine(ReopenBag());
        }
    }

    private void Win()
    {
        DontDestroyOnLoad(GameObject.Find("Timer"));
        GameObject.Find("Timer").GetComponent<TimerScript>().Time =
            GameObject.Find("TimerText").GetComponent<TimerUI>().Timer;
        SceneManager.LoadScene("EndScene");
    }

    private IEnumerator ReopenBag()
    {
        yield return new WaitForSeconds(openBagTime);
        _openSprite.enabled = true;
    }
}
