using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace lab6_7
{
    [Serializable]
    public class Product
    {
        [Required(ErrorMessage = "Отсутствует имя продукта")]
        public string nameOfProduct { get; set; }
        public string pathToPicture { get; set; }
        [Required(ErrorMessage = "Отсутствует категория")]
        public string category { get; set; }
        [Required(ErrorMessage = "Отсутствует рейтинг")]
        [RegularExpression(@"[0-9]{1}\,[0-9]{1}", ErrorMessage ="Неверный формат рейтинга")]
        public string rating { get; set; }
        [Required(ErrorMessage = "Отсутствует цена")]
        [RegularExpression(@"[0-9]{1,5}\,[0-9]{1,2}", ErrorMessage = "Неверный формат цены")]
        public string price { get; set; }
        [Required(ErrorMessage = "Отсутствует количество")]
        [RegularExpression(@"[0-9]{1,3}", ErrorMessage = "Неверный формат количества")]
        public string number { get; set; }
        [Required(ErrorMessage = "Отсутствует размер")]
        public string size { get; set; }

        public Product() { }
        public Product(string nameOfProduct, string category, string rating, string price, string number, string size)
        {
            this.nameOfProduct = nameOfProduct;
            this.category = category;

            if(category == "Телефон")
            {
                //pathToPicture = @"D:\University\2 курс\2-ой сем\ООП\lab6_7\lab6_7\bin\Debug\netcoreapp3.1\images\phone.jpg";
                pathToPicture = Path.GetFullPath(@"images\phone.jpg");
            }    
            else if(category == "Ноутбук")
            {
                //pathToPicture = @"D:\University\2 курс\2-ой сем\ООП\lab6_7\lab6_7\bin\Debug\netcoreapp3.1\images\notebook.jpg";
                pathToPicture = Path.GetFullPath(@"images\notebook.jpg");
            }
            else if(category == "Утюг")
            {
                //pathToPicture = @"D:\University\2 курс\2-ой сем\ООП\lab6_7\lab6_7\bin\Debug\netcoreapp3.1\images\iron.jpg";
                pathToPicture = Path.GetFullPath(@"images\iron.jpg");
            }
            else
            {
                pathToPicture = Path.GetFullPath(@"images\error.png");
            }

            this.rating = rating;
            this.price = price;
            this.number = number;
            this.size = size;
        }
    }
}
