using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField]private GameObject puntaCanon;
    private float rotacion;
    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControls = new CanonControls();
    }
    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
        modificarFuerza.Enable();
        modificarFuerza.performed += Modificar;
    }
    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
    }
    private void Update()
    {
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(0,0,rotacion);
        }
        if (rotacion > 90)
        {
            rotacion = 90;
        }
        if(rotacion < 0)
        {
            rotacion = 0;
        }
<<<<<<< HEAD
        if (AdministradorJuego.DisparoPorJuego > 0) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AdministradorJuego.DisparoPorJuego--;
                GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                Vector3 DireccionDisparo = transform.rotation.eulerAngles;
                DireccionDisparo.x = -90 + DireccionDisparo.y;
                tempRB.linearVelocity = DireccionDisparo.normalized * AdministradorJuego.VelocidadBala;
            } 
        }
=======
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
        SeguirCamara.objetivo = temp;
        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        Vector3 DireccionDisparo = new Vector3(-rotacion, 0, 0);
        DireccionDisparo.y = 90 + DireccionDisparo.x;
        Vector3 direccionParticulas = new Vector3(-90 + DireccionDisparo.x, 90, 0);
        GameObject Particulas = Instantiate(ParticulaDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
        tempRB.linearVelocity = DireccionDisparo.normalized * AdministradorJuego.VelocidadBala;
        AdministradorJuego.DisparoPorJuego--;
        SourceDisparo.Play();
        Bloqueado = true;
    }
    private void Modificar(InputAction.CallbackContext context)
    {
        AdministradorJuego.VelocidadBala -= modificarFuerza.ReadValue<float>();
>>>>>>> 1f32d2d6 (Practica Modulo 18)
    }
}
