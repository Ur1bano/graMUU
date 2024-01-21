using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolos_MU_22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
enemy-------------- -
public GameObject A;
public GameObject B;

public Rigidbody2D rb;
public Transform currentPoint;
public float speed;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    currentPoint = B.transform;
}

void Update()
{
    Vector2 point = currentPoint.position - transform.position;

    if (currentPoint == B.transform)
    {
        rb.velocity = new Vector2(speed, 0);
    }
    else
    {
        rb.velocity = new Vector2(-speed, 0);
    }


    if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == B.transform)
    {
        currentPoint = A.transform;

    }
    if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == A.transform)
    {
        currentPoint = B.transform;

    }

}
player--------------------------
;
public float speed;
public float jump;
public Rigidbody2D rb;

// Start is called before the first frame update
void Start()
{
    rb = GetComponent<Rigidbody2D>();

}

// Update is called once per frame
void Update()
{
    if (Input.GetButtonDown("Jump"))
    {
        rb.AddForce(new Vector2(rb.velocity.x, jump));
    }
}
void FixedUpdate()
{
    float x = Input.GetAxis("Horizontal");
    Vector2 move = new Vector2(x * speed, rb.velocity.y);
    rb.velocity = move;
}
scoreboard----------------------
public TextMeshPro scoreText;
private int score = 0;

// Start is called before the first frame update
void Start()
{
    UpdateScore();
}
public void UpdateScore()
{
    if (scoreText != null)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
public void AddScore(int points)
{
    score += points;
    UpdateScore();
}
punkty------------------------
public int pointsToAdd = 10;
private scoreboard scoreMenager;
// Start is called before the first frame update
void Start()
{
    scoreMenager = FindObjectOfType<scoreboard>();
    if (scoreMenager == null)
    {
        Debug.LogWarning("ScoreMenager not found!");
    }
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        if (scoreMenager != null)
        {
            scoreMenager.AddScore(pointsToAdd);
        }
        Destroy(gameObject);
    }
}
levelreset------------------ -
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        ResetLevel();
    }
}
private void ResetLevel()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}