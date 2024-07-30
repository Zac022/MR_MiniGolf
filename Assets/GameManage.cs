using Meta.XR.MRUtilityKit;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public TextMeshProUGUI ScoreText;
    public static int score = 0;
    public GameObject ballPrefab;
    public GameObject UIPanel;
    public Transform centerEye;
    public Transform playerPosition;

    private MRUKAnchor floor;
    private Vector2 floorSize;


    public UnityEvent OnBallEnterHole;
    public UnityEvent OnClubHitBall;




    public void SetupColliderOnFloor(MRUKRoom room)
    {
       floor = room.FloorAnchor;
       floorSize.y = floor.PlaneRect.Value.height;
       floorSize.x = floor.PlaneRect.Value.width;
       BoxCollider sample = floor.gameObject.AddComponent<BoxCollider>();
       sample.size = floorSize;
   
    }

    public void PlayBallEnterHoleSound()
    {

       OnBallEnterHole?.Invoke();
     
    }

    public void PlayClubHitBallSound()
    {
       
        
        OnClubHitBall?.Invoke();
        
    }

    private void Start()
    { 
        MRUK.Instance.RoomCreatedEvent.AddListener(SetupColliderOnFloor);
        SpawnBall();
        SpawnStartPanel();
    }

    private void SpawnStartPanel()
    {
        UIPanel.transform.position = new Vector3(playerPosition.position.x + 0.2f, playerPosition.position.y + 0.8f, playerPosition.position.z + 0.2f); ;
    }

    public void Update()
    {
        SetPositionUIPanel();
    }

    private void SetPositionUIPanel()
    {
       
        UIPanel.transform.forward = centerEye.forward;

    }

    private void SpawnBall()
    {
        Instantiate(ballPrefab, centerEye.position, Quaternion.identity);
    }


    public void UpdateScore()
    {
        score++;
        ScoreText.text = "SCORE :" + score;
    }

    private void OnDisable()
    {
        MRUK.Instance.RoomCreatedEvent.RemoveListener(SetupColliderOnFloor);
    }

    public void ReplayGame()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateBall()
    {
       SpawnBall();
    }


    public void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

    }
}
