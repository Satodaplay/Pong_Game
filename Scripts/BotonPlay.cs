using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPlay : MonoBehaviour
{
    public void IrAlJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
