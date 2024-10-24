namespace MVP
{
    public abstract class Presenter
    {
        protected Model Model;

        public Presenter(Model model)
        {
            Model = model;
        }

        public void OnCellClicked(Cell cell)
        {
            Model.SetSighToCell(cell);
            Model.TryToWin();
        }
    }
}
