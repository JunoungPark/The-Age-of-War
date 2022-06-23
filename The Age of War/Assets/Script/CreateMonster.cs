using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    // Start is called before the first frame update
    public void Create()
    {
        Instantiate(Resources.Load<GameObject>("Warrior Goblin"), new Vector3(-34, 0, 50), Quaternion.Euler(0, 90, 0));
    }
    // Update is called once per frame
   
}
