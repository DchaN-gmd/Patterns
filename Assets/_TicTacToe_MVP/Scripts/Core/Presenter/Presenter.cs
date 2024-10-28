namespace MVP
{
    public class Presenter
    {
        protected Model Model;
        protected View View;

        public Presenter(Model model, View view)
        {
            Model = model;
            View = view;
        }

        public void Subscribe()
        {
            SubscribeToModel();
            SubscribeToView();
        }

        public void Unsubscribe()
        {
            UnsubscribeToModel();
            UnsubscribeToView();
        }

        private void SubscribeToModel()
        {
            Model.CellGettingSign += View.UpdateCellView;
            Model.Winning += View.ShowWin;
        }

        private void SubscribeToView()
        {
            View.CellClicked += OnCellClicked;
        }

        private void UnsubscribeToModel()
        {
            Model.CellGettingSign -= View.UpdateCellView;
            Model.Winning -= View.ShowWin;
        }

        private void UnsubscribeToView()
        {
            View.CellClicked -= OnCellClicked;
        }

        private void OnCellClicked(Cell cell)
        {
            Model.SetSighToCell(cell);
            Model.TryToWin(View.Cells);
        }
    }
}
