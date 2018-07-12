using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds:MonoBehaviour {
    

    static WaitSeconds s_Instance;
    IEnumerator coroutine;

    public static WaitSeconds Instance {
        get {
            if(s_Instance == null) {
                s_Instance = FindObjectOfType(typeof(WaitSeconds)) as WaitSeconds;
                if(s_Instance == null) {
                    GameObject WaitController = new GameObject("WaitController");
                    s_Instance = WaitController.AddComponent<WaitSeconds>();
                    }
                }
            return s_Instance;
            }
        }


    public void Waits(float time,Action callback=null) {
        coroutine = WaitFor(time,callback);
        StartCoroutine(coroutine);
        }

    IEnumerator WaitFor(float time,Action callback=null ) {
        yield return new WaitForSeconds(time);
        if(callback != null) {
            callback();
            }
        }
    }
