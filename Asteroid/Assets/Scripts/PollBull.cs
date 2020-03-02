using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PollBull : MonoBehaviour
{
    [SerializeField]
    Transform spawnPos;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int amount = 0;
    [SerializeField]
    private bool populateOnStart = true;
    [SerializeField]
    private bool growOverAmount = true;

    private bool spawn = true;

    private List<GameObject> pool = new List<GameObject>();

    public static PollBull inst;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(inst == null) inst = this;
    }

    void Start()
    {
        if (populateOnStart && prefab != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(prefab);
                instance.SetActive(false);
                pool.Add(instance);
            }
        }
    }

    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        foreach (var item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = position;
                item.transform.rotation = rotation;
                item.SetActive(true);
                return item;
            }
        }

        if (growOverAmount)
        {
            var instance = (GameObject)Instantiate(prefab, position, rotation);
            pool.Add(instance);
            return instance;
        }

        return null;
    }

    public IEnumerator SpawnBull()
    {
        //spawn = false;
        Instantiate(spawnPos.position, spawnPos.transform.parent.rotation);
        yield return new WaitForSeconds(0.3f);
        //spawn = true;
    }

    // private void Update()
    // {
    //     if (spawn)
    //         StartCoroutine(SpawnBull());
    // }
}
