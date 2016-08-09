namespace Vend
{
    /// <summary>
    /// an action taken ny a customer, e.g. inserting money or selecting a product
    /// </summary>
    public abstract class CustomerActionResult
    {
        /// <summary>
        /// the resulting change returned, if any
        /// </summary>
        public decimal? Change { get; set; }
    }
}
