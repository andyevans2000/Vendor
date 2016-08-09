namespace Vend
{
    /// <summary>
    /// Represents a coin object e.g a 50 cent piece
    /// </summary>
    public class Coin
    {   
        /// <summary>
        /// size of the coin e.g. 20 mm diameter
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// weight of the coin e.g. 5g
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// monentry value of the coin e.g. 10 cents
        /// </summary>
        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"Coin value {Value} - size {Size} - weight {Weight}";
        }
    }
}
