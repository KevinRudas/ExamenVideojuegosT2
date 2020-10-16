using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float velocity = 5f;
    private Rigidbody2D rb;
    private PuntajeController puntajeController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puntajeController = FindObjectOfType<PuntajeController>();
        Debug.Log(puntajeController.GetPoints());

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity * -1,rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "kunai")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            
            puntajeController.AddPoints(10);
            Debug.Log(puntajeController.GetPoints());
        }
    }

}
