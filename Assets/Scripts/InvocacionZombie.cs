using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocacionZombie : MonoBehaviour
{
    public GameObject zombie;
    public Transform posicionZombie;
    public int contador = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador ==500)
        {
            Instantiate(zombie, posicionZombie.position, Quaternion.identity);
            contador = 0;
        }

        contador++;
    }
    
}
