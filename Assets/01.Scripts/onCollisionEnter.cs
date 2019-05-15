using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionEnter : MonoBehaviour
{
    public TempMgr _tempMgr;
    private void Awake()
    {
        _tempMgr = GameObject.Find("TempMgr").GetComponent<TempMgr>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.GetComponent<Transform>().position = new Vector3();
        Debug.Log(collision.gameObject.GetComponent<Transform>().position);
        Debug.Log(collision.gameObject.name);
    }
}
