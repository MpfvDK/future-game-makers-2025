using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator anim;

    public AudioClip clip;
    public void KillYourselfNOW()
    {
        Destroy(gameObject);
    }

    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
