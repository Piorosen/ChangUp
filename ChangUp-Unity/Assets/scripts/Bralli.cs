using ChanUpP.Manage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bralli : MonoBehaviour
{
    public GameObject blockPrefab;

    public Vector2Int Size;
    public Vector3 Scale;
    List<GameObject> BlockList;

    Converter conv = new Converter();

    public string Text;
    public bool Run;

    Vector3 GetPosition(int x, int y)
    {
        Vector3 result = new Vector3();

        // 좌표계의 가운데 (0,0) 일 때 기준
        var middleX = (this.transform.localScale.x - this.transform.localScale.x / 2);
        var middleZ = (this.transform.localScale.z - this.transform.localScale.z / 2);

        // 계산상의 위치
        var vx = Scale.x * y - (Size.y * Scale.x);
        var vz = Scale.z * x - (Size.x * Scale.z);

        // 블럭의 위치 보정
        var bx = (blockPrefab.transform.localScale.x / 2);
        var bz = (blockPrefab.transform.localScale.z / 2);

        var pos = this.transform.position;

        result.x = middleX + vx + bx + pos.x;
        result.y = pos.y;
        result.z = middleZ + vz + bz + pos.z;


        return result;
    }
     
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(blockPrefab.transform.localScale.x * Size.y,
                                                this.transform.localScale.y,
                                                blockPrefab.transform.localScale.z * Size.x);

        BlockList = new List<GameObject>();

        Scale = blockPrefab.transform.localScale;

        for (int y = 0; y < Size.y; y++)
        {
            for (int x = 0; x < Size.x; x++)
            {
                var r = GetPosition(x, y);

                var p = Instantiate(blockPrefab, r, Quaternion.identity);
                p.name = $"X {x} : Y : {y}";
                p.transform.SetParent(this.transform);

                BlockList.Add(p);
            }
        }
    }

    string ListToString(List<bool> value)
    {
        string result = "";

        foreach (var i in value)
        {
            result += $"{i}, ";
        }

        return result;
    }

    void Update()
    {
        if (Run)
        {
            var p = conv.StringToBriall(Text);

            foreach (var o in BlockList)
            {
                o.GetComponent<Block>().Call(new List<bool> { false, false, false, false, false, false });
            }

            int size = 0;
            foreach (var o in p)
            {
                foreach (var i in o)
                {
                    if (size < BlockList.Count)
                    {
                        Debug.Log(ListToString(i));
                        
                        BlockList[size++].GetComponent<Block>().Call(i);
                    }
                }
            }

        }
    }
}
