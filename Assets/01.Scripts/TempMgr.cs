using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMgr : MonoBehaviour
{

	public GameObject[] floor;
	public GameObject[] Cube;
	public GameObject Cylinder;
    public float pushPower = 10f;

    public float Speed;
    public bool triggerBar = false;
    public bool pushBar = false;
    public float directY = 0.11f;
    public float directX = 0.14f;
    bool keyFlag = true;
    float moveTime = 0f;

    enum pushBarStatus
    {
        ready,
        push,
        pull,
        stop,
        init
    }
    pushBarStatus barStatus;

    void Start()
    {
        if (GameObject.Find("PowerCam").GetComponent<Camera>().enabled == true)
        {
            GameObject.Find("PowerCam").GetComponent<Camera>().enabled = false;
        }
        Cylinder.transform.position = new Vector3(0,0,-5);
        barStatus = pushBarStatus.ready;

    }

	void asd(GameObject _gameObject)
	{
		_gameObject.transform.position = new Vector3(1, _gameObject.transform.position.y, _gameObject.transform.position.z);
	}

    void moveCylinder(GameObject _gameObject)
    {
        // 키 입력 받아서 제어하는 방법
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //h = h * Speed * Time.smoothDeltaTime;
        //v = v * Speed * Time.smoothDeltaTime;

        //_gameObject.transform.Translate(Vector3.right * h, Space.World);
        //_gameObject.transform.Translate(Vector3.up * v, Space.World);


        switch (barStatus)
        {
            case pushBarStatus.ready:
                if (_gameObject.transform.position.x > 7.5 || _gameObject.transform.position.x < -7.1)
                {
                    directX = -directX;
                }
                if (_gameObject.transform.position.y > 7 || _gameObject.transform.position.y < -1.5)
                {
                    directY = -directY;
                }
                if (pushBar)
                {
                    _gameObject.transform.Translate(Vector3.up * directY, Space.World);
                    moveTime += Time.deltaTime;
                    if(moveTime > 0.2)
                    {
                        keyFlag = true;
                    }
                }
                else
                {
                    _gameObject.transform.Translate(Vector3.right * directX, Space.World);
                }

                break;
            case pushBarStatus.push:
                //_gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushPower);
                _gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * 10;
                moveTime += Time.deltaTime;
                if (Time.deltaTime > 1)
                {
                    barStatus = pushBarStatus.pull;
                    moveTime = 0;
                }
                break;
            case pushBarStatus.pull:
                moveTime += Time.deltaTime;
                _gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * pushPower);
                if(Time.deltaTime > 1)
                {
                    barStatus = pushBarStatus.stop;
                    moveTime = 0;
                }
                break;
            case pushBarStatus.stop:
                _gameObject.GetComponent<Rigidbody>().Sleep();
                pushBar = false;
                keyFlag = true;
                break;
            case pushBarStatus.init:
                _gameObject.transform.position = new Vector3(0, 0, -5);
                pushBar = false;
                keyFlag = true;
                break;
        }

        if (Input.GetKey(KeyCode.Space) && keyFlag)
        {
            moveTime = 0;
            switch (barStatus)
            {
                case pushBarStatus.init:
                    barStatus = pushBarStatus.ready;
                    break;
                case pushBarStatus.stop:
                    barStatus = pushBarStatus.init;
                    break;                
                case pushBarStatus.ready:
                    if (pushBar)
                    {
                        barStatus = pushBarStatus.push;
                    }
                    pushBarOn();
                    break;
            }
            keyFlag = false;
        }
    }
    private void Update()
    {
        moveCylinder(Cylinder);        
    }
    public void pushBarOn()
    {
        pushBar = true;
    }
}

