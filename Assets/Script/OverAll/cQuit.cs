using UnityEngine;

public class cQuit : MonoBehaviour {

    ///<summary> 同じオブジェクトの生成を防ぐ </summary>
    private static bool b_createquit = false;

    ///<summary> ダイアログオブジェクト </summary>
    private GameObject _dialogObj = null;

    ///<summary> 初期化 </summary>
    void Awake()
    {
        //同じオブジェクトがなければ
        //オブジェクトが消えないようにする
        //あれば破棄して同じものができないようにする
        if (!b_createquit)
        {
            DontDestroyOnLoad(gameObject);
            b_createquit = true;
        }
        else
        {
            Destroy(gameObject);
        }

        //ダイアログオブジェクトを見つけて消す
        _dialogObj = GameObject.Find("Dialog");
        _dialogObj.SetActive(false);
    }

    ///<summary> 画面更新 </summary>
    void Update()
    {
        //もしプラットフォームがアンドロイドなら
        if (Application.platform == RuntimePlatform.Android)
        {
            //エスケープキーでダイアログ表示
            if (Input.GetKey(KeyCode.Escape))
            {
                _dialogObj.SetActive(true);
                return;
            }
        }
    }

    ///<summary> はいボタン処理 </summary>
    public void YesButton()
    {
        //アプリケーションの終了
        Application.Quit();
        return;
    }

    ///<summary> いいえボタン処理 </summary>
    public void NoButton()
    {
        //ダイアログを隠す
        _dialogObj.SetActive(false);
        return;
    }
}
