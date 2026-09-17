using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField]private GameObject puntaCanon;
    private float rotacion;

    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
    }
    private void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
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
    }
}
