using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject ParticulaExplosion;

    public void Explotar()
    {
        GameObject particulas = Instantiate(ParticulaExplosion, transform.position, Quaternion.identity) as GameObject;
        Canon.Bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            Invoke("Explotar", .1f);
        }
        if (collision.collider.tag == "Obstaculo")
        {
            Invoke("Explotar",.1f);
        }
    }
}
