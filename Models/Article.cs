using System.ComponentModel.DataAnnotations;

namespace Catopia.Models
{
    /// <summary>
    /// Represents an individual article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Unique identifier for each article
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of article
        /// </summary>
        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Date article is created
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Content of article
        /// </summary>
        [Required(ErrorMessage = "The content of the article is required.")]
        public string Content { get; set; }

        /// <summary>
        /// The email address of the admin who created the article
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Link to cover picture of article
        /// </summary>
        [Required(ErrorMessage = "The cover picture of the article is required.")]
        public string ImageURL { get; set; }
    }
}
