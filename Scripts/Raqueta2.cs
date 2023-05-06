using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta2 : MonoBehaviour
{
    
    public float velocidadMovimiento = 5f;
    public GameObject pelota;

    private void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.y - pelota.transform.position.y) > 50)
        {
            if (transform.position.y < pelota.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * velocidadMovimiento;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * velocidadMovimiento;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
