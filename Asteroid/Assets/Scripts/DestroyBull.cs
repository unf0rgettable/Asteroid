using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBull : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
