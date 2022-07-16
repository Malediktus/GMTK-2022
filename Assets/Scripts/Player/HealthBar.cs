using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject bar;

    private void Update()
    {
        bar.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
    }

    public void SetMaxValue(int value)
    {
        bar.GetComponent<Slider>().maxValue = value;
    }

    public void SetHealth(int health)
    {
        bar.GetComponent<Slider>().value = health;
    }
}