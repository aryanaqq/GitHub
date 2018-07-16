using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsafeTest : MonoBehaviour {





	void Start () {
        unsafe
        {
            int a = 3;
            int* b = &a;
            print(String.Format("{0:X}", (int)b));
        }
    }
	

}
