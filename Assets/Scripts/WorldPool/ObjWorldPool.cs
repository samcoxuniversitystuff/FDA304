using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjWorldPool : MonoBehaviour
{
    public static ObjWorldPool ObjInstance;

    private List<GameObject> worldObj = new List<GameObject>();
    private int objAmount = 100;

    [SerializeField] private GameObject bulletObj;
    [SerializeField] private GameObject e1Obj;
    [SerializeField] private GameObject e2Obj;

    private void Awake()
    {
        if (ObjInstance == null)
        {
            ObjInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objAmount; i++)
        {
            GameObject gameObj = Instantiate(bulletObj);
            gameObj.SetActive(false);
            worldObj.Add(gameObj);
        }
    }


    public GameObject GetBulletWorldObj()
    {
        for (int i = 0; i < worldObj.Count; i++)
        {
            if (!worldObj[i].activeInHierarchy)
            {
                return worldObj[i];
            }
        }

        return null;
    }
    
}
