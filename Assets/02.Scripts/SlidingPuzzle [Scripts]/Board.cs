using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private	GameObject	tilePrefab;								// 숫자 타일 프리팹
	[SerializeField]
	private	Transform	tilesParent;							// 타일이 배치되는 "Board" 오브젝트의 Transform

	public	List<Tile>	tileList;								// 생성한 타일 정보 저장

	private	Vector2Int	puzzleSize = new Vector2Int(4, 4);		// 4x4 퍼즐
	private	float		neighborTileDistance = 102;             // 인접한 타일 사이의 거리. 별도로 계산할 수도 있다.
	public GameObject go;
	public	Vector3		EmptyTilePosition { set; get; }			// 빈 타일의 위치
	public	int			Playtime { private set; get; } = 0;		// 게임 플레이 시간
	public	int			MoveCount { private set; get; } = 0;    // 이동 횟수

    public void Awake()
    {
		tileList = new List<Tile>();
	}
    private void OnEnable()
	{
		
		StartCoroutine("st");
	}
	private IEnumerator st()
	{
		
		

		DestroyTile();
		SpawnTiles();

		UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

		// 현재 프레임이 종료될 때까지 대기
		yield return new WaitForEndOfFrame();

		// tileList에 있는 모든 요소의 SetCorrectPosition() 메소드 호출
		tileList.ForEach(x => x.SetCorrectPosition());

		StartCoroutine("OnSuffle");
		// 게임시작과 동시에 플레이시간 초 단위 연산
		StartCoroutine("CalculatePlaytime");
	}
    private void DestroyTile()
    {
		if (tileList.Count != 0)
		{
            print("널이아니에용"+ tileList.Count);
			
			tileList.Clear();
			for (int i = 0; i <= 15; i++)
			{
				GameObject obj = transform.GetChild(i).gameObject;
				print("삭제할 객체는 : " + obj.name);
				Destroy(obj);
			}
			
		}
		else
			print("널이에용" + tileList.Count);
	}
    private void SpawnTiles()
	{
		print("타일만들어용");

		for (int y = 0; y < puzzleSize.y; ++y)
		{
			for (int x = 0; x < puzzleSize.x; ++x)
			{
				GameObject clone = Instantiate(tilePrefab, tilesParent);
				Tile tile = clone.GetComponent<Tile>();

				tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

				tileList.Add(tile);
				print(tileList.Count);
			}
		}
	}

	private IEnumerator OnSuffle()
	{
		float current	= 0;
		float percent	= 0;
		float time		= 1.5f;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / time;

			int index = Random.Range(0, puzzleSize.x * puzzleSize.y);
			tileList[index].transform.SetAsLastSibling();

			yield return null;
		}

		// 원래 셔플 방식은 다른 방식이었는데 UI, GridLayoutGroup을 사용하다보니 자식의 위치를 바꾸는 것으로 설정
		// 그래서 현재 타일리스트의 마지막에 있는 요소가 무조건 빈 타일
		EmptyTilePosition = tileList[tileList.Count-1].GetComponent<RectTransform>().localPosition;
	}

	public void IsMoveTile(Tile tile)
	{
		if ( Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
		{
			Vector3 goalPosition = EmptyTilePosition;

			EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

			tile.OnMoveTo(goalPosition);

			// 타일을 이동할 때마다 이동 횟수 증가
			MoveCount ++;
		}
	}

	public void IsGameOver()
	{
		List<Tile> tiles = tileList.FindAll(x => x.IsCorrected == true);

		Debug.Log("Correct Count : "+tiles.Count);
		if ( tiles.Count == puzzleSize.x * puzzleSize.y - 1 )
		{
			//TODO: 산소통 처리
			Debug.Log("GameClear");
			PuzzleDataManager.Data_Oxygen_DarkRoom = true;
			// 게임 클리어했을 때 시간계산 중지
			StopCoroutine("CalculatePlaytime");
			// Board 오브젝트에 컴포넌트로 설정하기 때문에
			// 그리고 한번만 호출하기 때문에 변수를 만들지 않고 바로 호출..
			//go.GetComponent<UIController>().OnResultPanel();
		}
	}

	private IEnumerator CalculatePlaytime()
	{
		while ( true )
		{
			Playtime ++;

			yield return new WaitForSeconds(1);
		}
	}
}
