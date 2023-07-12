using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageComplete : MonoBehaviour
{
    public void CallFirework() 
    {
        GameManager.instance.SpawnFirework();
    }


}
