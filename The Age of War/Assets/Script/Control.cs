using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    //RaycastHit hit;
    //
    //Ray ray;

    int damage = 10;

    public float speed = 1.0f;

    public int health;

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
                health -= 10;
                animator.Rebind();
            }
        }
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if(health <= 0)
            Destroy(gameObject);
        
        
        //ray = new Ray(transform.position,transform.forward);
        //
        //if (Physics.Raycast(ray, out hit, 1.5f))
        //{
        //
        //    animator.SetBool("Attack", true);
        //}
        //else
        //{
        //    animator.SetBool("Attack", false);
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //
        //}
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Enemy" || other.tag == "Player")
        {
            animator.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Attack", false);
    }
}
