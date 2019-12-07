using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    public GameObject particle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject deathParticle = Instantiate(particle, other.transform.position, Quaternion.Euler(0f, 180f, 0f));
            deathParticle.GetComponent<ParticleSystem>().Play();
            StartCoroutine("Death");
            
        }
    }

    //TODO Replace Death() function
    IEnumerator Death()
    {      
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(0);
    }
}
