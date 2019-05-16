using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    public TempMgr _tempMgr;
    public float moveSpeed = 1f;
    public GameObject HitBar;
    public GameObject HitArea;
    // Start is called before the first frame update
    public bool moveStop = false;

    float randArea = 0f;

    private void Awake()
    {
        _tempMgr = GameObject.Find("TempMgr").GetComponent<TempMgr>();
    }

    void Start()
    {
        randPos(HitArea);
    }
    void randPos(GameObject _gameObject)
    {
        randArea = Random.value * 140;
        _gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(randArea,0);
    }
    // Update is called once per frame
    int i = 0;
    float move = 0f;
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
        if (moveBack == true)
        {
            i--;
        }
        else
        {
            i++;
        }

        if (Input.GetKey(KeyCode.K))
        {            
            moveStop = true;
            i = 0;
            if (move * 140 > (randArea - 5f) && move * 140 < (randArea + 5f))
            {
                _tempMgr.pushPower = 100f;
                Debug.Log("YESSSSSSSSSSSSSSSSSSSSSSSSSSS");
            }
            else
            {
                _tempMgr.pushPower = 50f;
                Debug.Log("NNNNNNOOOOOOOOOOOOOOOOOOOOOOO");
            }
            GameObject.Find("PowerCam").GetComponent<Camera>().enabled = false;
            GameObject.Find("GameCam").GetComponent<Camera>().enabled = true;
            _tempMgr.triggerBar = true;
            move = 0.0f;
        }

        if (moveStop == false)
        {            
            _gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(move * 140, 0);
        }
    }

    void Update()
    {
        moveBar(HitBar);        
    }
}
