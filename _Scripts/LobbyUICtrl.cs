using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 大厅界面
/// </summary>
public class LobbyUICtrl : MonoBehaviour {



	// Use this for initialization
	void Start () {
        UIButton[] button = this.gameObject.GetComponentsInChildren<UIButton>();
        for (int i = 0; i < button.Length; i++)
        {
            UIEventListener.Get(button[i].gameObject).onClick = ButtonClick;
        }
    }

    public void ButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "StartGameButton":
                StartGameButtonClick();
                break;
        }
    }

    /// <summary>
    /// 开始游戏按钮点击
    /// </summary>
    public void StartGameButtonClick()
    {
        SceneManager.LoadScene("Test1");
    }
}
