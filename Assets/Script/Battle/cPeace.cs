using UnityEngine;
using System.Collections;

public class cPeace : MonoBehaviour
{

    //初期化
    void Awake()
    {

    }

    //
    void Update()
    {

    }

    void Swap(int before, int after)
    {
        int temp;
        temp = before;
        before = after;
        after = before;
    }
}
