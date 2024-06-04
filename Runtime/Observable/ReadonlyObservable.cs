namespace SBaier
{
    public interface ReadonlyObservable<T>
    {
        public event Observable<T>.ValueChanged OnValueChanged;
        T Value { get; }
    }
}
