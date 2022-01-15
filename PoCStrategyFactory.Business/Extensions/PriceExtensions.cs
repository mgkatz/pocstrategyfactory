using PoCStrategyFactory.Data;

namespace PoCStrategyFactory.Business.Extensions
{
	/// <summary>
	/// EN: Class to extend functionalities related to prices.
	/// ES: Clase para extender funcionalidades relativas a los precios.
	/// </summary>
	internal static class PriceExtensions
	{
		/// <summary>
		/// EN: Extension method to apply a percentage on a given price.
		/// ES: Método de extensión para aplicar un porcentaje sobre un precio dado.
		/// </summary>
		/// <param name="price">
		/// EN: The given price.
		/// ES: El precio dado.
		/// </param>
		/// <param name="percentage">
		/// EN: The percentage to be applied in the price.
		/// ES: El porcentaje a aplicar en el precio.
		/// </param>
		/// <returns>
		/// EN: The price given plus the applied percentage.
		/// ES: El precio dado más el porcentaje aplicado.
		/// </returns>
		public static decimal ApplyPercentage(this decimal price, decimal percentage)
			=> percentage == 0 ? price : price * (1 + (percentage / 100));

		/// <summary>
		/// EN: Extension method to apply a discount that can be fixed or proportional on a given price.
		/// ES: Método de extensión para aplicar un descuento que puede ser fijo o proporcional sobre un precio dado.
		/// </summary>
		/// <param name="price">
		/// EN: The given price.
		/// ES: El precio dado.
		/// </param>
		/// <param name="discountType">
		/// EN: Type of discount to apply.
		/// ES: Tipo de descuento a aplicar.
		/// </param>
		/// <param name="value">
		/// EN: Value of the discount to apply according to the type of discount.
		/// ES: Valor del descuento a aplicar según el tipo de descuento.
		/// </param>
		/// <returns></returns>
		public static decimal ApplyDiscount(this decimal price, DiscountType? discountType, decimal value) => value == 0
			? price
			: discountType switch
			{
				DiscountType.Fixed => price - value,
				DiscountType.Percentage => price - (value * price / 100),
				_ => price,
			};
	}
}
