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
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Date cat was born
        /// </summary>
        [Required(ErrorMessage = "The birthdate is required.")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gender of cat
        /// </summary>
        [Required(ErrorMessage = "The gender is required.")]
        public string Gender { get; set; }

        /// <summary>
        /// Health conditions/needs of cat - NULLABLE
        /// </summary>
        public string? HealthNotes { get; set; }

        /// <summary>
        /// General desc of cat personality
        /// Displays on 'card' panels in the adoption listings
        /// </summary>
        [Required(ErrorMessage = "A short description is required.")]
        public string BriefDescription { get; set; }

        /// <summary>
        /// Depthy desc of cat behavior/likes/dislikes - NULLABLE
        /// Displays in the details page of the given cat
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
        [Required(ErrorMessage = "The cat's picture is required.")]
        public string ImageURL { get; set; }


        /// <summary>
        /// Calculates the age of a cat based on birthday.
        /// Will return months if cat is less than 1 year old,
        /// and years if cat is greater than or equal to 1 year old.
        /// </summary>
        public string GetAge()
        {
            // cat's age in months
            int months = (DateTime.Now.Year - Birthdate.Year) * 12 + DateTime.Now.Month - Birthdate.Month;
            int years = months / 12;

            if (months < 12)
            {
                return $"{months} {(months == 1 ? "month" : "months")}";
            }
            else
            {
                return $"{years} {(years == 1 ? "year" : "years")}";
            }
        }
    }
}
