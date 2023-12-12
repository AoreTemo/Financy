using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DL.Entities; 

public class Cost
{
    [Key]
    public int CostsId { get; set; }
    public string CostsDescription { get; set; }
    public int Amount { get; set; }
    public DateTime CostsDate { get; set; }

    [ForeignKey("AppUser")]
    public string Id { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

}
