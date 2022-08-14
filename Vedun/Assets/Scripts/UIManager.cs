using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text numberCurrentImproves;
    [SerializeField] private GameObject message;

    private void Awake()
    {
        EventManager.UpdateTextImproveEvent += UpdateTextNumber;
        EventManager.MessageNeedMorePowerEvent += NeedMoreimproves;
    }
    private void UpdateTextNumber(int number)
    {
        numberCurrentImproves.text = number.ToString();
    }
    private void NeedMoreimproves()
    {
        StartCoroutine(TimerMessage());
    }
    private IEnumerator TimerMessage()
    {
        message.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        message.SetActive(false);
        StopCoroutine(TimerMessage());
    }
    private void OnDestroy()
    {
        EventManager.UpdateTextImproveEvent -= UpdateTextNumber;
        EventManager.MessageNeedMorePowerEvent -= NeedMoreimproves;
    }
}
