using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public Button BotonPrincipal;
    public GameObject PanelPausa;
    //variable para dectar cuando cerrar
    private bool menuAbierto = false;
    //variable para detectar si puede pausar
    private bool pausar = true;

    public TMP_Text TextoMoneda;
    public TMP_Text TextoTiempo;
    public TMP_Text TextoMuerte;

    void Update()
    {
        if (pausar)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (menuAbierto)
                    CerrarMenuPausa();
                else
                    AbrirMenuPausa();
            }
        }
    }
    public void AbrirMenuPausa()
    {
        actualizarPanel();

        BotonPrincipal.Select();
        menuAbierto = true;
        Time.timeScale = 0;
        PanelPausa.SetActive(true);
    }
    public void CerrarMenuPausa()
    {
        menuAbierto = false;
        Time.timeScale = 1;
        PanelPausa.SetActive(false);
    }

    private void actualizarPanel()
    {
        float tiempo = ContadorTiempo.Tiempo;
        TextoTiempo.text = string.Format("{0:00}:{1:00}", (int)tiempo / 60, (int)tiempo % 60);

        int intentos = ContadorIntentos.Intentos;
        TextoMuerte.text = intentos.ToString();

        int monedas = ContadorMonedas.MonedasObtenidas;
        TextoMoneda.text = monedas.ToString();
    }


    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
