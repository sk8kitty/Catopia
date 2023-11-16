using System.ComponentModel.DataAnnotations;

namespace Catopia.Models
{
    /// <summary>
    /// Represents an individual cat 
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// Unique identifier for each cat
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of cat
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Age of cat in months or years
        /// String because the number is not used for any math function &  it's just easier
        /// </summary>
        [Required]
        public string Age { get; set; }

        /// <summary>
        /// Gender of cat
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// Health conditions/needs of cat - NULLABLE
        /// </summary>
        public string? HealthNotes { get; set; }

        /// <summary>
        /// General description of cat personality
        /// </summary>
        [Required]
        public string AdoptionDescription { get; set; }

        /// <summary>
        /// More depthy description of cat behavior/likes/dislikes - NULLABLE
        /// </summary>
        public string? ExtendedDescription { get; set; }

        /// <summary>
        /// Whether or not the cat has been adopted
        /// </summary>
        [Required]
        public bool AdoptionStatus { get; set; }

        /// <summary>
        /// Link to picture of the cat
        /// </summary>
        [Required]
        public string ImageURL { get; set; }
    }
}
