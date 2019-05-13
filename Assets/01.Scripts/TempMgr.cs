using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMgr : MonoBehaviour
{

	public GameObject[] floor;
	public GameObject[] Cube;
	public GameObject[] Cylinder;

    public float Speed;
    public float thrust;

    void Start()
    {
		Cylinder[0].transform.position = new Vector3(0,0,-3);
        
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

        h *= Speed * Time.smoothDeltaTime;
        v *= Speed * Time.smoothDeltaTime;

        _gameObject.transform.Translate(Vector3.right * h);
        _gameObject.transform.Translate(Vector3.forward * v);

        if (Input.GetKey(KeyCode.Space))
        {
            //_gameObject.transform.Translate(Vector3.up * Time.smoothDeltaTime);
            _gameObject.GetComponent<Rigidbody>().AddForce(0,0,thrust,ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.Backspace)) _gameObject.transform.position = new Vector3(0,0,-3);
    }

    private void Update()
    {
        moveCylinder(Cylinder[0]);
        
    }
}
