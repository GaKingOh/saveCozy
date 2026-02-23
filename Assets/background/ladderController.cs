using Unity.VisualScripting;
using UnityEngine;

public class ladderController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject ladderMover;
    public Collider2D playercol;
    public Collider2D upEndFlagcol;
    bool player = false;
    public bool upEnd = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playercol.IsTouching(upEndFlagcol))
        {
            upEnd = true;
        }
        else
        {
            upEnd = false;
        }
    }
    public bool playerBeside()
    {
        return player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ladderMover.GetComponent<ladderMoveController>().loadLadder && !upEnd) upArrow.SetActive(true);
        else if(!ladderMover.GetComponent<ladderMoveController>().loadLadder && upEnd) downArrow.SetActive(true);
        player = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!ladderMover.GetComponent<ladderMoveController>().loadLadder && !upEnd) upArrow.SetActive(true);
        else if (!ladderMover.GetComponent<ladderMoveController>().loadLadder && upEnd) downArrow.SetActive(true);
        player = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        player = false;
        ladderMover.GetComponent<ladderMoveController>().initState();
    }
}
