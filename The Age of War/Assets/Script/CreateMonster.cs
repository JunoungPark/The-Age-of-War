using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateMonster : MonoBehaviour
{
    public Button[] createButton;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }
    public void Create(string name)
    {
        switch (name)
        {
            case "Goblin":
                    DataManager.instance.Save();
                    Instantiate(Resources.Load<GameObject>("Warrior Goblin"), new Vector3(-40, 0, 50), Quaternion.Euler(0, 90, 0));
                    StartCoroutine(Wait(3.0f, createButton[0]));
                
                break;

            case "Troll":
                    DataManager.instance.stuff.money -= Information.instance.data[1].price;
                    DataManager.instance.Save();
                    Instantiate(Resources.Load<GameObject>(name), new Vector3(-40, 0, 50), Quaternion.Euler(0, 90, 0));
                    StartCoroutine(Wait(5.0f, createButton[1]));
                   
                break;
            case "Wizard":
                    DataManager.instance.stuff.money -= Information.instance.data[2].price ;
                    DataManager.instance.Save();
                    Instantiate(Resources.Load<GameObject>(name), new Vector3(-40, 0, 50), Quaternion.Euler(0, 90, 0));
                    StartCoroutine(Wait(10.0f, createButton[2]));
                    
                break;
        }
        
    }
    // Update is called once per frame
    public void EnemyInstance()
    {

        if (GameManager.instance.state == true )
        {
            Instantiate(Resources.Load<GameObject>("Enemy Warrior Goblin"), new Vector3(40, 0, 50), Quaternion.Euler(0, -90, 0));
        }
    }

    IEnumerator Wait(float timer,Button button)
    {
        float defaultTime = timer;
        button.interactable = false;
        while (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            button.image.fillAmount = 1.0f - (timer / defaultTime);

            yield return new WaitForFixedUpdate();
        }

        button.interactable = true;
        button.image.fillAmount = 1.0f;
    }
}
