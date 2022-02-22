using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Vector2 moveDir;
    public float speed = 10f;
    GameManager gm;
    Transform transform;
    GameObject g;
    CameraEffects cam;
    public Material basic;
    public Material health;
    public Material damage;
    public AudioSource player;
    public AudioSource computer;
    TrailRenderer tr;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = new Vector2(1f, Random.Range(-0.8f, 0.8f)).normalized;
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        transform = this.gameObject.GetComponent<Transform>();
        speed = 10f;
        tr = this.gameObject.GetComponent<TrailRenderer>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraEffects>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        setColor(basic);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position += new Vector3(moveDir.x * speed * Time.deltaTime, moveDir.y * speed * Time.deltaTime, transform.position.z);
    }

    private void setColor(Material mat)
    {
        sr.material = mat;
        tr.material = mat;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        g = collision.gameObject;
        if (g.CompareTag("sidewall")){
            moveDir.y *= -1f;
            moveDir = moveDir.normalized;
        }else if (g.CompareTag("endwall")){
            if (this.transform.position.x < 0)
            {
                gm.computerScored();
                moveDir = Vector2.zero;
                posReset();
            }
            else
            {
                gm.playerScored();
                moveDir = Vector2.zero;
                posReset();
            }
        }else if (g.CompareTag("paddle")){
            if(this.transform.position.x < 0)
            {
                player.Play();
            }
            else
            {
                computer.Play();
            }
            moveDir.x *= -1f;
            float delta = transform.position.y - g.transform.position.y;
            moveDir.y += delta;
            moveDir.y = Mathf.Clamp(moveDir.y, -0.8f, 0.8f);
            moveDir = moveDir.normalized;
            StartCoroutine(cam.shake(.05f, .2f));
        }
    }

    private void posReset()
    {
        setColor(basic);
        tr.forceRenderingOff = true;
        this.transform.position = new Vector3(0f, 0f, 0f);
        moveDir = new Vector2(1f, Random.Range(-0.8f, 0.8f)).normalized;
        speed = 10f;
        tr.forceRenderingOff = false;
    }
}
