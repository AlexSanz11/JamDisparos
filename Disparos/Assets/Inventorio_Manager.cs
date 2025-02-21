using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorio_Manager : MonoBehaviour
{
    public List<ItemScriptable> items = new();
    // Start is called before the first frame update
    void Start()
    {
        int randmNUm = Random.Range(0, items.Count);
        Debug.Log("tienes el objeto"+items[randmNUm].Itemname+"y cuesnta un total de");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
