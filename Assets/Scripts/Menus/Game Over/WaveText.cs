using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : MonoBehaviour
{

    public DataContainer data;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + data.wave.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
