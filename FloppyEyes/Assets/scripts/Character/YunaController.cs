using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YunaController : MonoBehaviour
{
    public static YunaController instance;

    public delegate void TurnOnRigidBody();
    public event TurnOnRigidBody turnonrb; /*включает рэгдолл на частях тела*/

    float startSpeed;
    private float timeJump;
    private float speed_forward;
    private float distance = 1f;
    public Animator animator;
    private CharacterController cc;
    private float time;
    private float timeClimb;
    public bool isClimbing;
    private bool isInMovement = false;
    private float currentDir = 0f;
    private int currentRoad = 0;
    public float force;
    private float delta;
    public float jumpHeight;
    public float climbSpeed = 4.0f;
    public bool isJumping = false;
    private Vector3 moveUp = Vector3.zero;
    public float gravity = 20.0f;
    private bool shouldClimb;
    private float timeDie;
    public bool dead;
    private IEnumerator coroutine;
    public float timeMove;
    private float speed_y;
    public float speed_z = 0;
    Vector3 pos = new Vector3(0, 0, 0);
    public ParticlesController collision;
    public ParticlesController sparkles;
    private void Awake()
    {

        if (YunaController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        YunaController.instance = this;


        //DontDestroyOnLoad(gameObject);
    }
    private void OnDestroy()
    {
        YunaController.instance = null;
    }
    void Start()     
    {
        Time.timeScale = 1;
        dead = false;
        startSpeed = jumpHeight / timeJump + gravity * timeJump / 2;
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            name = clip.name;
            switch (clip.name)
            {
                case "left":
                    time = clip.length;
                    break;
                case "Climbing":
                    timeClimb = clip.length;
                    break;
                case "Death":
                    timeDie = clip.length;
                    break;
                case "Jump":
                    timeJump = clip.length;
                    break;
            }
        }

    }
    void Update()
    {
        if (!isJumping && !isClimbing)
        {
            cc.Move(new Vector3(0, -gravity, 0));
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && !dead && !isClimbing && !isJumping)
        {
            animator.SetTrigger("jump");
            isJumping = true;
            startSpeed = (jumpHeight - cc.transform.position.y) / timeJump + gravity * timeJump / 2;
            StartCoroutine(WaitToStopJumping());
        }
        if (!isInMovement && Input.GetKeyDown(KeyCode.D) && currentRoad < 1 && !dead && !isClimbing)
        {
            if (currentRoad == -1)
                distance = -transform.position.x;
            else if (currentRoad == 0)
                distance = 1 - transform.position.x;
            currentRoad += 1;
            isInMovement = true;
            currentDir = 1;
            StartCoroutine(WaitToStopMoving());
        }
        else if (!isInMovement && Input.GetKeyDown(KeyCode.A) && currentRoad > -1 && !dead && !isClimbing)
        {

            distance = 1f + transform.position.x - currentRoad;
            currentRoad -= 1;
            distance = 1f;
            isInMovement = true;
            currentDir = -1;
            StartCoroutine(WaitToStopMoving());
        }

        if (isInMovement && !dead)
        {
            Move();
        }
        if (isJumping && !dead)
        {
            Jump();
        }
        if (isClimbing && !dead)
        {
            Climb();
        }
        speed_y = transform.position.y;
    }
    private void Jump()
    {
        startSpeed -= gravity * Time.deltaTime;
        float tmpDist = Time.deltaTime * startSpeed;
        cc.Move(Vector3.up * tmpDist);
    }
    private void Move()
    {
        float speed = distance / timeMove;
        float tmpDist = Time.deltaTime * speed;
        cc.Move(Vector3.right * currentDir * tmpDist);
    }
    private void Climb()
    {
        float speed = distance / timeClimb;
        float tmpDist = Time.deltaTime * speed;
        cc.Move(Vector3.up * tmpDist);   
    }
    private IEnumerator WaitToStopJumping()
    {
        yield return new WaitForSeconds(timeJump);
        isJumping = false;

    }
    private IEnumerator WaitToStopClimbing()
    {
        yield return new WaitForSeconds(timeClimb+0.5f);
        isClimbing = false;
        WorldController.instance.speed_z = WorldController.instance.speed;

    }
    private IEnumerator WaitToStopMoving()
    {
        yield return new WaitForSeconds(timeMove);
        isInMovement = false;
    }
    private IEnumerator Restart(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void SaveSettings()
    {
        if (ShowScore.score > PlayerPrefs.GetFloat("BestScore"))
            PlayerPrefs.SetFloat("BestScore", ShowScore.score);
        PlayerPrefs.SetFloat("Score", 0f);
        PlayerPrefs.SetFloat("Speed", WorldController.instance.initial_speed);
    }
    public void PhysicKill() /*влючает рэгдолл на персонаже*/
    {
        WorldController.instance.speed_z = 0;
        animator.enabled = false;
        turnonrb();
        dead = true;
        SaveSettings();
        coroutine = Restart(timeDie);
        StartCoroutine(coroutine);
    }
    public void AnimatedKill() /*включает анимацию*/
    {
        dead = true;
        WorldController.instance.speed_z = 0;
        animator.SetTrigger("dead");
        coroutine = Restart(timeDie);
        StartCoroutine(coroutine);
    }
    public void SetClimb(float delta1)
    {
        isClimbing = true;
        animator.SetTrigger("climb");
        distance = delta1;
        WorldController.instance.speed = WorldController.instance.speed_z;
        WorldController.instance.speed_z = 0;
        StartCoroutine(WaitToStopClimbing());
    }
}
