using System.Collections;
using UnityEngine;


public class GunRotate : MonoBehaviour
{
    public GameObject gun;
    public SpriteRenderer SpriteRenderer;

    private void Start()
    {
        SpriteRenderer = gun.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = Quaternion.LookRotation(Vector3.forward, MousePos - gun.transform.position).eulerAngles;
        rot += new Vector3(0, 0, 90);
        gun.transform.rotation = Quaternion.Euler(rot);
        Debug.Log(rot.z);
        if(Mathf.Abs(rot.z) > 270 && Mathf.Abs(rot.z) < 450)
        {
            SpriteRenderer.flipY = false;
        }
        else
        {
            SpriteRenderer.flipY = true;
        }
    }
}
