using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bralli : MonoBehaviour
{
    public GameObject blockPrefab;

    public Vector2Int Size;
    public Vector3 Scale;
    List<GameObject> BlockList;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(blockPrefab.transform.localScale.x * Size.y, 2, blockPrefab.transform.localScale.z * Size.x);

        BlockList = new List<GameObject>();

        Scale = blockPrefab.transform.localScale;

        for (int y = 0; y < Size.y; y++)
        {
            for (int x = 0; x < Size.x; x++)
            {
                var vx = Scale.x * y - (Size.y * Scale.x);
                var vy = this.transform.position.y;
                var vz = Scale.z * x - (Size.x * Scale.z);

                var r = this.transform.position + new Vector3(vx, vy, vz);

                Instantiate(blockPrefab, r, Quaternion.identity);
            }
        }
    }
}
