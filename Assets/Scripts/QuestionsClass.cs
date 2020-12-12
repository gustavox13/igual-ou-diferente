using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsClass : MonoBehaviour
{

    [SerializeField]
    private GameObject[] answer = new GameObject[3];




    private void Start()
    {
            StartAnswer();
    }


    public void StartAnswer()
    {
        StartCoroutine(ShowAnswer());
    }


    IEnumerator ShowAnswer() //SHOW ANSWER
    {

        answer[0].SetActive(true);

        yield return new WaitForSeconds(3f);

        answer[1].SetActive(true);

        yield return new WaitForSeconds(3f);

        answer[2].SetActive(true);

    }

    public void HideAnswer()
    {
        answer[0].SetActive(false);

        answer[1].SetActive(false);

        answer[2].SetActive(false);
    }
}
