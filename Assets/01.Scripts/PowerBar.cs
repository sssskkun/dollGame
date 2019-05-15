using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject HitBar;
    public GameObject HitArea;
    // Start is called before the first frame update
    void Start()
    {
        randPos(HitArea);
    }
    void randPos(GameObject _gameObject)
    {
        _gameObject.GetComponent<RectTransform>().localPosition = new Vector3(Random.value * 50,0,0);
    }
    // Update is called once per frame
    int i = 0;
    float move = 0;
    bool moveBack = false;
    void moveBar(GameObject _gameObject)
    {
        move = i * moveSpeed / 1000;
        if(move > 1)
        {
            moveBack = true;
        }
        if(move < 0.01)
        {
            moveBack = false;
        }

        _gameObject.GetComponent<RectTransform>().anchorMin = new Vector3(move, 0, 0);
        _gameObject.GetComponent<RectTransform>().anchorMax = new Vector3(move, 0, 0);

        if (moveBack == true)
        {
            i--;
        }
        else
        {
            i++;
        }
    }
    void barchk()
    {

    }
    
    void Update()
    {
        moveBar(HitBar);
    }
}
