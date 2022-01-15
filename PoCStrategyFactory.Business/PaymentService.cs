using PoCStrategyFactory.Business.Models;
using PoCStrategyFactory.Business.SeedWork;

namespace PoCStrategyFactory.Business
{
	/// <summary>
	/// EN: Implementation of a service that processes payments.
	/// ES: Implementación de un servicio que procesa pagos.
	/// </summary>
	public class PaymentService : IPaymentService
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
		public decimal CalculatePrice(PaymentInfoDto paymentInfo)
		{
			// EN: The PaymentFactory abstract class has only one method exposed, which is in charge of knowing which is the appropriate factory based on the payment channel. We don't care what the specific instance is since the factory pattern abstracts us away and makes us agnostic of that information.
			// ES: La clase abstracta PaymentFactory tiene un sólo método expuesto que es el que se encarga de saber cuál es la factory adecuada basada en el canal de pago. No nos importa cuál es la instancia específica ya que el patrón de factory nos abstrae y nos vuelve agnósticos de esa información.
			PaymentFactory factory = PaymentFactory.CreatePriceFactory(paymentInfo.PaymentChannelType);

			// EN: The instance obtained (it does not matter which one specifically) will have a method exposed that is responsible for calculating the final price.
			// ES: La instancia obtenida (no importa cuál especifícamente) va a tener expuesta un método que se encarga de calcular el precio final.
			return factory.CalculatePrice(paymentInfo);
		}
	}
}
