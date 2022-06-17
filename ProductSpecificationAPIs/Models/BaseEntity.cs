using System.ComponentModel.DataAnnotations;

namespace ProductCodeOldAPIs.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }

        public BaseEntity()
        {
            UpdateDate = DateTime.Now;
        }
    }


}
