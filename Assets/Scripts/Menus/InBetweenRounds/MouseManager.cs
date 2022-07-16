using System.Collections;
using UnityEngine;


public class MouseManager : MonoBehaviour
{
    bool isSelecting = false;
    Die selectedDie;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!isSelecting && Input.GetMouseButtonDown(0))
        {
            Collider2D[] targetObj = Physics2D.OverlapPointAll(mousePosition);
            if (targetObj.Length > 0)
            {
                
                for (int i = 0; i < targetObj.Length; i++)
                {
                    Die die;
                    if (targetObj[i].TryGetComponent<Die>(out die)){
                    die.isSelected = true;
                    selectedDie = die;
                    isSelecting = true;
                }
                }


            }
        }

        else if(isSelecting && !Input.GetMouseButton(0))
        {
            selectedDie.isSelected = false;
            isSelecting = false;
        }
        
    }
}
