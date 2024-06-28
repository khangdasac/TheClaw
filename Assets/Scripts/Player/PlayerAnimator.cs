using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animatorBody;
    public Animator animatorClothes;
    public Animator animatorArmor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBool(string name, bool value)
    {
        animatorBody.SetBool(name, value);
        animatorClothes.SetBool(name, value);
        animatorArmor.SetBool(name, value);
    }

    public void SetFloat(string name, float value)
    {
        animatorBody.SetFloat(name, value);
        animatorClothes.SetFloat(name, value);
        animatorArmor.SetFloat(name, value);
    }

    public void SetTrigger(string name)
    {
        animatorBody.SetTrigger(name);
        animatorClothes.SetTrigger(name);
        animatorArmor.SetTrigger(name);
    }

}
