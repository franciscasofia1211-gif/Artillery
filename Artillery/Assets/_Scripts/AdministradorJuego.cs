using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;

    public static int DisparoPorJuego = 10;

    public static float VelocidadBala = 30;
    public static float VelocidadRotacion = 1;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;
    public GameObject CanvasPausa;

    public TMP_Text TextDisp;

    public Slider FuerzaDisparo;
    public bool pausa;

    private void Awake()
    {
        DisparoPorJuego = 10;
        CanvasPerder.SetActive(false);
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
    }
    private void Update()
    {
        FuerzaDisparo.value = VelocidadBala;
        TextDisp.text = $"Quedan {DisparoPorJuego} disparos";
        if (DisparoPorJuego <= 0)
        {
            PerderJuego();
        }
        if (pausa || !pausa)
        {
            CanvasPausa.SetActive(pausa);
        }
    }
    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
    }
    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }
    public void Pausa()
    {
        pausa = !pausa;
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void Reintentar()
    {
        var LevelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(LevelActual);
    }
}
