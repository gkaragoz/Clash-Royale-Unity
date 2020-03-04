using Pathfinding;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    float _slope;
    float _angleCharacter;
    private AIPath _AIPath = null;
    Animator anim;
    private void Awake() {
        _AIPath = GetComponent<AIPath>();
        anim = GetComponentInChildren<Animator>();




    }

    private void Update() {
        if (_AIPath == null)
            return;

        anim.SetFloat("InputX", _AIPath.desiredVelocity.x/ _AIPath.maxSpeed);
        anim.SetFloat("InputY", _AIPath.desiredVelocity.y/ _AIPath.maxSpeed);
       // Debug.Log(_AIPath.desiredVelocity / _AIPath.maxSpeed);

        if (_AIPath.desiredVelocity.y<0)
        {
            _angleCharacter = 360 - Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, new Vector2(1, 0));
            //Debug.Log(360-Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, new Vector2(1, 0)));
        }
        else
        {
            _angleCharacter = Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, new Vector2(1, 0));
          //  Debug.Log(Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, new Vector2(1, 0)));

        }



        if (_angleCharacter<=30&& _angleCharacter >330)
        {
            anim.SetFloat("InputX",1);
            anim.SetFloat("InputY",0);
        }
        else if (_angleCharacter>30&& _angleCharacter <= 60)
        {
            anim.SetFloat("InputX", .5f);
            anim.SetFloat("InputY", .5f);

        }
        else if (_angleCharacter > 60&& _angleCharacter <= 120)
        {
            anim.SetFloat("InputX", 0);
            anim.SetFloat("InputY", 1f);

        }
        else if (_angleCharacter > 120 && _angleCharacter <= 150)
        {
            anim.SetFloat("InputX", -.5f);
            anim.SetFloat("InputY", .5f);
        }
        else if (_angleCharacter > 150 && _angleCharacter <= 210)
        {
            anim.SetFloat("InputX", -1);
            anim.SetFloat("InputY", 0);
        }
        else if (_angleCharacter > 210 && _angleCharacter <= 240)
        {
            anim.SetFloat("InputX", -.5f);
            anim.SetFloat("InputY", -.5f);
        }
        else if (_angleCharacter > 240 && _angleCharacter <= 300)
        {
            anim.SetFloat("InputX", 0);
            anim.SetFloat("InputY", -1);
        }
        else if (_angleCharacter > 300 && _angleCharacter <= 330)
        {
            anim.SetFloat("InputX", .5f);
            anim.SetFloat("InputY", -.5f);
        }

    }


}
