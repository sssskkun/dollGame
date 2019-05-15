using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject HitBar;
    public GameObject HitArea;
    // Start is called before the first frame update
    float randArea = 0f;
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
    bool moveStop = false;
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
        if (moveStop == false)
        {
            _gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(move*140, 0);            
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

            if (move * 140 > (randArea - 5f) && move * 140 < (randArea + 5f))
            {
                Debug.Log("YESSSSSSSSSSSSSSSSSSSSSSSSSSS");
            }
            else
                Debug.Log("NNNNNNOOOOOOOOOOOOOOOOOOOOOOO");
        }
        if (Input.GetKey(KeyCode.L))
        {
            moveStop = false;
            move = 0.0f;
            i = 0;
        }
    }   
    
    
    void Update()
    {
        moveBar(HitBar);
    }
}
