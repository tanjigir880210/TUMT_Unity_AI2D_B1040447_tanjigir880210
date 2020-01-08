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
    public string saystart = "KID:緊急事件呼叫太空人! KID:魔王佔領了水晶保護區 KID:我需要你找到3塊水晶 KID:以防止魔王利用水晶毀滅世界";
    public string saynotcomplete = "KID:還沒找到啊! KID:時間不等人快快快";
    public string saycomplete = "KID:感謝你的幫忙 KID:不然世界就真的沒了 KID:我現在幫你傳送回人類世界";

    [Header("對話速度")]
    public float speed = 0.01f;

    [Header("任務相關")]
    public bool missingcomplete;
    public int countPlayer;
    public int countFinish = 3;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    public GameObject final;

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
                final.SetActive(true);
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
