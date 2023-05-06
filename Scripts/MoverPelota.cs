using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelota : MonoBehaviour
{
    //Variables del movimiento
    public float velocidadMovimiento = 5f;
    public float velocidadExtraPorGolpe = 0.5f;
    public float velocidadExtraMaxima = 10f;

    private int contraGolpes;

    private void Start()
    {
        StartCoroutine(IniciarPelota());
    }

    public IEnumerator IniciarPelota(bool comienzaJugador1 = true)
    {

        this.PosicionarPelota(comienzaJugador1);

        contraGolpes = 0;
        yield return new WaitForSeconds(2f); // Pausa inicial de 2 segundo

        Vector2 direccion = comienzaJugador1 ? Vector2.left : Vector2.right;
        MovimientoPelota(direccion);
    }

    void PosicionarPelota(bool comiezaJugador1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (comiezaJugador1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, -9);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, -9);
        }
        

    }

    public void MovimientoPelota(Vector2 direccion)
    {
        direccion.Normalize();

        float velocidad = velocidadMovimiento + (contraGolpes * velocidadExtraPorGolpe);
        velocidad = Mathf.Min(velocidad, velocidadExtraMaxima);

        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = direccion * velocidad;
    }

    public void AumentarContadorGolpes()
    {
        if (contraGolpes * velocidadExtraPorGolpe <= velocidadExtraMaxima)
        {
            contraGolpes++;
        }
    }
}
