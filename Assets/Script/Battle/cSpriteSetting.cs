using UnityEngine;
using System.Collections;

public class cSpriteSetting : MonoBehaviour
{
    [SerializeField]
    private string fileName = null;
    [SerializeField]
    private string spriteName = null;

    //初期化
    void Awake()
    {
    }

    /// <summary>
    /// 画像を読み込んで分割
    /// </summary>
    /// <param "元のテクスチャ名"="file_name"></param>
    /// <param "スプライト名"="sprite_name"></param>
    /// <returns></returns>
    public static Sprite load(
        string file_name, string sprite_name)
    {
        //Resorceから対象のテクスチャから生成したスプライトの一覧
        Sprite[] sprites = 
            Resources.LoadAll<Sprite>(file_name);

        //対象のスプライトを取得
        return System.Array.Find<Sprite>(
            sprites,
            (sprite) => sprite.name.Equals(sprite_name));
    }
}
