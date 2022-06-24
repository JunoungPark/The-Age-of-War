using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{

    float time;

    int gold;
    
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            time--;
            gold++;
        }
    }
    public void Create()
    {
        Instantiate(Resources.Load<GameObject>("Warrior Goblin"), new Vector3(-34, 0, 50), Quaternion.Euler(0, 90, 0));
    }
    // Update is called once per frame
   public void EnemyInstance()
    {
        if (gold >= 1)
        {
            Instantiate(Resources.Load<GameObject>("Enemy Warrior Goblin"), new Vector3(34, 0, 50), Quaternion.Euler(0, -90, 0));
        }
    }
}
