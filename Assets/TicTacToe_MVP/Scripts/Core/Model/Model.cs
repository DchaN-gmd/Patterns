using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVP
{
    public abstract class Model
    {
        public const int ValueToWin = 3;

        public readonly int Height;
        public readonly int Width;
        protected SignType CurrentSign;

        protected View View;

        public Model(View view, int height, int width, SignType startSignType)
        {
            View = view;
            Height = height;
            Width = width;
            CurrentSign = startSignType;
        }

        public virtual void SetSighToCell(Cell cell)
        {
            if (cell.Sign != SignType.None) return;

            cell.SetSign(CurrentSign);
            View.UpdateCellView(cell);

            ChangeCurrentSign();
        }

        public virtual void TryToWin()
        {
            if (IsWin()) View.ShowWin();
        }

        private void ChangeCurrentSign()
        {
            switch (CurrentSign)
            {
                case SignType.Cross:
                    CurrentSign = SignType.Circle;
                    break;
                case SignType.Circle:
                    CurrentSign = SignType.Cross;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(CurrentSign));
            }
        }

        private bool IsWin()
        {
            var cells = View.Cells;

            var cellsDictionary = CreateCellDictionary();

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Sign == SignType.None) continue;

                var maxCount = GetMaxMatchCount(cellsDictionary, i, cells);

                if (maxCount >= ValueToWin) return true;

            }
            return false;
        }

        private int GetMaxMatchCount(Dictionary<Vector2, int> cellsDictionary, int index, IReadOnlyList<Cell> cells)
        {
            var position = cellsDictionary.First((x) => x.Value == index).Key;

            var horizontal = CalculateAxisMatchCount(cellsDictionary, new Vector2Int(1, 0),
                position, cells[index].Sign);

            var vertical = CalculateAxisMatchCount(cellsDictionary, new Vector2Int(0, 1),
                position, cells[index].Sign);

            var diagonalFirst = CalculateAxisMatchCount(cellsDictionary, new Vector2Int(1, 1),
                position, cells[index].Sign);

            var diagonalSecond = CalculateAxisMatchCount(cellsDictionary, new Vector2Int(-1, 1),
                position, cells[index].Sign);

            var maxCount = Mathf.Max(horizontal, vertical, diagonalFirst, diagonalSecond);

            return maxCount;
        }

        private Dictionary<Vector2, int> CreateCellDictionary()
        {
            var cellsDictionary = new Dictionary<Vector2, int>();
            int index = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    cellsDictionary.Add(new Vector2(i, j), index);
                    index++;
                }
            }

            return cellsDictionary;
        }

        private int CalculateAxisMatchCount(Dictionary<Vector2, int> cellsDictionary, Vector2 direction, Vector2 position, SignType signType)
        {
            var directionCount = 1;
            var cells = View.Cells;

            var currentPosition = position + direction;

            directionCount = DirectionMatchCount(cellsDictionary, direction, signType, currentPosition, cells);

            currentPosition = position - direction;

            directionCount = DirectionMatchCount(cellsDictionary, -direction, signType, currentPosition, cells);

            return directionCount;
        }

        private int DirectionMatchCount(Dictionary<Vector2, int> cellsDictionary, Vector2 direction, SignType signType,
            Vector2 currentPosition, IReadOnlyList<Cell> cells)
        {
            var count = 1;

            while (cellsDictionary.TryGetValue(currentPosition, out var cell))
            {
                var index = cellsDictionary[currentPosition];
                if (cells[index].Sign != signType) break;

                count++;
                currentPosition += direction;
            }

            return count;
        }
    }
}