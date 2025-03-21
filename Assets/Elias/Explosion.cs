using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(anim.GetFloat("played") > 0) Destroy(gameObject);
    }

    public void KillYourselfNOW()
    {
        Destroy(gameObject);
    }
}
