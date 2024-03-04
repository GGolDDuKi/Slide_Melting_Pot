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

    //������ ������ ��
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

    //������ ����� �� / �ߴ��� ��
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

    //_tiles�� ����ִ��� Ȯ��
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

        //�ֺ� 1ĭ�� ���� �Ӽ��� Ÿ���� �ִٸ�
        //���̵忡 �ִ� Ÿ���� ��츦 ���� ������ ����������
        if(row == 0)    //��� Ÿ���� ���
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
        else if(col == 0)   //���� Ÿ���� ���
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
        else if(col == 5)   //���� Ÿ���� ���
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
        else if(row == 5)   //�ϴ� Ÿ���� ���
        {
            if(element == _tiles[row - 1, col - 1].element || element == _tiles[row - 1, col].element || element == _tiles[row - 1, col + 1].element ||
                element == _tiles[row, col - 1].element || element == _tiles[row, col].element || element == _tiles[row, col + 1].element)
            {
                return true;
            }
        }
        else    //�� �� Ÿ���� ���
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

    //������ Ÿ���� ������ �̵��� �� �ִ� Ÿ������ Ȯ�� move Ÿ���� tile Ÿ���� �Ӽ��� ������ true
    public bool CheckRoad(Tile tile, Tile move)
    {
        if(TileDistance(tile, move) == 1)   //������ Ÿ������ Ȯ��
        {
            if(tile.element == move.element)    //������ �ִ� Ÿ�ϰ� �����̷��� Ÿ���� �Ӽ��� ���ٸ�
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

    //���� �ִ� Ÿ�� - ���� / ���� ���� Ÿ�� - ��ο�
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

    //����, ������ �ִ� Ÿ�� - ��ο� / ����, ������ ���� Ÿ�� - ����
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
