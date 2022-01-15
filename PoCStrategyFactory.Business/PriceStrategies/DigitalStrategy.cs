using PoCStrategyFactory.Data;
using PoCStrategyFactory.Business.Extensions;
using PoCStrategyFactory.Business.Models;
using PoCStrategyFactory.Business.SeedWork;

namespace PoCStrategyFactory.Business.PriceStrategies
{
	/// <summary>
	/// EN: Strategy implemented for payment through a digital channel.
	/// ES: Estrategia implementada para el pago mediante un canal digital.
	/// </summary>
	internal class DigitalStrategy : IPriceStrategy
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
		public decimal GetFinalPrice(PaymentInfoDto paymentInfo)
		{
			// EN: We obtain the payment method information through a mock up that returns data simulating what the data layer would do.
			// ES: Obtenemos la información del método de pago a través de un mock que retorna datos simulando lo que haría la capa de datos.
			PaymentMethod paymentMethod = TestDataProvider.GetPaymentMethodInfo(paymentInfo.PaymentMethodId);

			// EN: We obtain the payment channel information through a mock up that returns data simulating what the data layer would do.
			// ES: Obtenemos la información del canal de pago a través de un mock que retorna datos simulando lo que haría la capa de datos.
			PaymentChannel paymentChannel = TestDataProvider.GetPaymentChannelInfo(PaymentChannelType.Digital);

			// EN: Using an extension method for applying percentages and discounts, the final price is calculated and returned based on the original price, the percentage and the discount indicated by the information obtained from the data layer.
			// ES: Usando un método de extensión para la aplicación de porcentajes y descuentos, se calcula y se retorna el precio final basados en el precio original, el porcentaje y el descuento que indica la información obtenida de la capa de datos.
			return paymentInfo.Price
				.ApplyPercentage(paymentMethod.Percentage)
				.ApplyDiscount(paymentChannel.DiscountType, paymentChannel.DiscountValue);
		}
	}
}
