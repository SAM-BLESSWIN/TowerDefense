using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhit : MonoBehaviour
{
    [SerializeField] int hitpoints = 10;
    [SerializeField] ParticleSystem hitprefab;
    [SerializeField] ParticleSystem death;
    [SerializeField] GameObject dead;
    [SerializeField] AudioClip hitsfx;
    [SerializeField] AudioClip deathsfx;
    AudioSource myaudio;

    public void Start()
    {
         myaudio = GetComponent<AudioSource>();
    }
    public void OnParticleCollision(GameObject other)
    {
        damage();
        kill();
    }

    void damage()
    {
        hitpoints = hitpoints - 1;
        myaudio.PlayOneShot(hitsfx);
        hitprefab.Play();
    }

    private void kill()
    {
        if (hitpoints <=0)
        {
            var vfx=Instantiate(death, transform.position, Quaternion.identity);
            vfx.transform.position = new Vector3(transform.position.x, 15,transform.position.z);
            vfx.Play();
            AudioSource.PlayClipAtPoint(deathsfx,Camera.main.transform.position);
            Destroy(vfx.gameObject, vfx.main.duration);
            Destroy(dead);
        }
    }
}
