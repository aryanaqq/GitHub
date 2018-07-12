using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMove:MonoBehaviour {

    public float _speed;
    public float  _animationSpeed;

    public virtual void Move(float Speed,float AnimationSpeed=1) {
        _speed = Speed;
        StartCoroutine("Moving");
        }

    public virtual void GetParam(float Speed,float AnimationSpeed = 1) {
        _speed = Speed;
        Move(Speed);
        }

    IEnumerator  Moving() {
        while(true) {
            float translation = Input.GetAxis("Vertical") * _speed;
            float rotation = Input.GetAxis("Horizontal") * _speed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(rotation,0,translation);
            transform.Rotate(0,rotation,0);
            yield return null;
            }
        }

    }

public class Move1:AMove{
    public new void GetParam(float Speed,float AnimationSpeed = 1) {
        }
    }

public class Move2:AMove {
    public override void GetParam(float Speed,float AnimationSpeed = 1) {
        }
    }

public class Move3:AMove {
    public override void GetParam(float Speed,float AnimationSpeed = 1) {
        Speed *= 5;
        Move(Speed);
        }
    }
