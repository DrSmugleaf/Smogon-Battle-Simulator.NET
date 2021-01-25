namespace SmogonBattleSimulator.NET.Generations.I.Modifier
{
    public delegate void CancelDelegate();

    public class ModifierToken : IModifierToken
    {
        public ModifierToken(CancelDelegate @delegate)
        {
            Delegate = @delegate;
        }

        private CancelDelegate Delegate { get; }

        public void Cancel()
        {
            Delegate();
        }
    }
}
