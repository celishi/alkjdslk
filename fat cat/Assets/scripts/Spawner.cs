using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPoint; //SpawnPoint, to get Position to Spawn New Tile of Obstacles
    public int PlayerDistance; //Distance Player Has Traveled
    public int DistancePerTile; //Distance Traveled Necessary to Instantiate new Tile
    public List<GameObject> TilesOfObstacles; //List of Obstacle Tiles
    private int PreviousModResult = -1; //Used to Check if New Tile Is Needed
    private List<int> ListOfChoices = new List<int> { 0, 1, 2, 3, 4, 5, 6 }; //List of Valid Choices, number of tiles, TBD 
    private List<int> ListOnCD = new List<int> { }; //List of Tiles on Cooldown
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        int remove;
        while (i < 4)
        {
            remove = Random.Range(0, ListOfChoices.Count);
            ListOnCD.Add(remove);
            ListOfChoices.Remove(remove);
            i++;
        }
        //Sets 4 Tiles on Cooldown at the Start
    }

    // Update is called once per frame
    void Update()
    {
        int ChoiceOfSpawn = Random.Range(0, ListOfChoices.Count); //Chooses a Random Tile to Spawn

        if (PlayerDistance % DistancePerTile < PreviousModResult) //Checks if Player Has Passed Threshold to Spawn New Tile by Checking if Player Has JUST Passed Threshold
        {
            ListOnCD.Add(ChoiceOfSpawn); //Adds ChoiceOfSpawn to Cooldown
            ListOfChoices.Remove(ChoiceOfSpawn); //Removes ChoiceOfSpawn from ListOfChoices
            ListOfChoices.Add(ListOnCD[0]); //Adds First Value of ListOnCD to ListOfChoices
            ListOnCD.Remove(ListOnCD[0]); //Removes First Value of ListOnCD
            Instantiate(TilesOfObstacles[ListOfChoices[ChoiceOfSpawn]], SpawnPoint.transform.position, Quaternion.identity); //Instantiate, Creates, Spawns the Tile Chosen
        }
        PreviousModResult = PlayerDistance % DistancePerTile; //Used to Determine if Player has Passed Threshold
    }
}
