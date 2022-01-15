namespace PoCStrategyFactory.Data
{
	/// <summary>
	/// EN: Class that represents information that could be in a database about a payment channel.
	/// ES: Clase que representa información que podría haber en una base de datos sobre un canal de pago.
	/// </summary>
	public class PaymentChannel
	{
		/// <summary>
		/// EN: Payment channel id.
		/// ES: Id del canal de pago.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// EN: Payment channel type.
		/// ES: Tipo de canal de pago.
		/// </summary>
		public PaymentChannelType ChannelType { get; set; }

		/// <summary>
		/// EN: Type of discount to apply for using a certain payment channel.
		/// ES: Tipo de descuento a aplicar por usar un canal de pago determinado.
		/// </summary>
		public DiscountType? DiscountType { get; set; }

		/// <summary>
		/// EN: Value of the discount to application according to the type.
		/// ES: Valor del descuento a aplication según el tipo.
		/// </summary>
		public decimal DiscountValue { get; set; }
	}
}
