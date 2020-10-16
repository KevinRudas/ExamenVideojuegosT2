using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{
    private int points = 0;

    public Text puntajeText;
    // Start is called before the first frame update

    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int points)
    {
        this.points += points;
        puntajeText.text = "Puntaje:" + this.points;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
