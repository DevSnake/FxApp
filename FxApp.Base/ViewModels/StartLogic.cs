namespace FxApp.Base.ViewModels
{
    public class StartLogic: IStartMethods
    {
        private IStart _start;

        public StartLogic(IStart start)
        {
            this._start = start;
        }
    }
}
