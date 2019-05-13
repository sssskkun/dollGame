using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMgr : MonoBehaviour
{

	public GameObject[] floor;
	public GameObject[] Cube;
	public GameObject[] Cylinder;

	void Start()
    {
		Cylinder[0].transform.position = Vector3.zero;

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
}
