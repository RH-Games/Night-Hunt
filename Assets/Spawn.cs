using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject NpcToSpawn;
    void Start()
    {
        Instantiate(NpcToSpawn, transform.position, transform.rotation);          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
