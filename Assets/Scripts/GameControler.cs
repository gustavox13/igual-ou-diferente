using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = new GameObject[4];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    public int QuantPlay = 0;

    [SerializeField]
    private GameObject finalScreen;

    [SerializeField]
    private GameObject BlockButtons;


    private int currentQuestion = 0;

    private void Awake()
    {
        ShuffleQuestions();
    }

    private void Start()
    {
        pacocaAnim = pacoca.GetComponent<Animator>();

    }

    public void CloseTutoAndStart() //FECHA TUTORIAL E INICIA GAME
    {
        tutorial.SetActive(false);
        StartTurn();
    }

    private void StartTurn() //INICIA TURNO
    {
        questions[currentQuestion].SetActive(true);

        StartCoroutine(UnblockButtons());

    }

    IEnumerator UnblockButtons()
    {
        yield return new WaitForSeconds(9f);
        BlockButtons.SetActive(false);
    }

    public void CheckAnswer(int answer)
    {

        QuantPlay++;

        if(answer == 1)  //RESPOSTA CORRETA
        {
            StartCoroutine(CorrectAnswer());
        }
        else //RESPOSTA ERRADA
        {
            StartCoroutine(WrongAnswer());
        }

    }

    IEnumerator CorrectAnswer()
    {
        BlockButtons.SetActive(true);

        yield return new WaitForSeconds(3f);


        if(currentQuestion < 3)
        {
            questions[currentQuestion].SetActive(false);

            currentQuestion++;

            StartTurn();
        }
        else
        {
            finalScreen.SetActive(true);
        }



    }


    IEnumerator WrongAnswer() //RESPOSTA INCORRETA
    {
        pacocaAnim.SetTrigger("wrong");
        BlockButtons.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        BlockButtons.SetActive(false);
    }


    private void ShuffleQuestions()     //EMBARALHAR FRASES
    {
        for (int i = 0; i < questions.Length; i++)
        {
            GameObject obj = questions[i];
            int randomizeArray = Random.Range(0, i);
            questions[i] = questions[randomizeArray];
            questions[randomizeArray] = obj;
        }
    }




}
