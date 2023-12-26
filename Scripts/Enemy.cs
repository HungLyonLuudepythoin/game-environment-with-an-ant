using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            MenuManager.instance.IncreaseScore();
            gameObject.SetActive(false);
        }


    }

}
