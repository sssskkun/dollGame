using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionEnter : MonoBehaviour
{
    public TempMgr _tempMgr;
    public Rigidbody _rigidbody;

    private void Awake()
    {
        _tempMgr = GameObject.Find("TempMgr").GetComponent<TempMgr>();
        _rigidbody = GameObject.Find("Cylinder").GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log(collision.gameObject.GetComponent<Transform>().position);
        Debug.Log(collision.gameObject.name);
        _rigidbody.Sleep();
    }
}
