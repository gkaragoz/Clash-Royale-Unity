using Pathfinding;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    float _angleCharacter;
    private AIPath _AIPath = null;
    private Vector2 _unitVectorRight;
    Animator anim;


    private void Awake()
    {
        _AIPath = GetComponent<AIPath>();
        anim = GetComponentInChildren<Animator>();
        _unitVectorRight = new Vector2(1, 0); // needed for getting standart angle of movement vector
    }

    private void Update()
    {
        if (_AIPath == null)
            return;


        // Vector2.Angle gives a float value between 0-180. Needed negative y area.
        if (_AIPath.desiredVelocity.y < 0)
        {
            _angleCharacter = 360 - Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, _unitVectorRight);
        }
        else
        {
            _angleCharacter = Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, _unitVectorRight);

        }



        //Topdown rotationg angles

        if (_angleCharacter <= 30 && _angleCharacter > 330)
        {
            anim.SetFloat("InputX", 1);
            anim.SetFloat("InputY", 0);
        }
        else if (_angleCharacter > 30 && _angleCharacter <= 60)
        {
            anim.SetFloat("InputX", .5f);
            anim.SetFloat("InputY", .5f);

        }
        else if (_angleCharacter > 60 && _angleCharacter <= 120)
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
