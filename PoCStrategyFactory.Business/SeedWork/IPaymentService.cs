using PoCStrategyFactory.Business.Models;

namespace PoCStrategyFactory.Business.SeedWork
{
	/// <summary>
	/// EN: Allows you to implement a service that processes payments.
	/// ES: Permite implementar un servicio que procese pagos.
	/// </summary>
	public interface IPaymentService
	{
		/// <summary>
		/// EN: It allows the calculation of the final price according to the payment information provided.
		/// ES: Permite el cálculo del precio final de acuerdo a la información de pago proporcionada.
		/// </summary>
		/// <param name="paymentInfo">
		/// EN: The payment information.
		/// ES: La información del pago.
		/// </param>
		/// <returns>
		/// EN: The final price.
		/// ES: El precio final.
		/// </returns>
		decimal CalculatePrice(PaymentInfoDto paymentInfo);
	}
}
