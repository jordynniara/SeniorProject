using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public struct ScoreSet : IComparer<ScoreSet>
    {
        public string initials;
        public int score;

        public ScoreSet(int sc)
        {
            initials = "";
            score = sc;
        }
        public ScoreSet(string init, int sc)
        {
            initials = init;
            score = sc;
        }

        int IComparer<ScoreSet>.Compare(ScoreSet x, ScoreSet y)
        {
            //sorts in descending order
            if (x.score > y.score) return -1;
            if (x.score < y.score) return 1;
            return 0;
        }
    }

    private const string path = "Assets/Resources/ScoreSheet.txt";
    private const int MAX_NUM_SCORES = 10;
    public static string inputInitial;
    private SubmitInput submitInput = new SubmitInput();

    public static List<ScoreSet> scoreList = new List<ScoreSet>(MAX_NUM_SCORES);//highest score @ index 0
    public GameObject initialsGroup;
    public GameObject scoresGroup;



	private void Awake()
	{
        if (scoreList.Count == 0)
            ReadToList();
        UpdateLeaderboard();//post last saved scores to leaderboard
	}

	private void Update()
	{
		if(GameEnder.toLeaderboard)
        {
            AddToScoreList(Score.score);
            GameEnder.toLeaderboard = false;
        }
	}

    //called by Score class to see if score is a high score
	public static bool NewScoreCheck(int newScore)
    {
        if (newScore == 0)
            return false;
        if (scoreList.Count < MAX_NUM_SCORES)
        {
            return true;
        }
        //see if there is a new score is greater than some other score in the list
        if(scoreList.Exists(x => x.score < newScore))
        {
            return true;
        }
        return false;
    }


    private void AddToScoreList(int newScore)
    {
        if (newScore == 0)
            return;
        
        ScoreSet set = new ScoreSet(inputInitial, newScore);
        scoreList.Add(set); //add new score to the list

        scoreList.Sort(new ScoreSet()); // sort list

        if (scoreList.Count > MAX_NUM_SCORES) //if the list is above max
        {
            scoreList.RemoveRange(MAX_NUM_SCORES - 1, scoreList.Count - MAX_NUM_SCORES); //remove everything after max number of scores
        }

        UpdateLeaderboard();
    }

     public static void ReadToList()
    {
        if (scoreList.Count > 0)
            return;
        using (StreamReader reader = new StreamReader(path, true))
        {
            string line;
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');//initials and score separated by space
                    string initials = words[0];
                    int score;
                    int.TryParse(words[1], out score);

                    //create new object and add to list
                    scoreList.Add(new ScoreSet(initials, score));
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    private void UpdateLeaderboard()
    {
        // Get the text components of each player initials and score
        Text [] initials = initialsGroup.GetComponentsInChildren<Text>();
        Text [] scores = scoresGroup.GetComponentsInChildren<Text>();

        int i = 0;
        foreach(ScoreSet set in scoreList)
        {
            //set the text
            initials[i].text = set.initials;
            scores[i].text = set.score.ToString();
            i++;
        }

        //set remaining fields to empty string
        if(i < scoreList.Count)
        {
            initials[i].text = "";
            scores[i].text = "";
            i++;
        }
    }

    //called when game is closed in order to update
    public static void WriteToFile()
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            try
            {
                //clear contents of text file
                File.WriteAllText(path, "");

                //write list to text file- format: initials [space] score\n
                foreach (ScoreSet obj in scoreList)
                {
                    writer.WriteLine(obj.initials + " " + obj.score.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

        }
    }
}
