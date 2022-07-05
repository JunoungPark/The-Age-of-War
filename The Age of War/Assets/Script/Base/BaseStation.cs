using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStation : MonoBehaviour
{
    public Slider slider;

    public float health;

    float Defaulthealth;

    
    // Start is called before the first frame update
    void Start()
    {
        Defaulthealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameManager.instance.state = false;
        }
        else
            slider.value = health / Defaulthealth;
    }
}
