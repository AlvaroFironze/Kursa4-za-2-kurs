
using System.ComponentModel.DataAnnotations;

namespace ConfLog.Models
{
    public class ConstructorDetails
    {
        [Display(Name ="Путь сохраненмя txt файлов (Пустое поле = папка программы)")]
     
        [RegularExpression(@"(^([\wа-яА-Я '@№#$;%^)(\]\[]+:\\)([\wа-яА-Я '@№#$;%^)(\]\[]+\\)+([\wа-яА-Я '@№#$;%^)(\]\[]+)$|^$)", ErrorMessage = @"Путь должен начинаться с диска, директории разделяться \, а имена папок не должны содержать <>""/\|?*")]
        public string? Text { get; set; }

        [Display(Name = "Путь сохраненмя Excel файлов (Пустое поле = папка программы)")]
        [RegularExpression(@"(^([\wа-яА-Я '@№#$;%^)(\]\[]+:\\)([\wа-яА-Я '@№#$;%^)(\]\[]+\\)+([\wа-яА-Я '@№#$;%^)(\]\[]+)$|^$)", ErrorMessage = @"Путь должен начинаться с диска, директории разделяться \, а имена папок не должны содержать <>""/\|?*")]
        public string? Excel { get; set; }


        [Display(Name = "Адресс периёма tcp информации вашего ELC")]
        [Required(ErrorMessage = "Мы не можем знать адрес вашего ELC")]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.|:(\d?\d?\d?\d?\d)$)){4}", ErrorMessage = @"Адресс выглядит как Байт.Байт.Байт.Байт:Порт")]
        public string? Tcp { get; set; }


    }
}
