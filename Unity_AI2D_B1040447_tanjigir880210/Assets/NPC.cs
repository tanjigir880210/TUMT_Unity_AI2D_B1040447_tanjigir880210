using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public enum state
    {
        normal, notComplete, complete
    }

    public state _state;

    [Header("對話內容")]
    public string saystart = "KID呼叫太空人";
    public string saynotcomplete = "我需要你幫我一件事";
    public string saycomplete = "感謝你完成任務";

    [Header("對話速度")]
    public float speed = 1.5f;

    [Header("任務相關")]
    public bool missingcomplete;
    public string countPlayer;
    public string countFinish = "10";

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

        switch (_state)
        {
            case state.normal:
                textSay.text = saystart;
                break;
            case state.notComplete:
                textSay.text = saynotcomplete;
                break;
            case state.complete:
                textSay.text = saycomplete;
                break;
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        objCanvas.SetActive(false);
    }
}
