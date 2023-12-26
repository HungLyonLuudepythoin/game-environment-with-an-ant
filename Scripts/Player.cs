using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public static Player instance;
    [SerializeField] private float speed;
    private bool startMoving = false;
    public bool StartMoving { get { return startMoving; } set { startMoving = value; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving == true)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * 2 * Time.deltaTime;
        }
        if (startMoving == false) return;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Tree"))
        {
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
        }

    }

}
