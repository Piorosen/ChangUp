using ChanUpP.Manage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public List<GameObject> Object = new List<GameObject>();
    public List<bool> State = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var o in Object)
        {
            o.transform.localPosition = new Vector3(o.transform.localPosition.x, 0, o.transform.localPosition.z);
        }
    }

    public void Call(List<bool> State)
    {
        this.State = State;

        int range = State.Count > Object.Count ? Object.Count : State.Count;

        for (int i = 0; i < range; i++)
        {
            if (this.State[i])
            {
                Object[i].transform.localPosition = new Vector3(Object[i].transform.localPosition.x, 0.7f, Object[i].transform.localPosition.z);
            }
            else
            {
                Object[i].transform.localPosition = new Vector3(Object[i].transform.localPosition.x, 0.0f, Object[i].transform.localPosition.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
