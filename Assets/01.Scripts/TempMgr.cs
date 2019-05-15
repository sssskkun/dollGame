using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMgr : MonoBehaviour
{

	public GameObject[] floor;
	public GameObject[] Cube;
	public GameObject[] Cylinder;

    public float Speed;
    public bool isflag = false;

    void Start()
    {
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
            isflag = true;
        }
        if (isflag)
        {
            _gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 300);

        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            isflag = false;
            _gameObject.transform.position = new Vector3(0, 0, -3);
            _gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            _gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
    private void Update()
    {
        moveCylinder(Cylinder[0]);        
    }
}

