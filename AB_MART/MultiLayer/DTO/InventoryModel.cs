using System.ComponentModel.DataAnnotations;

public class InventoryModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Range(0, 5000, ErrorMessage = "Range 1 to 4999.99")]
    public double Purchase_Price { get; set; }

    public string Category { get; set; }
    public int Quantity { get; set; }
}
