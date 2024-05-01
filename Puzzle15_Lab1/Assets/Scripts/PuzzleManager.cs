using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> cubes;
    [SerializeField] private GameObject emptySpace;
    [SerializeField] private GameObject winCube;
    private bool gameEnded = false;

    void Start(){
        Shuffle();
    }

    public void Shuffle(){
        for (int i = 0; i < 1000; i++){
            int randomIndex1 = Random.Range(0, cubes.Count);
            int randomIndex2 = Random.Range(0, cubes.Count);
            Vector3 tempPosition = cubes[randomIndex1].transform.position;
            cubes[randomIndex1].transform.position = cubes[randomIndex2].transform.position;
            cubes[randomIndex2].transform.position = tempPosition;
        }
    }

    public void MoveCubeToEmptySpace(GameObject cube){
        if (!gameEnded && IsAdjacentToEmptySpace(cube)){
            Vector3 tempPosition = cube.transform.position;
            cube.transform.position = emptySpace.transform.position;
            emptySpace.transform.position = tempPosition;
            if (CheckForWin()){
                GameWon();
            }
        }
    }


    private bool IsAdjacentToEmptySpace(GameObject cube){
        Vector3 cubePosition = cube.transform.position;
        Vector3 emptySpacePosition = emptySpace.transform.position;
        return Mathf.Abs(cubePosition.x - emptySpacePosition.x) + Mathf.Abs(cubePosition.y - emptySpacePosition.y) + Mathf.Abs(cubePosition.z - emptySpacePosition.z) == 1;
    }

    private bool CheckForWin(){
        for (int i = 0; i < cubes.Count; i++){
            Cube cubeScript = cubes[i].GetComponent<Cube>();
            if (cubes[i].transform.position != cubeScript.initialPosition){
                return false;
            }
        }
        return true;
    }

    private void GameWon(){
        gameEnded = true;
        winCube.SetActive(true);
    }

    void Update(){
        if (!gameEnded && Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                GameObject clickedCube = hit.collider.gameObject;
                if (cubes.Contains(clickedCube)){
                    MoveCubeToEmptySpace(clickedCube);
                }
            }
        }
    }
}
