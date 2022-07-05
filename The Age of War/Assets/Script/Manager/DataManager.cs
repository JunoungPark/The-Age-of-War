using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
public class Stuff
{
    public int money;

    float timer;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Text moneyText;

    public Stuff stuff = new Stuff();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    
        Load();

    }
    private void Update()
    {
        moneyText.text = stuff.money.ToString();
        
    }
    public IEnumerator Increase()
    {
        while(GameManager.instance.state == true)
        {
            yield return new WaitForSeconds(1f);
            stuff.money += 50;
            Save();
        }
    }
    public void Save()
    {
        string jsonData = JsonConvert.SerializeObject(stuff);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        string format=System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "Data.json", format);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "Data.json");
        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string format = System.Text.Encoding.UTF8.GetString(bytes);

        stuff = JsonConvert.DeserializeObject<Stuff>(format);
    }
    // Update is called once per frame
   
}
