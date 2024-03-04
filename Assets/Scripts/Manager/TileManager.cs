using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    Tile[,] _tiles = new Tile[6, 6];
    public Tile[,] Tiles { get { return _tiles; } }
    int Rows { get { return _tiles.GetLength(0); } }
    int Cols { get { return _tiles.GetLength(1); } }
    int row, col;

    //게임이 시작할 때
    public void Init()
    {
        if (IsEmpty<Tile>(_tiles))
        {
            GameObject obj = GameObject.Find("TileMapGroup");
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Cols; j++)
                {
                    _tiles[i, j] = obj.transform.GetChild(i).GetChild(j).GetComponent<Tile>();
                }
            }
        }
    }

    //게임이 종료될 때 / 중단할 때
    public void Clear()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                _tiles[i, j] = null;
            }
        }
    }

    public void TileReposition()
    {
        Init();

        for (int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Cols; j++)
            {
                if(_tiles[i, j].transform.childCount == 0 || (_tiles[i, j].transform.childCount != 0 && _tiles[i, j].transform.GetComponentInChildren<Unit>()))
                {
                    if(!_tiles[i, j].transform.GetComponentInChildren<Unit>())
                    {
                        _tiles[i, j].element = Managers.Game.deckElement[Random.Range(0, Managers.Game.deckElement.Count)];
                        _tiles[i, j].ChangeColor(_tiles[i, j].element);
                    }
                }
                
            }
        }
    }

    //_tiles가 비어있는지 확인
    bool IsEmpty<T>(T[,] array)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (Equals(array[i, j], null))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAroundTile(Tile tile, ElementObject.Element element)
    {
        FindTile(tile);

        //주변 1칸에 같은 속성의 타일이 있다면
        //사이드에 있는 타일의 경우를 따로 조건을 만들어줘야함
        if(row == 0)    //상단 타일의 경우
        {
            if(col == 0)
            {
                if(element == _tiles[row, col].element || element == _tiles[row, col + 1].element || element == _tiles[row + 1, col].element || element == _tiles[row + 1, col + 1].element)
                {
                    return true;
                }
            }
            else if(col == 5)
            {
                if (element == _tiles[row, col - 1].element || element == _tiles[row, col].element || element == _tiles[row + 1, col - 1].element || element == _tiles[row + 1, col].element)
                {
                    return true;
                }
            }
            else
            {
                if (element == _tiles[row, col - 1].element || element == _tiles[row, col].element || element == _tiles[row, col + 1].element ||
                    element == _tiles[row + 1, col - 1].element || element == _tiles[row + 1, col].element || element == _tiles[row + 1, col + 1].element)
                {
                    return true;
                }
            }
        }   
        else if(col == 0)   //좌측 타일의 경우
        {
            if(row == 5)
            {
                if(element == _tiles[row - 1, col].element || element == _tiles[row - 1, col + 1].element || 
                    element == _tiles[row, col].element || element == _tiles[row, col + 1].element)
                {
                    return true;
                }
            }
            else
            {
                if(element == _tiles[row - 1, col].element || element == _tiles[row - 1, col + 1].element ||
                     element == _tiles[row, col].element || element == _tiles[row, col + 1].element ||
                     element == _tiles[row + 1, col].element || element == _tiles[row + 1, col + 1].element)
                {
                    return true;
                }
            }
        }
        else if(col == 5)   //우측 타일의 경우
        {
            if (row == 5)
            {
                if (element == _tiles[row - 1, col - 1].element || element == _tiles[row - 1, col].element ||
                    element == _tiles[row, col - 1].element || element == _tiles[row, col].element)
                {
                    return true;
                }
            }
            else
            {
                if (element == _tiles[row - 1, col - 1].element || element == _tiles[row - 1, col].element ||
                    element == _tiles[row, col - 1].element || element == _tiles[row, col].element ||
                    element == _tiles[row + 1, col - 1].element || element == _tiles[row + 1, col].element)
                {
                    return true;
                }
            }
        }
        else if(row == 5)   //하단 타일의 경우
        {
            if(element == _tiles[row - 1, col - 1].element || element == _tiles[row - 1, col].element || element == _tiles[row - 1, col + 1].element ||
                element == _tiles[row, col - 1].element || element == _tiles[row, col].element || element == _tiles[row, col + 1].element)
            {
                return true;
            }
        }
        else    //그 외 타일의 경우
        {
            if (element == _tiles[row - 1, col - 1].element || element == _tiles[row - 1, col].element || element == _tiles[row - 1, col + 1].element ||
            element == _tiles[row, col - 1].element || element == _tiles[row, col].element || element == _tiles[row, col + 1].element ||
            element == _tiles[row + 1, col - 1].element || element == _tiles[row + 1, col].element || element == _tiles[row + 1, col + 1].element)
            {
                return true;
            }
        }
        return false;
    }

    //인접한 타일이 유닛이 이동할 수 있는 타일인지 확인 move 타일이 tile 타일의 속성과 같으면 true
    public bool CheckRoad(Tile tile, Tile move)
    {
        if(TileDistance(tile, move) == 1)   //인접한 타일인지 확인
        {
            if(tile.element == move.element)    //유닛이 있던 타일과 움직이려는 타일의 속성이 같다면
            {
                return true;
            }
        }
        return false;
    }

    void FindTile(Tile tile)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if(_tiles[i, j] == tile)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    public int TileDistance(Tile tile1, Tile tile2)
    {
        int row1 = 0, col1 = 0, row2 = 0, col2 = 0;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if(_tiles[i, j] == tile1)
                {
                    row1 = i;
                    col1 = j;
                }
                else if(_tiles[i, j] == tile2)
                {
                    row2 = i;
                    col2 = j;
                }
            }
        }

        if(Mathf.Abs(row1 - row2) > Mathf.Abs(col1 - col2))
        {
            return Mathf.Abs(row1 - row2);
        }
        else
        {
            return Mathf.Abs(col1 - col2);
        }
    }

    public void ChangeTilesLayer(int layer = 2)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                _tiles[i, j].GetComponent<Canvas>().sortingOrder = layer;
            }
        }
    }

    //유닛 있는 타일 - 밝음 / 유닛 없는 타일 - 어두움
    public void ChangeLayersUT()
    {
        Managers.Game.darkField.sortingOrder = 3;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if(_tiles[i, j].transform.childCount > 0 && _tiles[i, j].transform.GetChild(0).GetComponent<Unit>())
                    _tiles[i, j].GetComponent<Canvas>().sortingOrder = 4;
                else
                    _tiles[i, j].GetComponent<Canvas>().sortingOrder = 2;
            }
        }
    }

    //유닛, 아이템 있는 타일 - 어두움 / 유닛, 아이템 없는 타일 - 밝음
    public void ChangeLayersTU()
    {
        Managers.Game.darkField.sortingOrder = 3;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (_tiles[i, j].transform.childCount == 0)
                    _tiles[i, j].GetComponent<Canvas>().sortingOrder = 4;
                else
                    _tiles[i, j].GetComponent<Canvas>().sortingOrder = 2;
            }
        }
    }

    public void LayerReset()
    {
        ChangeTilesLayer();
        Managers.Game.darkField.sortingOrder = 1;
    }
}
