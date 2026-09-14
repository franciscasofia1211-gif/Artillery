using UnityEngine;

public class Canon : MonoBehaviour
{
    public static bool Bloqueado;
    public AudioClip ClipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;
    public GameObject ParticulaDisparo;
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField] private GameObject puntaCanon;
    private float rotacion;

    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }
    private void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, rotacion);
        }
        if (rotacion > 90)
        {
            rotacion = 90;
        }
        if (rotacion < 0)
        {
            rotacion = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !Bloqueado)
        {
            AdministradorJuego.DisparoPorJuego--;
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
            SeguirCamara.objetivo = temp;
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 DireccionDisparo = new Vector3(-rotacion, 0,0);
            DireccionDisparo.y = 90 + DireccionDisparo.x;
            Vector3 direccionParticulas = new Vector3(-90 + DireccionDisparo.x, 90,0);
            GameObject Particulas = Instantiate(ParticulaDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.linearVelocity = DireccionDisparo.normalized * AdministradorJuego.VelocidadBala;
            SourceDisparo.Play();
            Bloqueado = true;
        }

    }
}
