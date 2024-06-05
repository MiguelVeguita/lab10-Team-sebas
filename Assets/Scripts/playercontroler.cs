using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject Fitgh;
    public float PUn;
    public Transform[] nodes;
    private int currentNodeIndex = 0;
    public float Vida;

    public TextMeshProUGUI Vid;
    public TextMeshProUGUI Puntaje;
    public TextMeshProUGUI CURACION;

    private int puntoactual = 0;
    public Button advance;
    public Button back;
    public Button curar;
    public int curita;
    public GameObject cubir;

    private bool isMoving = false;

    void Start()
    {
        advance.onClick.AddListener(MoveForward);
        back.onClick.AddListener(MoveBackward);
        curar.onClick.AddListener(curarse);
        rb = GetComponent<Rigidbody2D>();
        MoveToCurrentNode();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToCurrentNode();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Fitgh.SetActive(true);
            Vida -= 1;
            PUn = PUn + 10;
            Vid.text = "Vida: " + Vida;
            Puntaje.text = "Puntaje " + PUn;
            moveSpeed = 2;
            if (Vida == 0)
            {
                SceneManager.LoadScene("Derrota");
            }
            //quieto = false;

        }
        if (collision.gameObject.tag == "node")
        {
            if (puntoactual < 14)
            {
                puntoactual = puntoactual + 1;
            }
            else
            {
                puntoactual = puntoactual;
            }

        }
        if (collision.gameObject.tag == "Win")
        {

            SceneManager.LoadScene("Victoria");

        }
    }

    void MoveToCurrentNode()
    {
        Transform targetNode = nodes[currentNodeIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetNode.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetNode.position) < 0.1f)
        {
            isMoving = false;
        }
    }

    void MoveForward()
    {
        if (!isMoving && currentNodeIndex < nodes.Length - 1)
        {
            currentNodeIndex++;
            isMoving = true;
        }
    }

    void MoveBackward()
    {
        if (!isMoving && currentNodeIndex > 0)
        {
            currentNodeIndex--;
            isMoving = true;
        }
    }
    void curarse()
    {
        if (Vida == 2)
        {

        }
        else if (Vida < 2)
        {
            Vida++;
            Vid.text = "Vida: " + Vida;
            curita--;
            CURACION.text = "usar:x" + curita;
            if (curita == 0)
            {
                cubir.SetActive(true);
            }
        }
    }

}