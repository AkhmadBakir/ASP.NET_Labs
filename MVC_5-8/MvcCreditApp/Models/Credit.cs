using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcCreditApp.Models
{
    public class Credit
    {
        // ID кредита
        [DisplayName("ID кредита")]
        public virtual int CreditId { get; set; }
        // Название
        [DisplayName("Название")] 
        public virtual string Head { get; set; }
        // Период, на который выдается кредит
        [DisplayName("Период, на который выдается кредит")]
        public virtual int Period { get; set; }
        // Максимальная сумма кредита
        [DisplayName("Максимальная сумма кредита")]
        public virtual int Sum { get; set; }
        // Процентная ставка
        [DisplayName("Процентная ставка")]
        public virtual int Procent { get; set; }
    }
}
