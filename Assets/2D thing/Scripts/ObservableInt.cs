namespace Assets._2D_thing.Scripts
{
    public class ObservableInt
    {
        private int value;
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public event System.Action<int> OnValueChanged;

        public ObservableInt()
        {
            value = 0;
        }

        public ObservableInt(int initialValue)
        {
            value = initialValue;
        }
    }
}