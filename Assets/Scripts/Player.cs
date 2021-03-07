using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 yon;
    public float hiz;
    public float hizlanmaZorluğu;
    public ZeminOlusturma zeminOlustur;
    public static bool dustuMu;
    float skor;
    public int skorArtmasi;
    public Text textSkor;
    public int highScore;
    public Text highscoreText;

    public GameObject GameOverPanel;
    public Text GameOverScore;
    public Text GameOverHighScore;

    public Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        highScore = PlayerPrefs.GetInt("highScore");
        highscoreText.text = highScore.ToString();
        yon = Vector3.back;
        dustuMu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if(dustuMu == true)
        {
            return;
        }

        if (transform.position.y < 1.1f)
        {
            Olunce();
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(yon.x == 0)
            {
                yon = Vector3.right;
                animator.SetBool("isGoingRight", true);
                animator.SetBool("isGoingUp", false);
            }
            else
            {
                yon = Vector3.back;
                animator.SetBool("isGoingRight", false);
                animator.SetBool("isGoingUp", true);
            }
        }
       
    }
    void Olunce()
    {
        if (highScore < (int)skor)
        {
            highScore = (int)skor;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        dustuMu = true;

        GameOverPanel.SetActive(true);
        GameOverScore.text = ((int)skor).ToString();
        GameOverHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }
    void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (dustuMu)
        {
            return;
        }
        Vector3 hareket = yon * Time.deltaTime * hiz;
        transform.position += hareket;
        hiz += hizlanmaZorluğu * Time.deltaTime;
        skor += (skorArtmasi * hiz*Time.deltaTime);
        textSkor.text = ((int)skor).ToString();
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            StartCoroutine(Kaldir(collision.gameObject));
            zeminOlustur.ZeminOlustur();
        }
    }
    IEnumerator Kaldir(GameObject kaldirilacak)
    {
        yield return new WaitForSeconds(0.9f);
        kaldirilacak.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(4.5f);
        Destroy(kaldirilacak);
    }
}
