using System;
namespace ICT.DAL.DB
{
	/// <summary>
	/// Area class
	/// </summary>
	public class Area
	{
		/// <summary>
		/// Primary key of Area
		/// </summary>
        [Key]
		public int Id { get; set; }
		/// <summary>
		/// Foreign key from the table Building
		/// </summary>
		public int Id_Building { get; set; }
		public virtual Building Building { get; set; }
		/// <summary>
		/// Foreign key from the table Area Type
		/// </summary>
		public int Id_Type { get; set; }
		/// <summary>
		/// Nome da área
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Piso da área
		/// </summary>
		public string Floor { get; set; }
		/// <summary>
		/// Número de bolas de fogo numa área
		/// </summary>
		public int NumFireBalls { get; set; }
		/// <summary>
		/// Número de Aspersores numa área
		/// </summary>
		public int NumSpringles { get; set; }
		/// <summary>
		/// Número de Bocas Singulares numa área
		/// </summary>
		public int NumBocasSingulares { get; set; }
		/// <summary>
		/// Número de Bocas Siameses numa área
		/// </summary>
		public int NumBocasSiameses { get; set; }

	}
