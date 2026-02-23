using UnityEngine;
using UnityEngine.InputSystem;

public class ladderMoveController : MonoBehaviour
{
    public GameObject player;
    public GameObject ladder;
    public Animator playerAnimator;
    public GameObject upArrow;
    public GameObject downArrow;
    public bool loadLadder = false; // 사다리 타고 있는가
    private void Awake()
    {
        
    }
    private void Update()
    {
        if (ladder.GetComponent<ladderController>().playerBeside() && Input.GetKeyDown(KeyCode.UpArrow) && !ladder.GetComponent<ladderController>().upEnd) loadLadder = true;
        if(ladder.GetComponent<ladderController>().playerBeside() && Input.GetKeyDown(KeyCode.DownArrow)) loadLadder = true;
        if(loadLadder)
        {
            player.transform.position = new Vector3(ladder.transform.position.x-0.1f, player.transform.position.y,player.transform.position.z);
            player.GetComponent<foot>().enabled = false;
            playerAnimator.SetBool("isclimb", true);
            playerAnimator.SetBool("iswalk", false);
            upArrow.SetActive(false);
            downArrow.SetActive(false);
        }
        else
        {
            player.GetComponent<foot>().enabled = true;
        }

        if (loadLadder && Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += new Vector3(0f, 1f * Time.deltaTime, 0f);

        }
        else if (loadLadder && Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position += new Vector3(0f, -1f * Time.deltaTime, 0f);
        }
    }
    public void initState()
    {
        loadLadder = false;
        player.GetComponent<foot>().enabled = true;
        playerAnimator.SetBool("isclimb", false);
    }
}
