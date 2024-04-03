using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcCreditApp.Models
{
    public class Bid
    { // ID заявки
      public virtual int BidId { get; set; }
        // Имя заявителя
      //[Required(ErrorMessage = "Введите Ваше имя")]
      [DisplayName("Имя заявителя")] 
      public virtual string Name { get; set; }
        // Название кредита
        [Required(ErrorMessage = "Выберете тип кредита")]
        [DisplayName("Название кредита")] 
      public virtual string CreditHead { get; set; }
      // Дата подачи заявки
      [DisplayName("Дата подачи заявки")]
      [DataType(DataType.DateTime)] 
      [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
      public virtual DateTime bidDate { get; set; }
    }
}
