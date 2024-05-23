using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_mascot : MonoBehaviour
{
    private Animator animator;
    private Animation anim;
    private int animNum;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        OwlAnimation();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        OwlAnimation();
    }

    private void OwlAnimation()
    {
        animNum = Random.Range(0, 3);
        animator.SetInteger("Num", animNum);
    }
}
