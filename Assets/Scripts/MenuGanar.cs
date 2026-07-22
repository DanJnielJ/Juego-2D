using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGanar : MonoBehaviour
{
    public GameObject PanelGanar;
    public Button BotonPrincipal;
    public TMP_Text TextoMoneda;
    public TMP_Text TextoTiempo;
    public TMP_Text TextoMuerte;

    private ContadorTiempo ContadorTiempo;

    private void Awake()
    {
        GestorEventos.EventoGanar += AbrirMenu;
    }
    private void OnDestroy()
    {
        GestorEventos.EventoGanar -= AbrirMenu;
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
    public void AbrirMenu()
    {
        actualizarPanel();
        Time.timeScale = 0;
        BotonPrincipal.Select();
        PanelGanar.SetActive(true);
    }
    public void ReiniciarNivel()
    {

        Time.timeScale = 1;



        //SceneManeger permite cargar escenas, getActive permite obtener el nombre de escena activa
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    
}
