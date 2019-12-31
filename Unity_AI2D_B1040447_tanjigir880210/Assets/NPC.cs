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
    public string saystart = "KID:我需要你幫我一件事";
    public string saynotcomplete = "你還沒完成任務";
    public string saycomplete = "感謝你完成任務";

    [Header("對話速度")]
    public float speed = 0.01f;

    [Header("任務相關")]
    public bool missingcomplete;
    public int countPlayer;
    public int countFinish = 10;

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
}
