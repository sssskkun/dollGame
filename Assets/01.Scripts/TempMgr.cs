using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMgr : MonoBehaviour
{

	public GameObject[] floor;
	public GameObject[] Cube;
	public GameObject[] Cylinder;
    public float pushPower = 100f;

    public float Speed;
    public bool triggerBar = false;
    public int moveTime;
    public bool pushBar = false;

	public float forceValue;
	float time = 0.0f;


	void Start()
    {
        GameObject.Find("PowerCam").GetComponent<Camera>().enabled = false;
        Cylinder[0].transform.position = new Vector3(0,0,-5);
        
		for(int i = 0; i < Cube.Length; ++i)
		{

			if(0 == i%2 )
			{
				asd(Cube[i]);
			}
		}

	}

	void asd(GameObject _gameObject)
	{
		_gameObject.transform.position = new Vector3(1, _gameObject.transform.position.y, _gameObject.transform.position.z);
	}

    int i = 0;
    int swit = 1;

    void moveCylinder(GameObject _gameObject)
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * Speed * Time.smoothDeltaTime;
        v = v * Speed * Time.smoothDeltaTime;

        _gameObject.transform.Translate(Vector3.right * h, Space.World);
        _gameObject.transform.Translate(Vector3.up * v, Space.World);



		if (Input.GetKey(KeyCode.Space))
        {            
            GameObject.Find("GameCam").GetComponent<Camera>().enabled = false;
            GameObject.Find("PowerCam").GetComponent<Camera>().enabled = true;
            GameObject.Find("Sliding Area").GetComponent<PowerBar>().moveStop = false;
        }

        if (triggerBar)
        {
			_gameObject.transform.position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y, _gameObject.transform.position.z + Time.deltaTime);

		}

        if(pushBar)
        {
			time += Time.deltaTime;

			if(time < 1.0f)
			{
				_gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceValue, ForceMode.Force);
			}
			else if(time >1.0f)
			{
				triggerBar = false;
				_gameObject.GetComponent<Rigidbody>().Sleep();
				_gameObject.transform.position = new Vector3(0, 0, -3);

			}




			//if(_gameObject.transform.position.z > -0.5)
			//{
			//    swit = -1;

			//}
			//_gameObject.transform.position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y, _gameObject.transform.position.z + Time.smoothDeltaTime * swit);
			//if (_gameObject.transform.position.z < -3)
			//{
			//    _gameObject.GetComponent<Rigidbody>().Sleep();
			//    pushBar = false;
			//    i = 0;
			//    swit = 1;
			//}
			//i++;


		}
		if (Input.GetKey(KeyCode.Backspace))
        {
            triggerBar = false;
            _gameObject.transform.position = new Vector3(0, 0, -3);
            _gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            _gameObject.GetComponent<Rigidbody>().Sleep();

			time = 0.0f;

		}
    }


	public void OntriggerBarStart()
	{
		triggerBar = true;
	}

    private void Update()
    {
		moveCylinder(Cylinder[0]);
    }
}

