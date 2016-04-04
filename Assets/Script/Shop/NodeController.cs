using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour
{
    /// <summary> 増やすプレハブ </summary>
    [SerializeField]
    RectTransform prefab = null;

    /// <summary> 個数 </summary>
    [SerializeField]
    private int num = 3;

    public string[] StrikeName =
        new string[]{
            "スキル1",
            "スキル2",
            "スキル3",
            "スキル4",
            "スキル5",
        };

    public string[] StrikePrice =
        new string[]{
            "100sp",
            "150sp",
            "150sp",
            "200sp",
            "500sp",
        };

    /// <summary> 初期化 </summary>
    void Awake()
    {
        for (int i = 1; i <= num; ++i)
        {
            //プレハブを設定個数分生成
            var item = Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            //名前変更
            item.name = prefab.name + i;

            var text = item.GetComponentsInChildren<Text>();
            text[0].text = StrikeName[i - 1];
            text[1].text = StrikePrice[i - 1];
        }
    }
}
