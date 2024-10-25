using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVP
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private List<Cell> _cells;
        [SerializeField] private SignParameter[] _signParameters;

        public IReadOnlyList<Cell> Cells => _cells;

        public event Action<Cell> CellClicked;

        private void OnEnable()
        {
            foreach (var cell in _cells)
            {
                cell.Clicked += OnCellClicked;
            }
        }

        private void OnDisable()
        {
            foreach (var cell in _cells)
            {
                cell.Clicked -= OnCellClicked;
            }
        }

        public void UpdateCellView(Cell cell)
        {
            var parameter = _signParameters.FirstOrDefault((x) => x.Type == cell.Sign);
            cell.SetSprite(parameter.Sprite);
        }

        public void ShowWin()
        {
            Debug.Log("Win");
        }

        private void OnCellClicked(Cell cell) =>
            CellClicked?.Invoke(cell);
    }
}
