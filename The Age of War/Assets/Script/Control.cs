using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    int damage = 10;
    public float speed = 1.0f;

    Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Attack") == true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.SetBool("Attack", false);
            }
        }
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            animator.SetBool("Attack", true);
        }
    }
}
