using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    RaycastHit hit;

    Ray ray;

    public float speed;

    public float health;

    public int attack;

    public LayerMask[] layermask;

    public Slider healthGauge;

    float defaulthealth;

    int count = 0;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        defaulthealth = health;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else if (health < defaulthealth)
        {
            healthGauge.value = health / defaulthealth;
            healthGauge.gameObject.SetActive(true);
        }
        


        

        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 2.0f, layermask[0]))
        {
            // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“attack1”일 때 
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime - count >= 1)
                {
                    count++;
                    if (hit.transform.tag == "Base")
                        hit.transform.GetComponent<BaseStation>().health -= attack;
                    else
                        hit.transform.GetComponent<Control>().health -= attack;
                }
            }
            else
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Attack", true);
            }
        }
        else if (Physics.Raycast(ray, out hit, 3.0f, layermask[1]))
        {
            
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
            count = 0;
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
            count = 0;
        }
    }
}