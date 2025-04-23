using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlide : MonoBehaviour
{
    [SerializeField] private GameObject slide0;
    [SerializeField] private GameObject slide1;
    
    public void NextSlide()
    {
        Vector3 temp = slide0.transform.position;
        slide0.transform.position = slide1.transform.position;
        slide1.transform.position = temp;
    }

}
