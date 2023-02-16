using System;

namespace PlayerComponents
{
    public class Wallet
    {
        private float _amount;
        public float Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnAmountChanged?.Invoke(Amount);
            }
        }

        public event Action<float> OnAmountChanged;

        public void Add(float amount)
        {
            Amount += amount;
        }

        public void Remove(float amount)
        {
            Amount -= amount;
        }
    }
}