using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour
{
    public Action<int> myAction;
    void Start()
    {
        myAction += DebugNumber;
        myAction += DebugString;
        myAction?.Invoke(7);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DebugNumber(int q)
    {
        q++;
        Debug.Log(q);
    }
    void DebugString(int a)
    {
        a *= 2;
        Debug.Log(a);
    }
    void a (Action myAction){
        
    }
}
