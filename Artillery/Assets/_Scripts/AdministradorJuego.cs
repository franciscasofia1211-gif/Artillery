using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static int VelocidadBala = 30;
    public static int DisparoPorJuego = 10;
    public static float VelocidadRotacion = 1;

    private void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
    }
}
