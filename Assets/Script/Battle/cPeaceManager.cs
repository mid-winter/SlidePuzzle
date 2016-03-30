using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//スライドピースの数値設定・スライド全体の事はここでやるよ

public class cPeaceManager : MonoBehaviour
{
    cSpriteSetting spriteLoader;

    //1ピース
    private GameObject peaceObj = null;
    //ピース
    private List<GameObject> peaces = null;

    [SerializeField]
    public int _peacesNumber;//一辺のピース数（3×3＝9マスなら、3）
    [SerializeField]
    public float _peaceWidth;//ピース横幅サイズ
    [SerializeField]
    public float _peaceHeight;//ピース縦幅サイズ


    //初期化
    void Awake()
    {
        for(int i = 0;i < _peacesNumber; i++)
        {
            for(int j = 0; j < _peacesNumber; j++)
            {
                Sprite spriteImage = Resources.Load("Assets/Resources/PuzzlePicture/peaces", typeof(Sprite)) as Sprite;
                new GameObject("peace(" + i + "," + j + ")").AddComponent<SpriteRenderer>().sprite = spriteImage;
                //spriteImage.name = "peace(" + i + "," + j + ")";
            }
        }

    }

    //更新
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
