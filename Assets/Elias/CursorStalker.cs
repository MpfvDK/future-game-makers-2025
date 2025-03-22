using Unity.VisualScripting;
using UnityEngine;

public class CursorStalker : MonoBehaviour
{
    public GameObject baseTooltip;
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    public void OnTriggerExit2D(Collider2D other)
    {;
        if(other.gameObject.CompareTag("Base")) baseTooltip.SetActive(false);
    }
    public void OnTriggerStay2D(Collider2D other)
    {;
        baseTooltip.SetActive(other.gameObject.CompareTag("Base"));
    }
}
