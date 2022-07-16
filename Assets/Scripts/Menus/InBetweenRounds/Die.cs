using System.Collections;
using UnityEngine;


public class Die : MonoBehaviour
{
    public int Value = 0;
    public bool isSelected = false;
    void Update()
    {
        if (isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 9);
        }
    }
}
