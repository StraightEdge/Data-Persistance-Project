using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance Instance { get; private set; }

    public string PlayerName;
    public int BestScore;
    public string BestScorePlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public class SaveData
    {
        public int BestScore;
        public string BestScorePlayerName;
    }

}
