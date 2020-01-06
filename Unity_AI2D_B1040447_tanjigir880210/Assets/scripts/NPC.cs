using UnityEngine;
using UnityEngine.UI;   
using System.Collections;
public class NPC : MonoBehaviour
{
    public enum state
    {
        normal, notComplete, complete
    }

    public state _state;

    [Header("對話內容")]
    public string saystart = "KID:呼叫太空人! 現在有個緊急事件,魔王佔領了水晶收藏區,我需要你找到3塊水晶,以防止魔王利用水晶毀滅世界。";
    public string saynotcomplete = "KID:還沒找完,時間不等人的,快快快!";
    public string saycomplete = "KID:感謝你幫助我的忙,不然世界就真的沒了,這份恩情我會報答你的,我現在幫你傳送回人類世界。";

    [Header("對話速度")]
    public float speed = 0.01f;

    [Header("任務相關")]
    public bool missingcomplete;
    public int countPlayer;
    public int countFinish = 3;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "太空人")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "太空人")
            SayClose();
    }

    /// <summary>
    /// 對話:打字效果
    /// </summary>
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;

        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(saystart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(saynotcomplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(saycomplete));
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              

        for (int i = 0; i < say.Length; i++)            
        {
            textSay.text += say[i].ToString();          
            yield return new WaitForSeconds(speed);     
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public void PlayerGet()
    {
        countPlayer++;
    }
}
